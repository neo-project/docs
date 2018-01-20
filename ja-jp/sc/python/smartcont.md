# スマートコントラクトとの相互作用

neo-pythonの実装のための共通したユースケースとして、スマートコントラクトの相互作用が挙げられます。典型的なスマートコントラクトイベントには、`Runtime.Notify`、`Runtime.Log`、完遂あるいは失敗、そして`Storage.GET/PUT/DELETE`が含まれます。

## イベントの種類

以下のリストが、現在のところneo-pythonが扱えるスマートコントラクトイベントの種類です。

```python
RUNTIME_NOTIFY = "SmartContract.Runtime.Notify"
RUNTIME_LOG = "SmartContract.Runtime.Log"

EXECUTION = "SmartContract.Execution.*"
EXECUTION_INVOKE = "SmartContract.Execution.Invoke"
EXECUTION_SUCCESS = "SmartContract.Execution.Success"
EXECUTION_FAIL = "SmartContract.Execution.Fail"

STORAGE = "SmartContract.Storage.*"
STORAGE_GET = "SmartContract.Storage.Get"
STORAGE_PUT = "SmartContract.Storage.Put"
STORAGE_DELETE = "SmartContract.Storage.Delete"

```

受け取ったブロックでこのようなイベントが起きた場合、`SmartContractEvent`インスタンスが`neo.EventHub`を通してディスパッチされます。

## SmartContractEvent

イベントを処理する人は、いつもひとつの実引数、つまり、`neo.EventHub.SmartContractEvent`のインスタンスを受け取ります。これは、 現在のイベントに関するすべての情報を含みます。`SmartContractEvent`は、以下のプロパティを有します。

| プロパティ            | データ型 | 説明                              |
| ------------------- | ---------- | ---------------------------------------- |
| `event_type`        | str        | `neo.EventHub.SmartContractEvent`でのイベントタイプのうちのひとつのイベント |
| `contract_hash`     | UInt160    | コントラクトのハッシュ                     |
| `tx_hash`           | UInt256    | トランザクションのハッシュ                  |
| `block_number`      | int        | そのイベントを受け取ったときのブロックナンバー  |
| `event_payload`     | object[]   | どんな種類のデータタイプをスマートコントラクトが吐くかに応じた、オブジェクトのリスト（例：`Runtime.Notify`で） |
| `execution_success` | bool       | 呼び出しのメソッドが成功したかどうか |
| `test_mode`         | bool       | そのイベントが、ブロックチェーンから受け取ったものではなく、ローカルのTestInvokeによってディスパッチされたかどうか |

## neo.contrib.smartcontract.SmartContract

`neo.contrib.smartcontract.SmartContract`を使うことにより、開発者はこれらのイベントを容易に署名することができます。例として、ハッシュ`6537b4bd100e514119e3a7ab49d520d20ef2c2a4`とともにスマートコントラクトの`Runtime.Notify`イベントを監視するには、次のようにします。

```python
from neo.contrib.smartcontract import SmartContract

smart_contract = SmartContract("6537b4bd100e514119e3a7ab49d520d20ef2c2a4")

@smart_contract.on_notify
def sc_notify(event):
    print("SmartContract Runtime.Notify event:", event)

    # イベントのペイロードリストが少なくともひとつの要素を有することを確認してください。
    if not len(event.event_payload):
        return

    # イベントのペイロードリストは少なくとも一つの要素を有します。スマートコントラクトの
    # 開発者として、バイトにどのデータタイプがあるのか、そして、どのようにそれをデコードできる
    # かを知らなければなりません。この例であれば、ただの文字列型なので、utf-8でデコードでき
    # ます。
    print("- payload part 1:", event.event_payload[0].decode("utf-8"))

```

現在使用できるデコレーターは、以下のとおりです。

| デコレーター       | スマートコントラクトイベント                  |
| --------------- | -------------------------------------- |
| `@on_any`       | すべてのイベント                             |
| `@on_notify`    | `Runtime.Notify`                       |
| `@on_log`       | `Runtime.Log`                          |
| `@on_storage`   | PUT、GET、DELETEをストレージ            |
| `@on_execution` | メソッドの呼び出し、成功と失敗 |

下は、もうひとつの例です。あなたが書いたコードのすべてのイベントを監視したり、イベントタイプ間を識別するには、以下を参照してください。

```python
from neo.contrib.smartcontract import SmartContract
from neo.EventHub import SmartContractEvent

smart_contract = SmartContract("6537b4bd100e514119e3a7ab49d520d20ef2c2a4")

@smart_contract.on_all
def handle_sc_event(event):
    print("SmartContract Runtime.Notify event:", event)

    # Runtime.Notifyイベントであるか確認する
    if event.event_type == SmartContractEvent.RUNTIME_NOTIFY:
        # 空のペイロードリストであれば終了する
        if not len(event.event_payload):
            return

        # 最初のペイロードアイテムをデコードして出力する
        print("- payload part 1:", event.event_payload[0].decode("utf-8"))
```
