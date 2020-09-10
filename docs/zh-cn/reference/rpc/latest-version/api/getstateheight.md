# getstateheight 方法

获取当前最高高度以及被验证过的state高度。

#### 参数说明

无

#### 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getstateheight",
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
    "blockheight": 6143917,
    "stateheight": 6143916
  }
}
```
