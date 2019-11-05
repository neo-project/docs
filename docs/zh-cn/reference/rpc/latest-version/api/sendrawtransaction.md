# sendrawtransaction 方法

广播交易。

```json
{
  "jsonrpc": "2.0",
  "method": "sendrawtransaction",
  "params": [hex],
  "id": 1
}
```

### 参数说明

* hex：在程序中构造的已签名的交易序列化后的 16 进制字符串。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "sendrawtransaction",
  "params": ["80000001195876cb34364dc38b730077156c6bc3a7fc570044a66fbfeeea56f71327e8ab0000029b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc500c65eaf440000000f9a23e06f74cf86b8827a9108ec2e0f89ad956c9b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc50092e14b5e00000030aab52ad93f6ce17ca07fa88fc191828c58cb71014140915467ecd359684b2dc358024ca750609591aa731a0b309c7fb3cab5cd0836ad3992aa0a24da431f43b68883ea5651d548feb6bd3c8e16376e6e426f91f84c58232103322f35c7819267e721335948d385fae5be66e7ba8c748ac15467dcca0693692dac"],
  "id": 1
}
```

如果成功，响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "hash":"64af42150db8b15db6778f3efbbd8713f443e7447f854aab854cb1941950c218"
  }
}
```

如果失败，响应正文：
```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "error": {
        "code": -501,
        "message": "Block or transaction already exists and cannot be sent repeatedly."
    }
}
```

响应说明：

当结果为 false 时，区块广播失败并引发异常。可能返回以下错误代码：

错误代码 | 信息 |
| --------------- | ---- |
| -501 | 区块或交易已经存在，不能重复发送。|
| -502 | 内存池已满，不能发送更多交易。 |
| -503 | 无法验证区块。 |
| -504 | 区块或交易验证失败。 |
| -505 | 某个策略筛选器失败。 |
| -500 | 未知错误。