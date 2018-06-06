# getrawtransaction 方法

根据指定的散列值，返回对应的交易信息。

## 参数说明

txid：交易 ID。

verbose：可选参数，verbose 默认值为 0，verbose 为 0 时返回的是交易的序列化后的信息，用 16 进制字符串表示，如果从中获取详细信息需要调用 SDK 来进行反序列化。verbose 为 1 时返回的是对应交易的详细信息，用 Json 格式字符串表示。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657"],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": "80000001195876cb34364dc38b730077156c6bc3a7fc570044a66fbfeeea56f71327e8ab0000029b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc500c65eaf440000000f9a23e06f74cf86b8827a9108ec2e0f89ad956c9b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc50092e14b5e00000030aab52ad93f6ce17ca07fa88fc191828c58cb71014140915467ecd359684b2dc358024ca750609591aa731a0b309c7fb3cab5cd0836ad3992aa0a24da431f43b68883ea5651d548feb6bd3c8e16376e6e426f91f84c58232103322f35c7819267e721335948d385fae5be66e7ba8c748ac15467dcca0693692dac"
}
```

请求正文：

verbose = 1，返回 JSON 格式的结果。

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657", 1],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "txid": "f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657",
    "size": 262,
    "type": "ContractTransaction",
    "version": 0,
    "attributes": [],
    "vin": [
      {
        "txid": "abe82713f756eaeebf6fa6440057fca7c36b6c157700738bc34d3634cb765819",
        "vout": 0
      }
    ],
    "vout": [
      {
        "n": 0,
        "asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
        "value": "2950",
        "address": "AHCNSDkh2Xs66SzmyKGdoDKY752uyeXDrt"
      },
      {
        "n": 1,
        "asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
        "value": "4050",
        "address": "ALDCagdWUVV4wYoEzCcJ4dtHqtWhsNEEaR"
      }
    ],
    "sys_fee": "0",
    "net_fee": "0",
    "scripts": [
      {
        "invocation": "40915467ecd359684b2dc358024ca750609591aa731a0b309c7fb3cab5cd0836ad3992aa0a24da431f43b68883ea5651d548feb6bd3c8e16376e6e426f91f84c58",
        "verification": "2103322f35c7819267e721335948d385fae5be66e7ba8c748ac15467dcca0693692dac"
      }
    ],
    "blockhash": "9c814276156d33f5dbd4e1bd4e279bb4da4ca73ea7b7f9f0833231854648a72c",
    "confirmations": 144,
    "blocktime": 1496719422
  }
}
```



