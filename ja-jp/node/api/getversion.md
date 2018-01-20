# getversionメソッド

照会されたノードに関するバージョン情報を返します。

## 例

リクエストボディ:

```json
{
  "jsonrpc": "2.0",
  "method": "getversion",
  "params": [],
  "id": 3
}
```

レスポンスボディ:

```json
{
  "jsonrpc": "2.0",
  "id": 3,
  "result": {
      "port": 0,
      "nonce": 156443862,
      "useragent": "/NEO:2.3.5/"
  }
}
```
