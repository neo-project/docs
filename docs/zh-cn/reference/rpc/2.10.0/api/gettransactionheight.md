# gettransactionheight 方法

获取交易高度。

## 参数说明

txid：交易id。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "gettransactionheight",
  "params": ["9ae1fd32d525eff2a1bb1fc8d0cd2cfb4cc97a06a232bb87fc58e4fe3bc2a845"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": 251488
}

```

响应说明：

返回该交易的高度。
