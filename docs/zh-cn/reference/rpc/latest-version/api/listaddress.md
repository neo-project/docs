# listaddress 方法

列出当前钱包内的所有地址。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

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
            "address": "NZos4XyLUEUrD7RQBn9J1A1PyeCwQKqwtT",
            "haskey": true,
            "label": null,
            "watchonly": false
        },
        {
            "address": "NdAth5nq7RyG4HEJRsVJxnk9Q6XHoeB3No",
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

