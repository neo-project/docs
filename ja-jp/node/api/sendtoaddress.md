# sendtoaddress メソッド

指定されたアドレスに転送します。

> [!注意]
> このコマンドを実行する前に、Neo-CLIノードでウォレットを開く必要があります。

## パラメータ説明

asset_id: アセットID（アセット識別子）。アセット登録時のRegistTransactionのトランザクションID。

NEOの場合: c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

GASの場合: 602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

残りのアセットIDは、[CLIコマンドリファレンス](../cli.md)の `list asset`コマンドまたはブロックチェーンブラウザで照会できます。

address: 転送先アドレス

value: 転送する金額

fee: 手数料、デフォルトは0 (省略可能)

## 例

リクエスト:

```json
{
  "jsonrpc": "2.0",
  "method": "sendtoaddress",
  "params": ["025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4", "AK4if54jXjSiJBs6jkfZjxAastauJtjjse", 1],
  "id": 1
}
```

レスポンス:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "Txid": "fbd69da6996cc0896691a35cba2d3b2e429205a12307cd2bdea5fbdf78dc9925",
    "Size": 262,
    "Type": "ContractTransaction",
    "Version": 0,
    "Attributes":[],
    "Vin": [
      { 
        "Txid": "19fbe968be17f4bd7b7f4ce1d27e39c5d8a857bd3507f76c653d204e1e9f8e63",
        "Vout": 0
      }
    ],
    "Vout": [
      {
        "N": 0,
        "Asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
        "Value": "1",
        "Address": "AK4if54jXjSiJBs6jkfZjxAastauJtjjse"
      },
      {
        "N": 1,
        "Asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
        "Value": "4978980",
        "Address": "AK4if54jXjSiJBs6jkfZjxAastauJtjjse"
       }
    ],
    "Sys_fee": "0",
    "Net_fee": "0",
    "Scripts": [
       {
        "Invocation": "40f02345c7e90245F085d0c588433ca9e89c6df58f3636b5240288aab5f081b1c67c3cad5946890de9001fcfe8d8b748b647b116891e6f1fb2393cc2f1aba45a81",
        "Verification": "21027b30333e0d0e6552ae6d1da9f9409f551e35ee9719305e945dc4dcba998456caac"
        }
     ]
  }
}
```

レスポンスの説明:

上記のトランザクション詳細が返された場合は、トランザクションが正常に送信されたことを示します。 そうでない場合はトランザクションの送信が失敗したことを意味します。

署名が不完全な場合は、署名が必要なトランザクションが返されます。

残高が不十分な場合は、エラーメッセージが返されます。
