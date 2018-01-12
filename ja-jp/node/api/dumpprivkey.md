# dumpprivkey メソッド

指定されたアドレスの秘密鍵をエクスポートします。

> [注意！]
> このコマンドを実行する前に、NEO-CLI ノードでウォレットを開く必要があります。

## パラメータ説明

アドレス:秘密鍵のアドレスをエクスポートするためには、そのアドレスが標準アドレスあることが必要です。

## 例

リクエスト:

```json
{
  "jsonrpc": "2.0",
  "method": "dumpprivkey",
  "params": ["ASMGHQPzZqxFB2yKmzvfv82jtKVnjhp1ES"],
  "id": 1
}
```

レスポンス:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "L3FdgAisCmV******************************9XM65cvjYQ1"
}
```

レスポンスの説明:

標準アドレスの秘密鍵を返す。
