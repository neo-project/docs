# gettxout 方法

根据指定的散列和索引，返回对应的交易输出（零钱）信息。

## 参数说明

txid：交易 ID。

n：要获取的交易输出在该交易中的索引（从 0 开始）。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "gettxout",
  "params": ["f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657", 0],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "n": 0,
    "asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
    "value": "2950",
    "address": "AHCNSDkh2Xs66SzmyKGdoDKY752uyeXDrt"
  }
}
```



