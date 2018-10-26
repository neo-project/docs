# 与智能合约交互

neo-python 的一个常见用例是与智能合约进行交互。典型的智能合约事件包括 `Runtime.Notify`, `Runtime.Log`, 执行成功或失败，以及 `Storage.GET/PUT/DELETE`。

## 事件类型

以下列出了当前 NEO-Python 可以处理的智能合约事件类型：

```python
RUNTIME_NOTIFY = "SmartContract.Runtime.Notify"
RUNTIME_LOG = "SmartContract.Runtime.Log"

EXECUTION = "SmartContract.Execution.*"
EXECUTION_INVOKE = "SmartContract.Execution.Invoke"
EXECUTION_SUCCESS = "SmartContract.Execution.Success"
EXECUTION_FAIL = "SmartContract.Execution.Fail"

VERIFICATION = "SmartContract.Verification.*"
VERIFICATION_SUCCESS = "SmartContract.Verification.Success"
VERIFICATION_FAIL = "SmartContract.Verification.Fail"

STORAGE = "SmartContract.Storage.*"
STORAGE_GET = "SmartContract.Storage.Get"
STORAGE_PUT = "SmartContract.Storage.Put"
STORAGE_DELETE = "SmartContract.Storage.Delete"

CONTRACT = "SmartContract.Contract.*"
CONTRACT_CREATED = "SmartContract.Contract.Create"
CONTRACT_MIGRATED = "SmartContract.Contract.Migrate"
CONTRACT_DESTROY = "SmartContract.Contract.Destroy"
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

开发人员可以使用`neo.contrib.smartcontract.SmartContract` 轻松订阅这些事件。以下是一个使用散列`6537b4bd100e514119e3a7ab49d520d20ef2c2a4`监听 `Runtime.Notify`智能合约事件的示例：

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

## Prompt 中的智能合约交互

`neo-python` 最令人欣喜的功能之一是能够在 NEO 平台上快速构建、测试、导入以及调用智能合约。本节将提供在 Prompt 里操作智能合约的基本指南。

### 创建合约

首先，你需要在 prompt 里创建一个智能合约。该方法使用 neo-boa 编译器编译智能合约并将其保存为 .avm 格式。

在 prompt 里创建或导入智能合约时，最好使用相对路径 （相对于 neo-python 安装目录），尽管绝对路径可能也有效。

以下是一个示例： sample1.py

```
def Main():
  print("Hello World")
  return True
neo> build docs/source/example/sample1.py
Saved output to docs/source/example/sample1.avm
```

以上命令只是简单地编译文件，之后你就可以在 Prompt 或者 NEO-GUI 中导入已编译的 .avm 文件。

### 创建并测试合约

创建并测试命令更加常用，它可以在编译文件后执行和检测结果，只是其语法要复杂些。

查看 ContractParameterType 列表：[ContractParameterTypes](../../data-types.html#contractparametertypes)

该命令语法为:

 `build path/to/file.py test {input_params} {return_type} {needs_storage} {needs_dynamic_invoke} param1 param2 etc..` where `{input_params}` and `{return_type}`

- `{input_params}` ：输入一个或一系列 `ContractParameterType`，例如 `0710` 表示智能合约接收一个字符串和列表。
- `{return_type}`：输入一个 `ContractParameterType`, 例如 `02` 表示智能合约返回一个整数。
- `{needs_storage}` ：输入布尔值 `True` 或 `False` 指示智能合约是否使用 `Storage.Get/Put/Delete` 互操作 API。
- `{needs_dynamic_invoke}` ：输入布尔值`True` 或 `False` ，用于指示智能合约是否调用另一个运行时才知道地址的合约，通常为 `False`。
- `params1 params2 etc...` ：输入你用来测试的参数。

因此要创建并测试 `sample1.py`，命令格式为 `build docs/source/example/sample1.py test '' 01 False False`，其中 `''` 表示不接收参数，`01` 表示返回一个布尔值。在 Prompt 中输入如下：

```
neo> build docs/source/example/sample1.py test '' 01 False false
Saved output to docs/source/example/sample1.avm
please open a wallet to test built contract
neo>
```

现在我们可以打开钱包来测试之前创建的合约了。注意，打开钱包后，你可以使用向上箭头键选择之前输入过的命令。

```python
neo> open wallet Wallets/awesome
[password]> ***********
Opened wallet at Wallets/awesome
neo> build docs/source/example/sample1.py test '' 01 False false
Saved output to docs/source/example/sample1.avm
[I 180302 22:22:58 Invoke:482] Used 0.016 Gas

