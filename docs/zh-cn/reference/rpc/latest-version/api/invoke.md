# invoke 方法

使用给定的参数以散列值调用智能合约，并返回结果。

> [!Note]
>
> - 此方法用于测试你的虚拟机脚本，如同在区块链上运行一样。这个RPC调用对区块链没有任何影响。
> - 此方法由插件提供，需要安装 [RpcWallet](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

scripthash：智能合约脚本散列值。

params：传递给智能合约的参数。

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
                "type": "Boolean",
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
        "script": "00046e616d65675f0e5a86edd8e1f62b68d2b3f7c0a761fc5a67dc",
        "state": "HALT, BREAK",
        "gas_consumed": "2.489",
        "stack": [
            {
                "type": "ByteArray",
                "value": "576f6f6c6f6e67"
            }
        ],
        "tx": "d1011b00046e616d65675f0e5a86edd8e1f62b68d2b3f7c0a761fc5a67dc000000000000000000000000"
    }
}
```
