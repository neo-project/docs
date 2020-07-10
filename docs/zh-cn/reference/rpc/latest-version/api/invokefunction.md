# invokefunction 方法

使用给定的操作和参数，通过合约脚本哈希调用智能合约之后返回结果。

> [!Note]
>
> - 此方法用于测试你的虚拟机脚本，调用时只是在 RPC 对应的节点试运行脚本并返回结果，不会对区块链数据产生影响。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

- scripthash：智能合约脚本哈希。

- operation：操作名称（字符串）。

- params：传递给智能合约操作的参数。

- cosigners：需要添加的签名列表，如不需要签名，无需传递此参数。

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
    [
        {
          "account": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c",
          "scopes": "CalledByEntry"      
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
        "tx": "0005d16e331c0357464b777ecf6b5f3ac3893ace1f8b1621f658738900000000001e47130000000000a81f200001011c0357464b777ecf6b5f3ac3893ace1f8b1621f60154180c14e3137eddba5f6485cad334a79bdb67c43273171f0c141c0357464b777ecf6b5f3ac3893ace1f8b1621f613c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b5201420c40de4c406084b738675c42519643018748215cf9de3ef9c6ec40eecf70b403250a2dddca6045e020bf713503c649ba4df0ff6cfc39459fb26929c0699aebcb0a0c290c210222d8515184c7d62ffa99b829aeb4938c4704ecb0dd7e340e842e9df1218263430b4195440d78"
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
- gas_consumed：调用智能合约时消耗的系统手续费。
- stack：合约执行结果，其中 value 如果是字符串或 ByteArray，则是 Base64 编码后的结果。
- tx：默认为 null，当打开钱包并传入正确的签名时会返回构造好的交易，即本次调用合约交易的 16 进制字符串，该交易可以直接使用 [sendrawtransaction](sendrawtransaction.md) 接口发送至链上。

> [!Note]
>
> invokefunction 命令执行的时候是调用合约的 `operation` 方法，`params` 将作为实参传入。如果合约 abi 里没有对应的 `operation` 方法，将不能返回预期的结果。
