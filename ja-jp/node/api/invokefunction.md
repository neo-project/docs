# invokefunction メソッド

指定のオペレーションとパラメータ付きのscripthashでスマートコントラクトを呼び出した後の結果を返します。

> [!注意]
> 
> このメソッドは、VMスクリプトがその時点でブロックチェーン上で実行されているかどうか、VMスクリプトをテストするためのものです。このRPCの呼び出しは、ブロックチェーンには何も影響しません。

## パラメータの説明

scripthash: スマートコントラクトのスクリプトハッシュ

operation: オペレーションの名前（文字列）

params: スマートコントラクトのオペレーションに渡されるパラメータ

## 例

リクエストボディ:

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "balanceOf",
    [
      {
        "type": "Hash160",
        "value": "bfc469dd56932409677278f6b7422f3e1f34481d"
      }
    ]
  ],
  "id": 3
}
```

レスポンスボディ:

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "0.338",
        "stack": [
            {
                "type": "ByteArray",
                "value": "00e1f505"
            }
        ]
    }
}
```

