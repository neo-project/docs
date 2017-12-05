# invokefunction 方法

使用给定的操作和参数，以散列值调用智能合约之后返回结果。

> [!Note]
>
> 此方法用于测试你的虚拟机脚本，如同在区块链上运行一样。这个RPC调用对区块链没有任何影响。

## 参数说明

scripthash：智能合约脚本散列值。

operation：操作名称（字符串）。

params：传递给智能合约操作的参数。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "balanceOf",
    [
      {
        "type": "Hash160",
        "value": "bfc469dd56932409677278f6b7422f3e1f34481d"
      }
    ]
  ],
  "id": 3
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "0.338",
        "stack": [
            {
                "type": "ByteArray",
                "value": "00e1f505"
            }
        ]
    }
}
```
