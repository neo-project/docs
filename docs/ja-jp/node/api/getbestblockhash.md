# getbestblockhash メソッド

メインチェーン内の最も高いブロックのハッシュ値を返します。

## 例

リクエスト:

```json
{
   "jsonrpc": "2.0",
   "method": "getbestblockhash",
   "params":[],
   "id": 1
}
```

レスポンス:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": "773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e"
}
```

レスポンスの説明:

result: メインチェーン内の最も高いブロックのハッシュ値。
