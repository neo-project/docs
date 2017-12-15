# 与智能合约交互

实现 neo-python 的常见用例是与智能合约进行交互。典型的智能合约事件包括 `Runtime.Notify`, `Runtime.Log`, 执行成功或失败，以及 `Storage.GET/PUT/DELETE`。

## 事件类型

以下列出了当前可以用 neo-python 处理的智能合约事件类型：

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

当这些事件发生在接收区块时，由`neo.EventHub`调度一个 `SmartContractEvent`实例。 

## SmartContractEvent

事件处理程序总是收到参数 neo.EventHub.SmartContractEvent 的一个实例，其包含有关当前事件的所有信息。SmartContractEvent 具有以下属性：

| 属性                  | 数据类型     | 描述                                       |
| ------------------- | -------- | ---------------------------------------- |
| `event_type`        | str      | `neo.EventHub.SmartContractEvent`中的一个事件类型 |
| `contract_hash`     | UInt160  | 合约散列值                                    |
| `tx_hash`           | UInt256  | 事务散列值                                    |
| `block_number`      | int      | 收到此事件的区块号                                |
| `event_payload`     | object[] | 对象列表，取决于智能合约发出的数据类型（例如，使用Runtime.Notify）。 |
| `execution_success` | bool     | 方法调用是否成功                                 |
| `test_mode`         | bool     | 这个事件是否由本地TestInvoke调度，而不是从区块链接收          |

## neo.contrib.smartcontract.SmartContract

Developers can easily subscribe to these events by using 开发人员可以使用`neo.contrib.smartcontract.SmartContract`轻松订阅这些事件。以下是一个使用散列`6537b4bd100e514119e3a7ab49d520d20ef2c2a4`监听 `Runtime.Notify`智能合约事件的示例：

```python
from neo.contrib.smartcontract import SmartContract

smart_contract = SmartContract("6537b4bd100e514119e3a7ab49d520d20ef2c2a4")

@smart_contract.on_notify
def sc_notify(event):
    print("SmartContract Runtime.Notify event:", event)

    # Make sure that the event payload list has at least one element.
    if not len(event.event_payload):
        return

    # The event payload list has at least one element. As developer of the smart contract
    # you should know what data-type is in the bytes, and how to decode it. In this example,
    # it's just a string, so we decode it with utf-8:
    print("- payload part 1:", event.event_payload[0].decode("utf-8"))

```

目前可用的装饰器如下：

| 装饰器             | 智能合约事件               |
| --------------- | -------------------- |
| `@on_any`       | 所有事件                 |
| `@on_notify`    | `Runtime.Notify`     |
| `@on_log`       | `Runtime.Log`        |
| `@on_storage`   | 存储 PUT, GET 和 DELETE |
| `@on_execution` | 方法调用，成功或失败           |

以下示例显示如何监听所有事件并区分代码中的事件类型：

```python
from neo.contrib.smartcontract import SmartContract
from neo.EventHub import SmartContractEvent

smart_contract = SmartContract("6537b4bd100e514119e3a7ab49d520d20ef2c2a4")

@smart_contract.on_all
def handle_sc_event(event):
    print("SmartContract Runtime.Notify event:", event)

    # Check if it is a Runtime.Notify event
    if event.event_type == SmartContractEvent.RUNTIME_NOTIFY:
        # Exit if an empty payload list
        if not len(event.event_payload):
            return

        # Decode the first payload item and print it
        print("- payload part 1:", event.event_payload[0].decode("utf-8"))
```