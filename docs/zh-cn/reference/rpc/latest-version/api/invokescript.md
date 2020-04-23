# invokescript 方法

通过虚拟机传递脚本之后返回结果。

> [!Note]
>
> - 此方法用于测试你的虚拟机脚本，如同在区块链上运行一样。这个RPC调用对区块链没有任何影响。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

script：一个由虚拟机运行的脚本，与 InvocationTransaction 中携带的脚本相同；
checkWitnessHashes：合约签名账户列表。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "invokescript",
  "params": ["0c142bf173f849d1d59123d097c009aa31624d39e73911c00c0962616c616e63654f660c14897720d8cd76f4f00abfa37c0edd889c208fde9b41627d5b52",["0xcadb3dc2faa3ef14a13b619c9a43124755aa2569"]],
  "id": 3
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "0c142bf173f849d1d59123d097c009aa31624d39e73911c00c0962616c616e63654f660c14897720d8cd76f4f00abfa37c0edd889c208fde9b41627d5b52",
        "state": "HALT",
        "gas_consumed": "2007570",
        "stack": [
            {
                "type": "Integer",
                "value": "9999885"
            }
        ],
        "tx": "004473771e2bf173f849d1d59123d097c009aa31624d39e73900e1f50500000000269f120000000000eae1200000003e0c142bf173f849d1d59123d097c009aa31624d39e73911c00c0962616c616e63654f660c14897720d8cd76f4f00abfa37c0edd889c208fde9b41627d5b5201420c40abc3a8055c64dcfd70a922cf1a09df19f2d6ccb0b4dacf24612cd40ebab3ab0bf591dd159783c06f187088fb277cde15e8baee0ebc8c3953df22f435215c3421290c2103b9c46c6d5c671ef5c21bc7aa7c30468aeb081a2e3895269adf947718d650ce1e0b410a906ad4"
    }
}
```

