# invokefunction 方法

使用给定的操作和参数，以散列值调用智能合约之后返回结果。

> [!Note]
>
> - 此方法用于测试你的虚拟机脚本，如同在区块链上运行一样。这个RPC调用对区块链没有任何影响。
> - 此方法由插件提供，需要安装 [RpcWallet](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

scripthash：智能合约脚本散列值。注意你需要根据传入地址的数据类型，使用正确的字节序格式。如果数据类型为 Hash160, 输入大端序 scripthash; 如果数据类型为 ByteArray，则输入小端序 scripthash。

operation：操作名称（字符串）。

params：传递给智能合约操作的参数。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "af7c7328eee5a275a3bcaee2bf0cf662b5e739be",
    "balanceOf",
    [
      {
        "type": "Hash160",
        "value": "91b83e96f2a7c4fdf0c1688441ec61986c7cae26"
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
        "script": "1426ae7c6c9861ec418468c1f0fdc4a7f2963eb89151c10962616c616e63654f6667be39e7b562f60cbfe2aebca375a2e5ee28737caf",
        "state": "HALT, BREAK",
        "gas_consumed": "0.311",
        "stack": [
            {
                "type": "ByteArray",
                "value": "262bec084432"
            }
        ],
        "tx": "d101361426ae7c6c9861ec418468c1f0fdc4a7f2963eb89151c10962616c616e63654f6667be39e7b562f60cbfe2aebca375a2e5ee28737caf000000000000000000000000"
    }
}
```

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "af7c7328eee5a275a3bcaee2bf0cf662b5e739be",
    "decimals"
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
        "script": "00c108646563696d616c7367be39e7b562f60cbfe2aebca375a2e5ee28737caf",
        "state": "HALT, BREAK",
        "gas_consumed": "0.174",
        "stack": [
            {
                "type": "Integer",
                "value": "8"
            }
        ],
        "tx": "d1012000c108646563696d616c7367be39e7b562f60cbfe2aebca375a2e5ee28737caf000000000000000000000000"
    }
}
```
