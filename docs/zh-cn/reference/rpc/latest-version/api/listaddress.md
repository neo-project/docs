# listaddress 方法

列出当前钱包内的所有地址。

> [!Note]
>
> - 执行此命令前需要在 Neo-CLI 节点中打开钱包。
> - 此方法由插件提供，需要安装 [RpcWallet](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "listaddress",
  "params": [],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": [
        {
            "address": "ASL3KCvJasA7QzpYGePp25pWuQCj4dd9Sy",
            "haskey": true,
            "label": null,
            "watchonly": false
        },
        {
            "address": "AV2Ai7PXcNbjTSeKgWqsDEjLaEAJZpytru",
            "haskey": true,
            "label": null,
            "watchonly": false
        }
    ]
}
```

响应说明：

address：钱包内的地址。

watchonly：该地址是否为监视地址。