-----------------------------------------------------------
Calling docs/source/example/sample1.py with arguments []
Test deploy invoke successful
Used total of 11 operations
Result [{'type': 'Boolean', 'value': True}]
Invoke TX gas cost: 0.0001
-------------------------------------------------------------

neo>
```

到此我们就完成了第一个智能合约的创建和测试。如果想要查看该智能合约作为整数时的结果，可以更改 `return_type` ，你会得到如下所示的输出：

```python
neo> build docs/source/example/sample1.py test '' 02 False False
Saved output to docs/source/example/sample1.avm
[I 180302 22:25:09 Invoke:482] Used 0.016 Gas

-----------------------------------------------------------
Calling docs/source/example/sample1.py with arguments []
Test deploy invoke successful
Used total of 11 operations
Result [{'type': 'Integer', 'value': 1}]
Invoke TX gas cost: 0.0001
-------------------------------------------------------------

neo>
```

在上例中你会发现，尽管合约中包含了 `print` 命令，却并没有打印输出任何字符。要解决这个问题，让我们打开智能合约事件并再次运行一遍。

```python
neo>
neo> config sc-events on
Smart contract event logging is now enabled
neo> build docs/source/example/sample1.py test '' 01 False False
Saved output to docs/source/example/sample1.avm
[I 180302 22:56:19 EventHub:71] [test_mode][SmartContract.Contract.Create] [09a129673c61917593cb4b57dce066688f539d15] ['{\n    "version": 0,\n    "code": {\n        "hash": "0x09a129673c61917593cb4b57dce066688f539d15",\n        "script": "54c56b0b48656c6c6f20576f726c64680f4e656f2e52756e74696d652e4c6f67516c7566",\n        "parameters": "",\n        "returntype": 1\n    },\n    "name": "test",\n    "code_version": "test",\n    "author": "test",\n    "email": "test",\n    "description": "test",\n    "properties": {\n        "storage": false,\n        "dynamic_invoke": false\n    }\n}']
[I 180302 22:56:19 EventHub:71] [test_mode][SmartContract.Runtime.Log] [09a129673c61917593cb4b57dce066688f539d15] [b'Hello World']
[I 180302 22:56:19 EventHub:71] [test_mode][SmartContract.Execution.Success] [09a129673c61917593cb4b57dce066688f539d15] [1]
[I 180302 22:56:20 Invoke:482] Used 0.016 Gas

-----------------------------------------------------------
Calling docs/source/example/sample1.py with arguments []
Test deploy invoke successful
Used total of 11 operations
Result [{'type': 'Boolean', 'value': True}]
Invoke TX gas cost: 0.0001
-------------------------------------------------------------

neo>
```

当我们在 prompt 里使用 `config sc-events on `命令打开 SmartContractEvent 日志功能后，再次运行相同的命令会发现这次输出结果中多出了三行。

- **SmartContract.Contract.Create** 是在 VM 中创建了你的智能合约事件的事件
- **SmartContract.Runtime.Log** 是输出 `Hello World` 的事件
- **SmartContract.Execution.Success** 表示智能合约成功执行完成

下面让我们尝试一个复杂点的合约，sample2.py：

```python
def Main(operation, a, b):

    if operation == 'add':
        return a + b

    elif operation == 'sub':
        return a - b

    elif operation == 'mul':
        return a * b

    elif operation == 'div':
        return a / b

    else:
        return -1
```

创建并指定几个参数运行该合约：

```python
neo> build docs/source/example/sample2.py test 070202 02 False False
Saved output to docs/source/example/sample2.avm
[E 180302 22:30:01 ExecutionEngine:825] COULD NOT EXECUTE OP: Invalid list operation b'z' ROLL
[E 180302 22:30:01 ExecutionEngine:826] Invalid list operation
Traceback (most recent call last):
  File "/Users/thomassaunders/Workshop/neo-python/neo/VM/ExecutionEngine.py", line 823, in StepInto
    self.ExecuteOp(op, self.CurrentContext)
  File "/Users/thomassaunders/Workshop/neo-python/neo/VM/ExecutionEngine.py", line 276, in ExecuteOp
    estack.PushT(estack.Remove(n))
  File "/Users/thomassaunders/Workshop/neo-python/neo/VM/RandomAccessStack.py", line 57, in Remove
    raise Exception("Invalid list operation")
