# getassetstate メソッド

指定されたアセット番号に基づいてアセット情報を照会します。 

## パラメータ説明

asset_id: アセットID（アセット識別子）。アセット登録時のRegistTransactionのトランザクションID。

NEOの場合: c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

GASの場合: 602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

残りのアセットIDは、[CLIコマンドリファレンス](../cli.md)の `list asset`コマンドまたはブロックチェーンブラウザで照会できます。

## 例

リクエスト:

```json
{
  "jsonrpc": "2.0",
  "method": "getassetstate",
  "params": ["c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b"],
  "id": 1
}
```

レスポンス:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "version": 0,
        "id": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
        "type": "SystemShare",
        "name": [
            {
                "lang": "zh-CN",
                "name": "NEO"
            },
            {
                "lang": "en",
                "name": "NEO"
            }
        ],
        "amount": "100000000",
        "available": "100000000",
        "precision": 0,
        "owner": "00",
        "admin": "Abf2qMs1pzQb8kYk9RuxtUb9jtRKJVuBJt",
        "issuer": "Abf2qMs1pzQb8kYk9RuxtUb9jtRKJVuBJt",
        "expiration": 2000000,
        "frozen": false
    }
}
```

