# invoke メソッド

スマートコントラクトをスクリプトハッシュからパラメータを指定して呼び出した結果を返します。

> [!Note]
> 
> このメソッドは、VMスクリプトをその時点でブロックチェーン上で実行されているかのようにテストするものであり、このRPCコールはブロックチェーンには一切影響を与えません。

## パラメーター説明

scripthash: スマートコントラクトスクリプトハッシュ

params: スマートコントラクトに渡すパラメーター

## 例

リクエストボディ:

```json
{
  "jsonrpc": "2.0",
  "method": "invoke",
  "params": [
"dc675afc61a7c0f7b3d2682bf6e1d8ed865a0e5f",
[
  {
    "type": "String",
    "value": "name"
  },
  {
    "type":"Boolean",
    "value": false
  }
]
  ],
  "id": 1
}
```

レスポンスボディ:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "2.489",
        "stack": [
            {
                "type": "ByteArray",
                "value": "576f6f6c6f6e67"
            }
        ]
    }
}
```
