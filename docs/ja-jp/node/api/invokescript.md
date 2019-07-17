# invokescript メソッド

スクリプトがVMを介した後の結果を返します。

> [!注意]
> 
> このメソッドは、VMスクリプトをその時点でブロックチェーン上で実行されているかのようにテストするものであり、このRPCコールはブロックチェーンには一切影響を与えません。

## パラメータの説明

script: VMで実行可能なスクリプト。InvocationTransactionで実行されるのと同じスクリプトです。

## 例

リクエストボディ:

```json
{
  "jsonrpc": "2.0",
  "method": "invokescript",
  "params": ["00046e616d656711c4d1f4fba619f2628870d36e3a9773e874705b"],
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
        "gas_consumed": "0.125",
        "stack": [
            {
                "type": "ByteArray",
                "value": "5265642050756c736520546f6b656e20332e312e34"
            }
        ]
    }
}
```
