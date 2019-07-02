# APIリファレンス

Neo-CLI内の各ノードは、ノードからブロックチェーンデータを得るためにAPIを提供し、ブロックチェーンアプリケーション開発を容易にします。そのインターフェースは[JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html)を経由して提供され、基盤となるプロトコルはHTTP/HTTPSを通信に使用します。RPCサービスを提供するノードを開始するためには、下記のコマンドを実行します。

`dotnet neo-cli.dll /rpc`

HTTPS経由でRPCサーバにアクセスするため、ノードを開始する前にコンフィグレーションファイルconfig.jsonの変更が必要で、ドメイン名、証明書、パスワードを設定します。

```json
{
  "ApplicationConfiguration": {
    "Paths": {
      "Chain": "Chain"
    },
    "P2P": {
      "Port": 10333,
      "WsPort": 10334
    },
    "RPC": {
      "Port": 10331,
      "SslCert": "YourSslCertFile.xxx",
      "SslCertPassword": "YourPassword"
    }
  }
}                                       
```

JSON-RPCサーバは、起動後にメインネットとテストネットに対応する下記ポートをモニタします。

P2PとWebSocketに関する情報は[NEOノード序論](introduction.md)を参照。

|                | （メインネット） | （テストネット） |
| -------------- | ------------ | ------------- |
| JSON-RPC HTTPS | 10331        | 20331         |
| JSON-RPC HTTP  | 10332        | 20332         |

## コマンドリスト

| コマンド                                       | リファレンス                                      | 説明                         | コメント       |
| ---------------------------------------- | --------------------------------------- | -------------------------- | -------- |
| [dumpprivkey](api/dumpprivkey.md)        | \<address>                               | 指定されたアドレスの秘密鍵をエクスポートします。 | ウォレットを開いている必要がある。      |
| [getbalance](api/getbalance.md)          | \<asset_id>                             |指定のアセットナンバーから、対応するウォレット内アセットのバランスを返す。   | ウォレットを開いている必要がある。   |
| [getbestblockhash](api/getbestblockhash.md) |                                         | メインチェイン内で最も高いブロックのハッシュを取得する。           |          |
| [getblock](api/getblock.md)              | \<hash> [verbose=0]                     | 指定のハッシュ値から、対応するブロック情報を返す。         |          |
| [getblock](api/getblock2.md)             | \<index> [verbose=0]                    | 指定のインデックスから、対応するブロック情報を返す。          |          |
| [getblockcount](api/getblockcount.md)    |                                         | メインチェイン内のブロック数を取得する。                 |          |
| [getblockhash](api/getblockhash.md)      | \<index>                                | 指定のインデックスから、対応するブロックのハッシュ値を返す。         |          |
| [getblocksysfee](api/getblocksysfee.md)  | \<index>                                 | 指定されたインデックスに基づいて、ブロックのシステム料金を返します。 |                              |
| [getconnectioncount](api/getconnectioncount.md) |                                         | ノードがもつ現在のコネクション数を取得する。                 |          |
| [getcontractstate](api/getcontractstate.md) | \<script_hash>                           | コントラクトのスクリプトハッシュをキーとして、契約情報を照会します。 |                              |
| [getnewaddress](api/getnewaddress.md)    |                                          | 新規アドレスの作成                     | ウォレットを開いている必要がある。      |
| [getrawmempool](api/getrawmempool.md)    |                                         | メモリ内の未確認トランザクションのリストを取得する。            |          |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                     | 指定のハッシュ値に基づき、対応するトランザクション情報を返す。         |          |
| [gettxout](api/gettxout.md)              | \<txid> \<n>                            | 指定のハッシュとインデックスに基づき、対応するトランザクション出力（変更）情報を返却する。 |          |
| [getpeers](api/getpeers.md)              |                                          | ノードが現在、接続/切断しているノードのリストを取得する。 |                              |
| [getversion](api/getversion.md)          |                                          | 照会されたノードに関するバージョン情報を返します。     |                              |
| [invoke](api/invoke.md)                  | \<script_hash>  \<params>                | スマートコントラクトをスクリプトハッシュからパラメータを指定して呼び出した結果を返します。 |                              |
| [invokefunction](api/invokefunction.md)  | \<script_hash>  \<operation>  \<params>  | スマートコントラクトをスクリプトハッシュからオペレーション名とパラメータを指定して呼び出した結果を返します。 |                              |
| [invokescript](api/invokescript.md)      | \<script>                                | スクリプトがVMを介した後の結果を返します。 |                              |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                                  | トランザクションをネットワークにブロードキャストする。[ネットワークプロトコル](network-protocol.md)を参照。                       |          |
| [sendtoaddress](api/sendtoaddress.md)    | \<asset_id> \<address> \<value> [fee=0] | 指定のアドレスに送信する。                     | ウォレットを開いている必要がある。   |
| [sendmany](api/sendmany.md)              | \<outputs_array> \[fee=0] \[change_address] | オーダーの一括転送。お釣り用アドレスを指定することができます。                      | ウォレットを開いている必要がある。      |
| submitblock                              | \<hex>                                  | 新たなブロックをサブミットする。                      | コンセンサスノードである必要がある。 |
| [validateaddress](api/validateaddress.md) | \<address>                               | アドレスが正しいNEOアドレスであることを確認します。 |                              |

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

リクエストURL:

```
http://somewebsite.com:10332
```

リクエスト:

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

![image](/zh-cn/node/assets/api_2.jpg)

![image](/assets/api_3.jpg)

## その他

[C# JSON-RPC Command List](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)

