# getrawtransaction メソッド

指定されたハッシュ値に基づいて、対応するトランザクション情報を返します。

## パラメータ説明

txid: トランザクションID

verbose: 省略可能、デフォルト値は0。verboseが0の場合、ブロックのシリアル化された情報が返され、16進文字列で表されます。 詳細情報を取得する必要がある場合は、SDKを使用してデシリアライズする必要があります。 verboseが1の場合、JSON形式でブロックの詳細情報が返されます。

## 例

リクエスト:

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657"],
  "id": 1
}
```

レスポンス:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": "80000001195876cb34364dc38b730077156c6bc3a7fc570044a66fbfeeea56f71327e8ab0000029b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc500c65eaf440000000f9a23e06f74cf86b8827a9108ec2e0f89ad956c9b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc50092e14b5e00000030aab52ad93f6ce17ca07fa88fc191828c58cb71014140915467ecd359684b2dc358024ca750609591aa731a0b309c7fb3cab5cd0836ad3992aa0a24da431f43b68883ea5651d548feb6bd3c8e16376e6e426f91f84c58232103322f35c7819267e721335948d385fae5be66e7ba8c748ac15467dcca0693692dac"
}
```

リクエスト:

verbose = 1の場合は, JSON形式で結果を返します。

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657", 1],
  "id": 1
}
```

レスポンス:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "Txid": "f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657",
    "Size": 262,
    "Type": "ContractTransaction",
    "Version": 0,
    "Attributes":[],
    "Vin": [
      {
        "Txid": "abe82713f756eaeebf6fa6440057fca7c36b6c157700738bc34d3634cb765819",
        "Vout": 0
      }
     ],
     "Vout": [
      {
        "N": 0,
        "Asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
        "Value": "2950",
        "Address": "AHCNSDkh2Xs66SzmyKGdoDKY752uyeXDrt"
      },
      {
        "N": 1,
        "Asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
        "Value": "4050",
        "Address": "ALDCagdWUVV4wYoEzCcJ4dtHqtWhsNEEaR"
       }
    ],
    "Sys_fee": "0",
    "Net_fee": "0",
    "Scripts": [
      {
        "Invocation": "40915467ecd359684b2dc358024ca750609591aa731a0b309c7fb3cab5cd0836ad3992aa0a24da431f43b68883ea5651d548feb6bd3c8e16376e6e426f91f84c58",
        "Verification": "2103322f35c7819267e721335948d385fae5be66e7ba8c748ac15467dcca0693692dac"
      }
    ],
    "Blockhash": "9c814276156d33f5dbd4e1bd4e279bb4da4ca73ea7b7f9f0833231854648a72c",
    "Confirmations": 144,
    "Blocktime": 1496719422
  }
}
```
