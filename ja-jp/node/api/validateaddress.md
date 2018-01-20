# validateaddress メソッド

アドレスが正しいNEOアドレスであることを確認します。

## パラメータの説明

address: アドレス

## 例

リクエストボディ:

```json
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": ["AQVh2pG732YvtNaxEGkQUei3YA4cvo7d2i"],
  "id": 1
}
```

レスポンスボディ:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "AQVh2pG732YvtNaxEGkQUei3YA4cvo7d2i",
        "isvalid": true
    }
}
```

リクエストボディ:

```json
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": ["152f1muMCNa7goXYhYAQC61hxEgGacmncB"],
  "id": 1
}
```

レスポンスボディ:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "152f1muMCNa7goXYhYAQC61hxEgGacmncB",
        "isvalid": false
    }
}
```

