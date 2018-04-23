# 取引所開発者向けドキュメント

本ドキュメントは、取引所の開発者が取引所のサーバにNEOノードをセットアップし、NEO資産の取引に関するプログラムの開発を完了するようガイドすることを目的としています。これを読む前に、[NEOホワイトペーパー](http://docs.neo.org/ja-jp/index.html)を読み、NEOの背景知識と技術を理解しておいてください。

一般に、取引所は以下のことをする必要があります：

- [NEOノードのサーバへのデプロイ](#NEOノードのサーバへのデプロイ)
- [ウォレットと預金アドレスの作成](#ウォレットと預金アドレスの作成)
- [グローバル資産の取引の取り扱い](#グローバル資産の取引の取り扱い)
- [NEP-5資産の取引の取り扱い](#NEP-5資産の取引の取り扱い)
- [（オプション）ユーザへのGASの配布](#(オプション)ユーザへのGASの配布)



## NEOノードのサーバへのデプロイ

NEOノードを取引所のサーバにデプロイするためには、以下のことを行います：

1.  バージョン2.0以降の[.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime)をサーバにインストールします。
2.  Githubから[Neo-CLI](https://github.com/neo-project/neo-cli/releases)をダウンロードし、NEOノードを有効にします。

更なる情報については、[NEOノードのインストールとデプロイ](node/setup.html)を参照して下さい。

## ウォレットと預金用アドレスの作成

### NEO-CLIについて

NEO-CLIは、開発者向けのコマンドラインクライアント(ウォレット)です。開発者はこれとインタラクトする2つの方法があります：

- CLI(コマンドラインインターフェース)コマンドを使用します。例えば、ウォレットを作成したり、アドレスを生成したりすることができます。
- リモートプロシージャコール(RPC)を使用します。例えば、指定のアドレスに転送したり、指定の高さのブロック情報を取得したり、指定の取引情報を取得したりすることができます。

NEO-CLIは次の機能を提供します：

- ウォレットとして、コマンドラインで資産を管理します。

  ウォレットを有効化するため、NEO-CLIディレクトリで以下のコマンドを入力してください：
  
  ```
  dotnet neo-cli.dll
  ```

  すべてのコマンドが有効であることをチェックするため、以下のコマンドを入力してください：

  ```
  help
  ```

  さらなる情報については、[CLI Command Reference](node/cli.html)を参照して下さい。
  
- ノードからブロックチェーンのデータを取得するAPIを提供します。インターフェースは[JSON-RPC](http://www.jsonrpc.org/specification)で提供され、基本的な通信はHTTP/HTTPSプロトコルを使用します。

  RPCサービスを提供するノードを開始するため、NEO-CLIのディレクトリで以下のコマンドを入力して下さい。
  
  ```
  dotnet neo-cli.dll /rpc
  ```

  更なるAPIの情報については、[API Reference](node/api.html)を参照してください。
  
  ​
### ウォレットの作成

取引所は、ユーザの預金用アドレスを管理するため、オンラインウォレットを作成する必要があります。ウォレットはアカウント(公開鍵と秘密鍵の両方)とコントラクトの情報を格納するために使用されます。これはユーザが保持する最も重要な証拠です。ユーザはウォレットファイルとウォレットパスワードをセキュアに保つ必要があります。彼らはこれらのデータを失ったり、開示したりしてはなりません。

> [!注意]
> 
> 取引所は、アドレス毎にウォレットを作成する必要はありません。オンラインウォレットは通常、ユーザのすべての預金用アドレスを保持します。コールドウォレット（オフラインウォレットは）、より良いセキュリティを提供する別のストレージオプションです。

ウォレットを作成するため、以下のことを行います：

1. `create wallet <path>`を入力します。

   `<path>`はウォレットのパスとウォレットのファイル名です。ファイルの拡張子は任意で、例えば、mywallet.db3のウォレットを作成します。

2. ウォレットのパスワードを設定します。

> [!注意]
> 
> ユーザの引き出し要求に対応するため、ウォレットは常にオープンにしておく必要があります。

|                    | Mainnet | Testnet |
| ------------------ | ------- | ------- |
| JSON-RPC via HTTPS | 10331   | 20331   |
| JSON-RPC via HTTP  | 10332   | 20332   |
| P2P                | 10333   | 20333   |
| websocket          | 10334   | 20334   |

### 預金用アドレスの生成

ウォレットは複数のアドレスを保管できます。取引所は、ユーザ毎に預金用アドレスを生成する必要があります。

預金用アドレスを生成するには2つの方法があります：

- ユーザが最初に預金(NEO/NEO GAS)すると、プログラムは動的にNEOのアドレスを生成します。利点は、一定の時間間隔でアドレスを生成する必要がないことですが、一方でウォレットをバックアップできないという欠点があります。

  動的にアドレスを生成するプログラムを開発するには、NEO-CLIのAPIである[getnewaddressメソッド](node/api/getnewaddress.html)を使用します。生成されたアドレスが返されます。
  
- 取引所は、予めNEOアドレスのバッチを作成します。ユーザが初めて(NEO/NEO GAS)を請求すると、取引所はNEOアドレスを彼/彼女に割り当てます。利点としては、ウォレットをバックアップするのに便利であることですが、一方で欠点は手動でNEOアドレスを生成する必要があることです。
  バッチでアドレスを生成するには、NEO-CLIコマンドの`create address [n]`を実行します。アドレスは address.txt ファイルに自動でエクスポートされます。
  [n]はオプションで、デフォルト値は1です。例えば、一度に100個のアドレスを生成するには、`create address 100`と入力します。


> [!注意]
> 
> いずれにしても、取引所は、アドレスをデータベースにインポートしてユーザに配布する必要があります。

## グローバル資産の取引の取り扱い

### ユーザの預金と引き出しに関するプログラムの開発

グローバル資産について、取引所は以下の機能を果たすためのプログラムを開発する必要があります：

1. NEO-CLI API（[getblockメソッド](node/api/getblock2.html)）を使用して新しいブロックを監視します。
2. 取引の情報に従ってユーザの預金を取り扱います。
3. 取引所に関連する取引情報を保管します。

#### ユーザの預金

ユーザの預金に関して、取引所は以下について注意する必要があります：

- NEOブロックチェーンは、サイドチェーンがなく、たった1つのメインチェーンのみであり、フォークもせず、孤立したブロックを持ちません。
- NEOブロックチェーンに記録された取引は改ざんできません。これは、確認が預金成功であることを意味します。
- 一般に、取引所の預金アドレスの残高は、取引所でユーザが保持する残高とは等しくありません。これは次の理由が考えられます：
 - 転送や引き出しをする際、NEOウォレットは、指定のアドレスから引き出す代わりに、ウォレット内の1つ以上のアドレスを調べ、要求に合致する最小限の変更を見つけ、取引の合計に加算し、それを入力として処理します(取引所が、自身のニーズに合わせてNEOウォレットの機能を書き換えない限り)。
 - 残高が一致しないことにつながる可能性のある操作、例えば、取引所が一部の資産をコールドウォレットに送信することです。
- NEOのアドレスには2つ以上の資産(NEOとNEO GAS)があります。ユーザが発行した資産(株やトークン)をさらに保管することができます。取引所はユーザが預金する際、資産タイプを決定する必要があります。他の資産をNEOのシェアやNEOとみなしたり、NEOとNEO GASの払い出しを混同したりしてはいけません。
- NEOのウォレットはフルノードで、ブロックと同期するためにオンライン状態を維持する必要があります。CLIのshow stateで、ブロックの同期ステータスを表示することができます。左側はローカルのブロック高さ、右側はノードのブロック高さです。
- 取引所では、ユーザ間の転送は、ブロックチェーンを通じて記録するべきではありません。一般に、ユーザの残高はデータベースに対して直接変更されます。ブロックチェーンには、預金と引き出しのみ記録する必要があります。

#### 預金記録

取引所は、ブロック内のすべての取引を監視し、取引用のアドレスに関するすべての取引をデータベースに記録するコードを記述する必要があります。入金が発生した場合は、ユーザーの残高を更新する必要があります。

開発者は、NEO-CLI APIの`getblock <index> [verbose]`メソッドを使用してブロック情報を取得できます。`<index>`はブロックのインデックスです。`[verbose]`はデフォルトで0です。`[verbose]`が0の場合、このメソッドは16進数のシリアライズされたブロック情報を返します。ブロックの詳細な情報を取得するには、16進文字列を逆シリアル化する必要があります。`[verbose]`が1の場合、メソッドは対応するブロックの詳細情報をJSON形式で返します。更なる詳細については、（[getblockメソッド](node/api/getblock2.html)）を参照してください。

ブロック情報には、取引の入出力が含まれています。取引所は、関連するすべての取引を記録する必要があります。取引の出力は、実際にはユーザの引き出しの取引記録です。取引所は、取引の出力にユーザのアドレスが1つでもあると分かると、その預金アドレスを所有する対応するユーザのNEO/NEO GASの残高を更新します。また、ある取引所は次のようにするでしょう：取引の出力として取引所内のアドレスを見つけると、データベース内に預金を記録し、いくつかの承認を確認後に、ユーザーの残高を変更します（他のブロックチェーンの操作に遵守する必要がない限り、この方法はお勧めしません）。

> [!注意]
> 
> - getblockcountメソッドは、メインチェーン内のブロックカウントを返します。getblockメソッドの最初のパラメータはブロックインデックスである`<index>`です。ブロックインデックス = ブロックの高さ = ブロックカウント - 1 です。getblockcountが1234を返す場合、getblock 1233を使って最新のブロックの情報を得る必要があります。
> - 預金と引き出しの取引(NEO/NEO GAS)は、ContractTransactionという名前の型です。取引所は、ブロック内の取引をチェックする際に、ContractTransactionの型の取引のみ気にする必要があります。
> - すべてのブロックの最初の取引はMinerTransactionでなければならないため、ブロックチェーンを横断する際に無視やジャンプすることができます。
> - NEOシステムはトランザクションを記録の単位として扱います。
> 

### ユーザーの引き出しの取り扱い

グローバル資産のユーザの引き出しを取り扱うために、取引所は以下のことを行う必要があります：

1. NEO-CLIで、ウォレットを開くために`open wallet <path>`を実行してください。

2. ユーザの引き出しの取引を記録し、ユーザの残高を修正してください。

3. （オプションで）カスタマーサービスが引き出し申請を処理します。

4. NEO-CLI APIの`sendtoaddress <asset_id> <address> <value>`を使用してユーザの引き出しアドレスに取引を送信して下さい。更なる情報については、[sendtoaddressメソッド](node/api/sendtoaddress.html)を参照してください。

   - `<asset_id>` ：アセットID
   - `<address>` ：引き出しアドレス
   - `<value>` ：引き出し金額
   
   APIの[sendmanyメソッド]((node/api/sendmany.html))を使用して、複数のアドレスに取引をバッチ送信することもできます。
   
5. 返された取引の詳細からJSON形式で取引IDを抽出し、データベースに記録します。

6. ブロックチェーンにより承認が確認されたら、引き出し取引を成功としてマークします。

   預金の監視と同様に、引き出しも監視する必要があります。引き出しの取引IDがブロックチェーン内に見つかった場合、この取引はすでに承認済みで、引き出しが成功したことを意味します。
   
> [!注意]
> 
> - ここで、10^8を掛けた数値ではなく実際の量を示します。
> - NEOの転送量は整数でなければなりません。それ以外の場合は、ウォレット内の緩やかな変更が不正確になるため、ブロックチェーンは承認しません。

## NEP-5資産の取引の取り扱い

### ユーザによる預金通知の受信

NEP-5資産の場合、取引所はユーザの預金の通知を取得する必要があります。各ブロックの通知はJSONファイルに記録され、それはすべてのNEP-5の取引の情報が含まれます。

Notificationファイルを取得するには、次のコマンドを実行します：

```
dotnet neo-cli.dll --rpc --record-notifications
```

以下に示すように、 "Notifications"フォルダがルートパスに生成されます：

![1](../assets/notification_1.jpg)

#### ![2](../assets/notification_2.jpg)

#### Notifications JSON ファイル

以下は、Notificationファイルのコンテンツを示します。

```json
[
{
    "txid": "0x65d62a736a73c4d15dc4e4d0bfc1e4bbc4ef220e163625d770eb05577b1afdee",
    "contract": "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "state":
    {
        "type": "Array",
        "value": [
        {
            "type": "ByteArray",
            "value": "7472616e73666572"
        },
        {
            "type": "ByteArray",
            "value": "d336d7eb9975a29b2404fdb28185e277a4b299bc"
        },
        {
            "type": "ByteArray",
            "value": "eab336cac807707295afa7e7da2f4683237f612a"
        },
        {
            "type": "ByteArray",
            "value": "006ad42d100100"
        }]
    }
}]
```

このファイルには、オブジェクトを1つのみ含むNotificationの配列があり、ブロック内で1つのNEP-5イベントがトリガーされていることを意味します。ファイル内の取引に関するパラメータは次のとおりです：

- **contract**: 取引所が資産タイプを識別するための、スマートコントラクトのスクリプトハッシュです。例として、"0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9"はRPX資産を識別するためのユニークなスクリプトハッシュとなります。

-  "state"配列に含まれる4つのオブジェクト:

   [event, from account, to account, amount]

   -  "bytearray"型で値が"7472616e73666572"の最初のオブジェクトは、例で示すように、文字列"transfer"に変換出来ます。"transfer"は資産移転を表すNEP5のメソッドです。
   -  配列の2番目のオブジェクトは、資産の転送元のアドレスになります。"bytearray"型で値が"d336d7eb9975a29b2404fdb28185e277a4b299bc"であり、"Ab2fvZdmnM4HwDgVbdBrbTLz1wK5TcEyhU"に変換することが出来ます。接頭辞が"0x"の16進文字列の場合、ビッグエンディアンとして処理されます。それ以外の場合は、スモールエンディアンとして処理されます。
   -  配列の3番目のオブジェクトは、資産が転送されるアカウントアドレスです。アドレスが取引所アカウントの場合、預金取引を意味します。
   -  配列の4番目のオブジェクトは転送量です。量には整数型とバイト型の2種類があります。この値を扱うとき、取引所は整数型のトランザクションに特別な注意を払うべきです。

### ユーザの残高照会

ユーザの残高を照会するため、取引所は次のことをする必要があります：

1. PRC APIのinvokefunctionを使って、3つのメソッド(balanceOf, decimals, and symbol) を呼び出すためのJSONファイルを作成します。
2. JSONファイルをNEO RPCサーバに送信します。
3. 返された値に従って、ユーザの残高を計算します。

#### invokefunction

JSONにおいて、一般的なinvokefunctionリクエストのbodyは次の形式です：

```
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "script hash",
    "method name",
    [
      {
        "optional arguments"
      }
    ]
  ],
  "id": 1
}
```

ユーザの残高を照会する際、これらの文字列を置き換える必要があります：

- スクリプトハッシュ

  NEP-5トークンのスクリプトハッシュを参照しています。例えば、RPXのスクリプトハッシュは次の通りです：*0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9*.

- メソッド名

  呼び出しているメソッド名です。ユーザの残高を参照するため、これらの3つのメソッドを呼び出す必要があります：

  **balanceOf**

  - 構文: `<code>public static BigInteger balanceOf(byte[] account)</code>`
  - 注意: "balanceOf" は'''account'''のトークン残高を返します。

  **decimals**

  - 構文: `<code>public static byte decimals()</code>`
  - 注意: "decimals" はトークンにより使用される小数点以下の桁数を返します。

  **symbol**

  - 構文: `<code>public static string symbol()</code>`
  - 注意: "symbol" はトークンのシンボルを返します。

- オプション引数

  オプションとして、呼び出すメソッドに引数が必要な場合、これらのパラメータを配列として渡すことができます。例えば、NEP-5の "balanceOf" は、"account"のトークンバランスを返します：
  
  <code>public static BigInteger balanceOf(byte[] account)</code> 

  このため、"balanceOf" メソッドの引数としてaccountを渡す必要があります。

#### 例

##### **balanceOfの呼び出し**

アカウントのアドレスが AJShjraX4iMJjwVt8WYYzZyGvDMxw6Xfbe と仮定し、Hash160型に変換し、このパラメータをJSONオブジェクトとして作成する必要があります。

```json
{
    "type": "Hash160",
    "value": "bfc469dd56932409677278f6b7422f3e1f34481d"
}
```

次に、JSONメッセージを次のように作成できます:

リクエスト本文：

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

リクエスト送信後は、次のレスポンスを得られます：

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

整数100000000に変換可能な "00e1f505" を返します。

##### **decimalsの呼び出し**

リクエスト本文：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "decimals", 
    []
    ],
  "id": 2
}
```

リクエスト送信後は、次のレスポンスが得られます：

```json
{
    "jsonrpc": "2.0",
    "id": 2,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "0.156",
        "stack": [
            {
                "type": "Integer",
                "value": "8"
            }
        ]
    }
}
```

整数8を返します。

##### **symbolの呼び出し**

リクエスト本文：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "symbol", 
    []
    ],
  "id": 1
}
```

リクエスト送信後は、次のレスポンスが得られます：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "0.141",
        "stack": [
            {
                "type": "ByteArray",
                "value": "525058"
            }
        ]
    }
}
```

"RPX" に変換可能な"525058"を返します。

##### **ユーザの残高の計算**

返された値に従い、次のようにユーザの残高を計算することができます：
残高 = 100000000/108 RPX = 1 RPX

### ユーザの引き出しの取り扱い

取引所は、NEP-5資産をユーザに送信する次のいずれかの方法を選択できます。

- NEO-CLI コマンド: `send`

- RPC メソッド: `sendtoaddress`
- PRC メソッド: `sendmany`

#### NEO-CLI コマンド: send

##### 構文

`send <txid|script hash> <address> <value> [fee = 0]`

##### パラメータ

- txid|script hash: アセットID

- address: 支払いアドレス

- value: 転送量

- fee: このパラメータは空のままにすることができます。デフォルトは0です。


コマンドはウォレットのパスワードを検証します。

##### 例

100RPXを、アドレス*AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b*に転送するため、次を入力してください：

```
send 0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9 AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100
```

グローバル資産を送信する必要がある場合、最初のパラメータをtxidに変更します。例えば、
NEOのtxid：0Xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b 
GASのtxid: 0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

#### RPC メソッド: sendtoaddress

キーの "params" には、少なくとも3つのパラメータの配列が含まれます。

`"params":[script hash, address, amount, fee(optional), change address(optional)]`

例えば、1RPXを*AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg*に送信するため、次のようにJSONファイルを作成し、それをRPCサーバに送信してください：

リクエスト本文：

```json
{
    "jsonrpc":"2.0",
    "method":"sendtoaddress",
    "params":[
        "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
        "AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg",
        "1",
        "0",
        "ARkJ8QcVdYL68WRvN3wj3TSvXX8CgmC73Z"
    ],
    "id":1
}
```

リクエスト送信後は、次のレスポンスが得られます：

```json
{
    "jsonrpc":"2.0",
    "id":1,
    "result":{
        "txid":"0xc6d4bf7c62fb47e0b2a6e838c3a1ca297622a1b1df7ceb2d30fa4ef8b7870700",
        "size":219,
        "type":"InvocationTransaction",
        "version":1,
        "attributes":[
            {
                "usage":"Script",
                "data":"5305fbbd4bd5a5e3e859b452b7897157eb20144f"
            }
        ],
        "vin":[

        ],
        "vout":[

        ],
        "sys_fee":"0",
        "net_fee":"0",
        "scripts":[
            {
                "invocation":"4054fbfca678737ae164ebf0e476da0c8215782bc42b67ae08cf4d8a716eeef81fcc17641e7f63893c3e685fb7eb1fb8516161c5257af41630f4508dde3afa3a8c",
                "verification":"210331d1feacd79b53aeeeeb9de56018eadcd07948675a50258f9e64a1204b5d58d1ac"
            }
        ],
        "script":"0400e1f50514d710f6f3f0bad2996a09a56d454cfc116a881bfd145305fbbd4bd5a5e3e859b452b7897157eb20144f53c1087472616e7366657267f91d6b7085db7c5aaf09f19eeec1ca3c0db2c6ecf166187b7883718089c8",
        "gas":"0"
    }
}
```

#### RPC メソッド: sendmany

キーの "params"には、少なくとも1つのパラメータの配列が含まれます。

`"params":[[], fee(optional), change address(optional)]`

例えば、15.5RPXと0.0001GASを*AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg*に送信するため、`change address`もまた*AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg*であり、JSON ファイルを次のように作成し、RPCサーバに送信します。

リクエスト本文：

```json
{
    "jsonrpc":"2.0",
    "method":"sendmany",
    "params":[
        [
            {
                "asset":"0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
                "value":"15.5",
                "address":"AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            },
            {
                "asset":"0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value":"0.0001",
                "address":"AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            }
        ],"0.00001","AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
    ],
    "id":1
}
```

リクエスト送信後は、次のレスポンスが得られます：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xe1351c9c9f2205a801d1b04f0df2d65fb4b1692d7d3b06cf41e0712fd1b12c9c",
        "size": 373,
        "type": "InvocationTransaction",
        "version": 1,
        "attributes": [
            {
                "usage": "Script",
                "data": "6d64dc9e50af8e911247436b264c8f7d791ad58c"
            }
        ],
        "vin": [
            {
                "txid": "0x9f0a28a912527604ab4b7d5e8b8d1a9b57631fcbab460132811ae7b6ed1ccaff",
                "vout": 1
            }
        ],
        "vout": [
            {
                "n": 0,
                "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value": "0.0001",
                "address": "AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            },
            {
                "n": 1,
                "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value": "0.01359",
                "address": "AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0.00001",
        "scripts": [
            {
                "invocation": "40644ab915419dbf855a52d5c75596e80b78c8e928cc0ce91ae6afc3b75a0c31ee54efe1836f9ec232f6c42dcb3ace0bfdc688e626944fa20970a76064975eade9",
                "verification": "2103d4b6fc2d116855f86a483d151182f68e88e6ddd13f3f1f3631e36300aac122bfac"
            }
        ],
        "script": "04801f635c14d710f6f3f0bad2996a09a56d454cfc116a881bfd146d64dc9e50af8e911247436b264c8f7d791ad58c53c1087472616e7366657267f91d6b7085db7c5aaf09f19eeec1ca3c0db2c6ecf166f871fb30fc859b77",
        "gas": "0"
    }
}
```

### こちらも参照ください

[NEP-5 Token Standard](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki "NEP5")

#### メソッド

##### name

- 構文: `<code>public static string name()</code>`
- 注意: "name"はトークン名を返します。

#### transfer

- 構文: `<code>public static bool transfer(byte[] from, byte[] to, BigInteger amount)</code>`
- 注意: "transfer"は'''from'''アカウントから'''to'''アカウントへ'''amount'''のトークンを転送します。

#### transferFrom ''(オプション)''

- 構文: `<code>public static bool transferFrom(byte[] originator, byte[] from, byte[] to, BigInteger amount)</code>`
- 注意: "transferFrom"は、'''originator'''が要求された'''amount'''を転送することが承認されている場合、'''from'''アカウントから'''to'''アカウントへ'''amount'''を送信します。

#### イベント

##### transfer

- 構文: `<code>public static event Action<byte[], byte[], BigInteger> transfer</code>`
- 注意: "transfer"イベントは、"transfer"メソッドの実行が成功した後に発生します。

## (オプション) ユーザへのGASの配布

取引所は、GASをユーザに配布するかどうかを決定することができます。GASは、記録や追加サービスのためにNEOブロックチェーンへ支払うために使用されます。

### GASとは ?

NeoGas(略してGAS)は、NEOブロックチェーンを使用する権利を表します。合計1億GASになります。GASは、新しいブロック毎に生成されます。GASはゼロから1億に成長するための生成プロセスを経ますが、その発行は定められた緩やかな減少ペースに沿って減速します。NEOを取得すると、GASはアルゴリズムに従ってシステム内で生成されます。

### 利用可能なGASの量の計算

- 利用可能な*GAS = f(neo_amount, Δt_const)*

  -  Δt_const = t_end - t_start
    - t_end = NEOが使われた状態になった瞬間
    - t_start = NEOが未使用の状態になった瞬間
    
  Δt_constは一定量のため、利用可能なGASも一定量です。そしてこの量はユーザが保有するNEOの量と、この金額をアドレスに入れてから引き出すまでの期間の関数です。

- 利用不可の*GAS = f(neo_amount, Δt_var)*

  - Δt_var = t - t_start
    - t は現在の時間
    - t_start = NEOが未使用の状態になった瞬間
    
  現在の時間は可変のため、利用不可のGASもまた時間によって増えます。言い換えると可変です。

### ユーザへのGASの配布

すべての取引所のアドレスが1つのウォレットに格納されていると仮定して、次の図は取引所がユーザAに配布する方法と計算式を示しています。

![gasflow_jp](sc/assets/gasflow_jp.png)

スナップショット間隔が短いほど、計算はより正確です。スナップショット間隔が均一でない場合、加重平均計算方法を使用します。

### GASの請求

ユーザがNEOを転送した後、GASは請求可能になります。例えば、**誰かがアドレスAにNEOを持っていて、GASが請求可能でない場合、彼は自分のNEOを自分宛(アドレスA)に転送するとNEO GASが請求可能になります。**

次の表はGASを請求のステップと対応するコマンドです。

| #    | Steps                                    | Command                                  |
| ---- | :--------------------------------------- | ---------------------------------------- |
| 1    | NEO-CLIを実行します                       | `./neo-cli.dll /rpc`                     |
| 2    | クライアントのバージョンを確認します        | `version`                                |
| 3    | クライアントの同期の高さを確認します（Height: height/headerの高さ, Nodes: 接続ノード数）。| `show state`                             |
| 4    | ウォレットを作成します                     | `create wallet /home/NeoNode/test.db3`   |
| 5    | 前のステップで作成したウォレットを開きます   | `open wallet /home/NeoNode/test.db3`     |
| 6    | ウォレット内のアドレスリストを確認します     | `list address`                           |
| 7    | ウォレット内の資産を確認します              | `list asset`                             |
| 8    | ウォレット内のGASの残高の詳細を確認します    | `show gas`                               |
| 9    | GASを請求可能な状態に変更するため、NEOをあなたのアドレス(例 AaAHt6Xi51iMCaDaYoDFTFLnGbBN1m75SM 1)に転送します | `send NEO AaAHt6Xi51iMCaDaYoDFTFLnGbBN1m75SM 1` |
| 10   | 再びウォレット内のGASの残高の詳細を取得します。このときすべてのGASが請求可能な状態である必要があります。 | `show gas`                               |
| 11   | GASを請求します                           | `claim gas`                              |
| 12   | 再度残高を確認します                       | `list asset`                             |

