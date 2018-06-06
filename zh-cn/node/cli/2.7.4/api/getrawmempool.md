# getrawmempool 方法

获取内存中未确认的交易列表。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getrawmempool",
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
    "b4534f6d4c17cda008a76a1968b7fa6256cd90ca448739eae8e828698ccc44e7"
  ]
}
```

这些是节点收到的未确定的交易，即零确认的交易。