# getnewaddress メソッド

新規アドレスの作成

> [注意]
> このコマンドを実行する前にNEO-CLIノードにあるウォレットを開く必要があります。

## 例

リクエスト:

```json
{
  "jsonrpc": "2.0",
  "method": "getnewaddress",
  "params": [],
  "id": 1
}
```

レスポンス:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AVHcdW3FGKbPWGHNhkPjgVgi4GGndiCxdo"
}
```

レスポンスの説明:

新たに作成されたアドレスを返します。