Exception: Invalid list operation
[I 180302 22:30:01 InteropService:93] Trying to get big integer Array: ['None', 'None', 'None', 'None', 'None', 'None', 'None', 'None', 'None', 'None', 'None', 'None', 'None', 'None']
```

出现以上结果的原因是，我们测试的合约要求提供更多的参数。如果你在创建并测试合约时遇到相似的错误信息，很有可能是相同的原因。让我们输入一些参数再尝试一次：

```python
neo> build docs/source/example/sample2.py test 070202 02 False False add 1 2
Saved output to docs/source/example/sample2.avm
[I 180302 22:32:06 Invoke:482] Used 0.033 Gas

-----------------------------------------------------------
Calling docs/source/example/sample2.py with arguments ['add', '1', '2']
Test deploy invoke successful
Used total of 39 operations
Result [{'type': 'Integer', 'value': 3}]
Invoke TX gas cost: 0.0001
-------------------------------------------------------------

neo>
neo> build docs/source/example/sample2.py test 070202 02 False False mul -1 20000
Saved output to docs/source/example/sample2.avm
[I 180302 22:33:36 Invoke:482] Used 0.041 Gas

-----------------------------------------------------------
Calling docs/source/example/sample2.py with arguments ['mul', '-1', '20000']
Test deploy invoke successful
Used total of 53 operations
Result [{'type': 'Integer', 'value': -20000}]
Invoke TX gas cost: 0.0001
-------------------------------------------------------------

neo>
```

这次好多了。接下来让我们做些更有用的尝试，我们将做一个简单的地址余额跟踪器。

```python
from boa.interop.Neo.Storage import Get,Put,Delete,GetContext

def Main(operation, addr, value):


    if not is_valid_addr(addr):
        return False

    ctx = GetContext()

    if operation == 'add':
        balance = Get(ctx, addr)
        new_balance = balance + value
        Put(ctx, addr, new_balance)
        return new_balance

    elif operation == 'remove':
        balance = Get(ctx, addr)
        Put(ctx, addr, balance - value)
        return balance - value

    elif operation == 'balance':
        return Get(ctx, addr)

    return False

def is_valid_addr(addr):

    if len(addr) == 20:
        return True
    return False
```

我们将使用 `add` 进行一个测试，给钱包里的一个地址添加一些值。你会注意到，当你在钱包里输入任意地址时会自动完成输入，这可能会产生误导。当通过 `prompt` 将地址发送到 SC 时，它会自动转换为 ByteArray 以便使用。 因此方法签名看起来像 070502 或 **String**，**ByteArray**，**Integer**。

我们使用 `True` 来表示使用智能合约的 `Storage` API。

```python
neo> build docs/source/example/sample3.py test 070502 02 True False add AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy 3
Saved output to docs/source/example/sample3.avm
[I 180302 23:04:33 Invoke:482] Used 1.174 Gas

-----------------------------------------------------------
Calling docs/source/example/sample3.py with arguments ['add', 'AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy', '3']
Test deploy invoke successful
Used total of 106 operations
Result [{'type': 'Integer', 'value': 3}]
Invoke TX gas cost: 0.0001
-------------------------------------------------------------

neo>
```

再次调用，将看到我们的测试调用保留了存储库中的值。

```python
neo> build docs/source/example/sample3.py test 070502 02 True False add AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy 3
Saved output to docs/source/example/sample3.avm
[I 180302 23:04:33 Invoke:482] Used 1.174 Gas

-----------------------------------------------------------
Calling docs/source/example/sample3.py with arguments ['add', 'AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy', '3']
Test deploy invoke successful
Used total of 106 operations
Result [{'type': 'Integer', 'value': 6}]
Invoke TX gas cost: 0.0001
-------------------------------------------------------------

neo>
```

现在除去一些值：

```python
neo> build docs/source/example/sample3.py test 070502 02 True False remove AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy 2
Saved output to docs/source/example/sample3.avm
[I 180302 23:09:21 Invoke:482] Used 1.176 Gas

-----------------------------------------------------------
Calling docs/source/example/sample3.py with arguments ['remove', 'AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy', '2']
Test deploy invoke successful
Used total of 109 operations
Result [{'type': 'Integer', 'value': 4}]
Invoke TX gas cost: 0.0001
-------------------------------------------------------------

neo>
```

你也可以为地址传入一个 ByteArray 对象，并测试是否 `is_valid_addr` 在任何事情发生前返回 False，这会被解析为 0：

```python
neo> build docs/source/example/sample3.py test 070502 02 True False add bytearray(b'\x00\x01\x02\x03') 4
Saved output to docs/source/example/sample3.avm
[I 180302 23:12:43 Invoke:482] Used 0.041 Gas

