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
    "value": "39e7394d6231aa09c097d02391d5d149f873f12b"
  }
  ```


> [!Note]
>
> 注意你需要根据传入地址的数据类型，使用正确的字节序格式。如果数据类型为 Hash160，输入大端序 scripthash；如果数据类型为 ByteArray，则输入小端序 scripthash。


## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "invokefunction",
  "params": [
    "0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26",
    "balanceOf",
    [
      {
        "type": "Hash160",
        "value": "0xe4b0b6fa65a399d7233827502b178ece1912cdd4"
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
        "script": "0c14d4cd1219ce8e172b50273823d799a365fab6b0e411c00c0962616c616e63654f660c14266f539addd5bd84340e6cb13dc11e2411d0f4b741627d5b52",
        "state": "HALT",
        "gas_consumed": "3553180",
        "stack": [
            {
                "type": "Integer",
                "value": "10000000000000000"
            }
        ]
    }
}
```

响应说明：

- script：合约的调用脚本，参考 [OpCodeConverter](https://github.com/chenzhitong/OpCodeConverter)  项目，可以将脚本转为如下OpCode（NeoVM 是基于栈的虚拟机，执行时从下向上执行）：

  ```
  PUSHDATA1 0xe4b0b6fa65a399d7233827502b178ece1912cdd4
  PUSHDATA1 balanceOf
  PUSHDATA1 0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26
  SYSCALL System.Contract.Call
  ```

- state：虚拟机状态， `HALT` 表示虚拟机执行成功，`FAULT` 表示虚拟机执行时遇到异常退出。

- gas consumed：调用智能合约时消耗的系统手续费。

- stack：合约执行结果，其中 value 如果是字符串或 ByteArray，则是 Base64 编码后的结果。

> [!Note]
>
> 当输入 invokefunction 命令后，节点并不是直接调用合约中的 `operation` 方法。而是调用该合约的 `main` 方法，并将 `operation` 和 `params` 作为实参传入。如果 main 方法里没有对 `operation` 和 `params` 做处理，将不能返回预期的结果。