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
  "method": "invoke",
  "params": [
"dc675afc61a7c0f7b3d2682bf6e1d8ed865a0e5f",
[
  {
    "type": "String",
    "value": "name"
  },
  {
    "type":"Boolean",
    "value": false
  }
]
  ],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "2.489",
        "stack": [
            {
                "type": "ByteArray",
                "value": "576f6f6c6f6e67"
            }
        ]
    }
}
```