-----------------------------------------------------------
Calling docs/source/example/sample3.py with arguments ['add', "bytearray(b'\\x00\\x01\\x02\\x03')", '4']
Test deploy invoke successful
Used total of 52 operations
Result [{'type': 'Integer', 'value': 0}]
Invoke TX gas cost: 0.0001
-------------------------------------------------------------

neo>
```

请注意，以可读格式 ( *AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy* ) 发送地址与发送地址的脚本哈希是一样的。我们将通过获取余额进行尝试。由于智能合约期望第三个参数，我在最后添加了一个额外的 0 作为最后一个参数：

```python
neo> build docs/source/example/sample3.py test 070502 02 True False balance bytearray(b'\x03\x19\xe0)\xb9%\x85w\x90\xe4\x17\x85\xbe\x9c\xce\xc6\xca\xb1\x98\x96') 0
Saved output to docs/source/example/sample3.avm
[I 180302 23:16:23 Invoke:482] Used 0.162 Gas

-----------------------------------------------------------
Calling docs/source/example/sample3.py with arguments ['balance', "bytearray(b'\\x03\\x19\\xe0)\\xb9%\\x85w\\x90\\xe4\\x17\\x85\\xbe\\x9c\\xce\\xc6\\xca\\xb1\\x98\\x96')", '0']
Test deploy invoke successful
Used total of 87 operations
Result [{'type': 'Integer', 'value': 4}]
Invoke TX gas cost: 0.0001
-------------------------------------------------------------

neo>
```

### 导入智能合约

导入智能合约有点类似 `build .. test` 命令，但你不需要发送任何参数。命令格式为：

`import contract path/to/sample2.avm {input_params} {return_type} {needs_storage} {needs_dynamic_invoke}`

运行该命令后，如果一切正常系统会提示你添加合约相关的元数据。完成后你就可以选择在网络中实际部署将该合约。请注意部署合约将花费 GAS。

```python
neo>
neo> import contract docs/source/example/sample2.avm 070202 02 False False
Please fill out the following contract details:
[Contract Name] > Sample Calculator
[Contract Version] > .01
[Contract Author] > Thomas Saunders
[Contract Email] > tom@cityofzion.io
[Contract Description] > A test calculator contract
Creating smart contract....
               Name: A test calculator contract
            Version: .01
             Author: tom@cityofzion.io
              Email: tom@cityofzion.io
        Description: A test calculator contract
      Needs Storage: False
Needs Dynamic Invoke: False
{
  "hash": "0x86d58778c8d29e03182f38369f0d97782d303cc0",
  "script": "5ec56b6a00527ac46a51527ac46a52527ac46a00c3036164649c640d006a51c36a52c3936c7566616a00c3037375629c640d006a51c36a52c3946c7566616a00c3036d756c9c640d006a51c36a52c3956c7566616a00c3036469769c640d006a51c36a52c3966c7566614f6c7566006c7566",
  "parameters": "070202",
  "returntype": "02"
}
Used 100.0 Gas

-------------------------------------------------------------------------------------------------------------------------------------
Test deploy invoke successful
Total operations executed: 11
Results:
[<neo.Core.State.ContractState.ContractState object at 0x11435d2e8>]
Deploy Invoke TX GAS cost: 90.0
Deploy Invoke TX Fee: 0.0
-------------------------------------------------------------------------------------------------------------------------------------

