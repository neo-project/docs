# sendmany メソッド

オーダーの一括転送。お釣り用アドレスを指定することができます。

> [!Note]
> このコマンドを実行する前に、NEO-CLIノード内のウォレットをオープンする必要があります。

## パラメータの説明

\<outputs_array> \[fee=0] \[change_address]

Outputs_array：配列。配列内の各要素のデータ構造は次のようになります：

​	{"asset": \<asset>,"value": \<value>,"address": \<address>}

​	asset：アセットID（アセット識別子）。登録時の資産の`RegistTransaction` ID

​	For NEO：c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

​	For NeoGas：602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

  残りのアセットIDは、[CLI commandline](../cli.md)で渡すことができます。`list Asset`コマンドクエリは、ブロックチェーンブラウザでも照会できます。


​	value：転送量

​	address：宛先アドレス

Fee：取り扱い手数料。オプションのパラメータで、デフォルトは0です。

Change_address：お釣り用アドレス。オプションのパラメータで、デフォルトはウォレット内の最初の標準アドレスです。

## 例

リクエストボディ：

```json
{
  "jsonrpc": "2.0",
  "method": "sendmany",
  "params": [[{"asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4","value": 1,"address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"},{"asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4","value": 1,"address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"}]],
  "id": 1
}
```

レスポンスボディ:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "27b9a82ed519eec17c5520927b3f472e4df28b835c24dba25645e1650ed8d2ac",
        "size": 322,
        "type": "ContractTransaction",
        "version": 0,
        "attributes": [],
        "vin": [
            {
                "txid": "8674c38082e59455cf35cee94a5a1f39f73b617b3093859aa199c756f7900f1f",
                "vout": 0
            }
        ],
        "vout": [
            {
                "n": 0,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "1",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "n": 1,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "1",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "n": 2,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "999998",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0",
        "scripts": [
            {
                "invocation": "40844144eb6819cb094afee2db5e5da078cfc7bbe29dbc60e47b4c3b4bdf77a5fd97865ae9b5a8d8bb3fa20f1441a58a05f848b2ea49c6c0dbbfc5ed241b226665",
                "verification": "210208c5203d32f960c54c225f140c1020408b114c15d29082fc959dac6874828fccac"
            }
        ]
    }
}
```

レスポンスの説明:

上記のようにトランザクションの詳細を返し、トランザクションが正常に送信されたか、トランザクションが失敗したかを通知します。

JSONフォーマットが正しくない場合、パーサエラーが返されます。
署名が不完全な場合、ペンディングトランザクションが返されます。
残高不足の場合、エラーメッセージが返されます。
