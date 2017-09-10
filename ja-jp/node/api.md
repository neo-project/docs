# APIリファレンス

Neo-CLI内の各ノードは、ノードからブロックチェーンデータを得るためにAPIを提供し、ブロックチェーンアプリケーション開発を容易にします。そのインターフェースは[JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html)を経由して提供され、基盤となるプロトコルはHTTP/HTTPSを通信に使用します。RPCサービスを提供するノードを開始するためには、下記のコマンドを実行します。

`dotnet neo-cli.dll /rpc`

HTTPS経由でRPCサーバにアクセスするため、ノードを開始する前にコンフィグレーションファイルconfig.jsonの変更が必要で、ドメイン名、証明書、パスワードを設定します。

```json
{
  "ApplicationConfiguration": {
    "DataDirectoryPath": "Chain",
    "NodePort": 10333,
    "WsPort": 10334,
    "UriPrefix": [ "https://*:10331", "http://*:10332" ],
    "SslCert": "YourSslCertFile.xxx",
    "SslCertPassword": "YourPassword"
  }
}                                          
```

JSON-RPCサーバは、起動後にメインネットとテストネットに対応する下記ポートをモニタします。

P2PとWebSocketに関する情報は[Node/Introduction](introduction.md)を参照。

|                | （メインネット） | （テストネット） |
| -------------- | ------------ | ------------- |
| JSON-RPC HTTPS | 10331        | 20331         |
| JSON-RPC HTTP  | 10332        | 20332         |

## コマンドリスト

| コマンド                                       | リファレンス                                      | 説明                         | コメント       |
| ---------------------------------------- | --------------------------------------- | -------------------------- | -------- |
| [getbalance](api/getbalance.md)          | \<asset_id>                             |指定のアセットナンバーから、対応するウォレット内アセットのバランスを返す。   | ウォレットを開いている必要がある。   |
| [getbestblockhash](api/getbestblockhash.md) |                                         | メインチェイン内で最も高いブロックのハッシュを取得する。           |          |
| [getblock](api/getblock.md)              | \<hash> [verbose=0]                     | 指定のハッシュ値から、対応するブロック情報を返す。         |          |
| [getblock](api/getblock2.md)             | \<index> [verbose=0]                    | 指定のインデックスから、対応するブロック情報を返す。          |          |
| [getblockcount](api/getblockcount.md)    |                                         | メインチェイン内のブロック数を取得する。                 |          |
| [getblockhash](api/getblockhash.md)      | \<index>                                | 指定のインデックスから、対応するブロックのハッシュ値を返す。         |          |
| [getconnectioncount](api/getconnectioncount.md) |                                         | ノードがもつ現在のコネクション数を取得する。                 |          |
| [getrawmempool](api/getrawmempool.md)    |                                         | メモリ内の未確認トランザクションのリストを取得する。            |          |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                     | 指定のハッシュ値に基づき、対応するトランザクション情報を返す。         |          |
| [gettxout](api/gettxout.md)              | \<txid> \<n>                            | 指定のハッシュとインデックスに基づき、対応するトランザクション出力（変更）情報を返却する。 |          |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                                  | トランザクションをネットワークにブロードキャストする。[network protocol](network-protocol.md)を参照。                       |          |
| [sendtoaddress](api/sendtoaddress.md)    | \<asset_id> \<address> \<value> [fee=0] | 指定のアドレスに送信する。                     | ウォレットを開いている必要がある。   |
| submitblock                              | \<hex>                                  | 新たなブロックをサブミットする。                      | コンセンサスノードである必要がある。 |

## GETリクエスト例

代表的なJSON-RPC GETリクエストフォーマットは次のようになります。

下記は、メインチェイン内のブロック数を取得する方法の一例です。

Request URL:

```
http://somewebsite.com:10332?jsonrpc=2.0&method=getblockcount&params=[]&id=1
```

リクエスト送信後、下記のレスポンスが得られます。

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909129
}
```

## POSTリクエスト例

代表的なJSON-RPC Postリクエストは次のようになります。

下記は、メインチェイン内のブロック数を取得する方法の一例です。

Request URL:

```
http://somewebsite.com:10332
```

Request Body：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockcount",
  "params":[],
  "id": 1
}
```

リクエスト送信後、下記のレスポンスが得られます。

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909122
}
```

## テストツール

Postmanのクロム拡張機能を用いてテストを容易にできます(クロム拡張機能のインストールにはインターネット接続が必要です)。下記はテストのスクリーンショットです。

![image](http://docs.neo.org/images/2017-05-17_17-06-20.jpg)

![image](http://docs.neo.org/images/2017-05-17_16-55-58.jpg)

## その他

[C# JSON-RPC Command List](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)

