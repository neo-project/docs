# getversion 方法

获取查询节点的版本信息。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getversion",
  "params": [],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": "1",
    "result": {
        "tcpPort": 12333,
        "wsPort": 12334,
        "nonce": 245971508,
        "useragent": "/Neo:3.0.0-preview1/"
    }
}
```
