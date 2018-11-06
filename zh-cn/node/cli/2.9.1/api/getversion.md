# getversion 方法

获取查询节点的版本信息。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getversion",
  "params": [],
  "id": 3
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 3,
  "result": {
      "port": 0,
      "nonce": 1546258664,
      "useragent": "/NEO:2.7.5/"
  }
}
```