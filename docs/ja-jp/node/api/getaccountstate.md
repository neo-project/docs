# getaccountstate メソッド

アカウントのアドレスに基づいて、アカウントのアセット情報を照会します。

## パラメータ説明

address: アカウントのアドレス。Aから始まる34ビット長の文字列（例：AJBENSwajTzQtwyJFkiJSv7MAaaMc7DsRz）。

## 例

リクエスト:

```json
{
  "jsonrpc": "2.0",
  "method": "getaccountstate",
  "params": ["AJBENSwajTzQtwyJFkiJSv7MAaaMc7DsRz"],
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
        "script_hash": "1179716da2e9523d153a35fb3ad10c561b1e5b1a",
        "frozen": false,
        "votes": [],
        "balances": [
            {
                "asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": "94"
            }
        ]
    }
}
```

レスポンスの説明:

script_hash: コントラクトのスクリプトハッシュ。NEOでのアカウントはすべてコントラクトアカウントになります。

frozen: アカウントが凍結しているかどうかを判定します

votes: 対象アカウントの、投票に使用されたNEOの数量を照会します

balance: 対象アドレスのアセット残高

asset: アセットID

value: アセットの数量

