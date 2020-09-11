# invokefunction 方法

使用给定的操作和参数，通过合约脚本哈希调用智能合约之后返回结果。

> [!Note]
>
> - 此方法用于测试你的虚拟机脚本，调用时只是在 RPC 对应的节点试运行脚本并返回结果，不会对区块链数据产生影响。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

- scripthash：智能合约脚本哈希。

- operation：操作名称（字符串）。

- params：传递给智能合约操作的参数，可选。

- sender：交易发送者，支付交易费的账户，默认是 singers 中第一个账户，可选。

- signers: 签名账户列表，可选
  * account: 签名账户
  * scopes: 签名的作用域，允许的值: FeeOnly, CalledByEntry, CustomContracts, CustomGroups, Global
  * allowedcontracts: 如果 scopes 是 CustomContracts，该字段是签名生效的合约 Hash 列表
  * allowedgroups: 如果 scopes 是 CustomGroups，该字段是签名生效的公钥列表。

注意你需要根据传入地址的数据类型，使用正确的字节序格式。如果数据类型为 Hash160，输入大端序 scripthash；如果数据类型为 ByteArray，则输入小端序 scripthash。

例如：

  ```json
  {
    "type": "String",
    "value": "Hello"
  }

  {
    "type": "Hash160",
    "value": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c"
  }

  {
    "type": "ByteArray",
    "value": "7472616e73666572"
  }
  ```

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "invokefunction",
  "params": [
    "0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc",
    "transfer",
    [
      {
        "type":"Hash160",
        "value":"0xf621168b1fce3a89c33a5f6bcf7e774b4657031c"
        },
      {
        "type":"Hash160",
        "value":"0x1f177332c467db9ba734d3ca85645fbadd7e13e3"
        },
      {
        "type":"Integer",
        "value":"8"
        }        
    ],
    "0x1f5da2e47b37c4b96668a98da4ed8feb94bdf146",
    [
        {
          "account": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c",
          "scopes": "CalledByEntry",
          "allowedcontracts":[],
          "allowedgroups":[]
        }
    ]
  ]
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "script": "180c14e3137eddba5f6485cad334a79bdb67c43273171f0c141c0357464b777ecf6b5f3ac3893ace1f8b1621f613c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b52",
        "state": "HALT",
        "gasconsumed": "9007960",
        "stack": [
            {
                "type": "Boolean",
                "value": true
            }
        ],
        "tx": null
    }
}
```

响应说明：

- script：合约的调用脚本，参考 [OpCodeConverter](https://github.com/chenzhitong/OpCodeConverter)  项目，可以将脚本转为如下OpCode（NeoVM 是基于栈的虚拟机，执行时从下向上执行）：

   ```
   PUSHINT16 8
   PUSHDATA1 0x1f177332c467db9ba734d3ca85645fbadd7e13e3
   PUSHDATA1 0xf621168b1fce3a89c33a5f6bcf7e774b4657031c
   PUSHDATA1 transfer
   PUSHDATA1 0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc
   SYSCALL System.Contract.Call
   ```
   
- state：虚拟机状态， `HALT` 表示虚拟机执行成功，`FAULT` 表示虚拟机执行时遇到异常退出。
- gasconsumed：调用智能合约时消耗的系统手续费。
- stack：合约执行结果，其中 value 如果是字符串或 ByteArray，则是 Base64 编码后的结果。
- tx：本次调用合约交易的 hex string，需要打开钱包并且传入正确的签名账户参数，否则 tx 为 null。

> [!Note]
>
> 当输入 invokefunction 命令后，节点调用该合约的 `operation` 方法，并将 `params` 作为实参传入。如果合约里没有对 `operation` 和 `params` 做处理，将不能返回预期的结果。
