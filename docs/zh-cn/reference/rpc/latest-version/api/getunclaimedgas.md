# getunclaimedgas 方法

返回指定地址未提取的 GasToken。

## 参数说明

- address：要查询的地址。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getunclaimedgas",
  "params": ["NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "unclaimed": "9693738",
        "address": "NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y"
    }
}
```