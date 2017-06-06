# getbestblockhash 方法

获取主链中高度最大的区块的散列。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getbestblockhash",
  "params": [],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": "773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e"
}
```

响应说明：

result：主链中高度最大的区块的散列。