Enter your password to continue and deploy this contract
[password]>
```

从这里开始，如果你确定要花费 GAS 来部署合约，输入密码：

```python
Enter your password to continue and deploy this contract
[password]> ***********
[I 180302 23:46:23 Transaction:611] Verifying transaction: b'f8ad261d28bf4bc5544e47f9bc3fff85f85ee674f14162dac81dd56bf73cf0a3'
Relayed Tx: f8ad261d28bf4bc5544e47f9bc3fff85f85ee674f14162dac81dd56bf73cf0a3
neo>
```

现在你已将合约部署到网络。 如果一切顺利，将很快部署。 要确定何时部署完成，在区块链中搜索 txid 或合约哈希。

```python
neo> tx f8ad261d28bf4bc5544e47f9bc3fff85f85ee674f14162dac81dd56bf73cf0a3
{
  "txid": "0xf8ad261d28bf4bc5544e47f9bc3fff85f85ee674f14162dac81dd56bf73cf0a3",
  "type": "InvocationTransaction",
  "version": 1,
  "attributes": [],
  [ MORE Output Omitted ]

neo> contract 0x86d58778c8d29e03182f38369f0d97782d303cc0
{
    "version": 0,
    "code": {
        "hash": "0x86d58778c8d29e03182f38369f0d97782d303cc0",
        "script": "5ec56b6a00527ac46a51527ac46a52527ac46a00c3036164649c640d006a51c36a52c3936c7566616a00c3037375629c640d006a51c36a52c3946c7566616a00c3036d756c9c640d006a51c36a52c3956c7566616a00c3036469769c640d006a51c36a52c3966c7566614f6c7566006c7566",
        "parameters": "070202",
        "returntype": 2
    },
    "name": "A test calculator contract",
    "code_version": ".01",
    "author": "tom@cityofzion.io",
    "email": "tom@cityofzion.io",
    "description": "A test calculator contract",
    "properties": {
        "storage": false,
        "dynamic_invoke": false
    }
}

neo>
```

现在你已经在网络上部署了合同，可以使用真正的 InvocationTransactions 与它进行交互。

### 测试调用合约

一旦部署了合约，你就无法再像使用 `build .. test` 命令那样进行交互，更改和构建，但最好是使用 `testinvoke` 来确定链上的工作。

现在我们已经部署了*Calculator Contract*，只要知道它的脚本哈希，就可以使用 `testinvoke` 命令与它进行交互。命令格式是 `testinvoke {contract_hash} param1 param2 .. `

```python
neo> testinvoke 0x86d58778c8d29e03182f38369f0d97782d303cc0 add 1 2
Used 0.033 Gas

-------------------------------------------------------------------------------------------------------------------------------------
Test invoke successful
Total operations: 39
Results ['Integer: 3 ']
Invoke TX GAS cost: 0.0
Invoke TX fee: 0.0001
-------------------------------------------------------------------------------------------------------------------------------------

Enter your password to continue and invoke on the network

[password]>
```

这个调用只在本地完成，只有在你输入密码后才能运行。如果你不希望在网络中调用，只需输入错误密码即可取消。这里我们取消调用，然后设置 `config sc-events on` 以确切地查看测试调用时发生的情况，然后将其发送到网络：

```python
Enter your password to continue and invoke on the network

[password]> **
Incorrect password
neo>
neo> config sc-events on
Smart contract event logging is now enabled
neo>
neo> testinvoke 0x86d58778c8d29e03182f38369f0d97782d303cc0 add 1 2
[I 180303 07:38:58 EventHub:71] [test_mode][SmartContract.Execution.Success] [86d58778c8d29e03182f38369f0d97782d303cc0] [3]
Used 0.033 Gas

-------------------------------------------------------------------------------------------------------------------------------------
Test invoke successful
Total operations: 39
Results ['Integer: 3 ']
Invoke TX GAS cost: 0.0
Invoke TX fee: 0.0001
-------------------------------------------------------------------------------------------------------------------------------------

Enter your password to continue and invoke on the network

[password]> ***********
[I 180303 07:39:04 Transaction:611] Verifying transaction: b'e0f4251a83f7081fb6fd94ce884d12b0bb597c1c1b3f1a89f07db68e114f4fa2'
[I 180303 07:39:04 EventHub:89] [SmartContract.Verification.Success][433121] [4c896601a99d58e22c32dcadd24974ca24c10587] [tx e0f4251a83f7081fb6fd94ce884d12b0bb597c1c1b3f1a89f07db68e114f4fa2] [True]
Relayed Tx: e0f4251a83f7081fb6fd94ce884d12b0bb597c1c1b3f1a89f07db68e114f4fa2
neo>
neo> [I 180303 07:39:31 EventHub:89] [SmartContract.Execution.Success][433122] [86d58778c8d29e03182f38369f0d97782d303cc0] [tx e0f4251a83f7081fb6fd94ce884d12b0bb597c1c1b3f1a89f07db68e114f4fa2] [3]
neo>
```

在这里请注意以下几点：

1. 当使用 `sc-events on` 测试调用时，将看到 *SmartContract.Execution.Success* 事件，并且将看到该事件显示已在 `test_mode` 完成测试。
2. 现在你将看到 SmartContract.Verification.Success 事件。 这说明 TX 已正确签名并将通过验证，因为它被传递到其他节点并最终将达成一致。
3. 将 InvocationTransaction 发送到网络后，你将获得一个TX ID，可以用来查找调用。
4. 在网络处理完 TX 之后，本地 VM 会运行你的调用，这次不在 `test_mode` 中，你将再次看到SmartContract.Execution.Success 事件。