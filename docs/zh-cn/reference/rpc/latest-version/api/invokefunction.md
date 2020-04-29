# invokefunction 方法

使用给定的操作和参数，通过合约脚本哈希调用智能合约之后返回结果。

> [!Note]
>
> - 此方法用于测试你的虚拟机脚本，如同在区块链上运行一样。这个RPC调用对区块链没有任何影响。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

- scripthash：智能合约脚本哈希。

- operation：操作名称（字符串）。

- params：传递给智能合约操作的参数。

  > [!Note]
  >
  > 注意你需要根据传入地址的数据类型，使用正确的字节序格式。如果数据类型为 Hash160，输入大端序 scripthash；如果数据类型为 ByteArray，则输入小端序 scripthash。

- checkWitnessHashes: 合约签名账户列表。

  例如：

  ```json
  {
    "type": "String",
    "value": "Hello"
  }
  ```

  ```json
  {
    "type": "Hash160",
    "value": "39e7394d6231aa09c097d02391d5d149f873f12b
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
    "0x806b7fa0db3b46d6c42e1e1b0a7fd50db9d4a9b0",
    "transfer",
    [
      {
        "type": "Hash160",
        "value": "0xcadb3dc2faa3ef14a13b619c9a43124755aa2569"
      },
      {
        "type": "Hash160",
        "value": "0x2916eba24e652fa006f3e5eb8f9892d2c3b00399"
      },
      {
        "type": "Integer",
        "value": "1000"
      }
    ],
    ["0xcadb3dc2faa3ef14a13b619c9a43124755aa2569"]
  ]
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "script": "1a0c149903b0c3d292988febe5f306a02f654ea2eb16290c146925aa554712439a9c613ba114efa3fac23ddbca13c00c087472616e736665720c14b0a9d4b90dd57f0a1b1e2ec4d6463bdba07f6b8041627d5b52",
        "state": "HALT",
        "gas_consumed": "9413130",
        "stack": [
            {
                "type": "Integer",
                "value": "1"
            }
        ]
    }
}
```

响应说明：

- script：合约的调用脚本，参考 [OpCodeConverter](https://github.com/chenzhitong/OpCodeConverter)  项目，可以将脚本转为如下OpCode（NeoVM 是基于栈的虚拟机，执行时从下向上执行）：

```
PUSHINT16 1000
PUSHDATA1 0x2916eba24e652fa006f3e5eb8f9892d2c3b00399
PUSHDATA1 0xcadb3dc2faa3ef14a13b619c9a43124755aa2569
PUSHDATA1 transfer
PUSHDATA1 0x806b7fa0db3b46d6c42e1e1b0a7fd50db9d4a9b0
SYSCALL System.Contract.Call
```

- state：虚拟机状态， `HALT` 表示虚拟机执行成功，`FAULT` 表示虚拟机执行时遇到异常退出。
- gas_consumed：调用智能合约时消耗的系统手续费。
- stack：合约执行结果，其中 value 如果是字符串或 ByteArray，则是 Base64 编码后的结果。

> [!Note]
>
> 当输入 invokefunction 命令后，节点并不是直接调用合约中的 `operation` 方法。而是调用该合约的 `main` 方法，并将 `operation` 和 `params` 作为实参传入。如果 main 方法里没有对 `operation` 和 `params` 做处理，将不能返回预期的结果。
