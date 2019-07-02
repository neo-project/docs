# getrawmempool メソッド

メモリ内の未承認トランザクションのリストを取得します。

## 例

リクエスト:

```json
{
   "jsonrpc": "2.0",
   "method": "getrawmempool",
   "params":[],
   "id": 1
}
```

レスポンス:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": [
     "B4534f6d4c17cda008a76a1968b7fa6256cd90ca448739eae8e828698ccc44e7"
   ]
}
```

ノードにより受信された未承認状態のトランザクション（承認数がゼロのトランザクション）を返します。
