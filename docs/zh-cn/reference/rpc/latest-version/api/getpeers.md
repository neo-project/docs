# getpeers 方法

获得该节点当前已连接/未连接的节点列表。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getpeers",
  "params": [],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "unconnected": [],
        "bad": [],
        "connected": [
            {
                "address": "47.90.28.99",
                "port": 21333
            },
            {
                "address": "47.90.28.99",
                "port": 22333
            }
        ]
    }
}
```

响应说明：

- unconnected：当前未连接到的节点。

- bad：不再连接（拉黑）的节点。

- connected：当前已连接到的节点。
