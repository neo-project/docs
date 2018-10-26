# Application vs. Verification

现在，你已经完成了合约的构建、测试和测试调用，你可能会问，这个验证步骤是什么，如何与之程序化的交互？让我们从之前一个跟踪余额的例子开始，限制仅有一个所有者地址可以对其执行操作。以下是智能合约代码：

```python
from boa.interop.Neo.Runtime import GetTrigger,CheckWitness
from boa.interop.Neo.Storage import Get,Put,Delete,GetContext
from boa.interop.Neo.TriggerType import Application, Verification

OWNER = b'\x03\x19\xe0)\xb9%\x85w\x90\xe4\x17\x85\xbe\x9c\xce\xc6\xca\xb1\x98\x96'

def Main(operation, addr, value):

    print("Running Sample v4")
    trigger = GetTrigger()

    # This determines that the SC is runnning in Verification mode
    # This determines whether the TX will be relayed to the rest of the network
    # The `Verification` portion of SC is *read-only*, so calls to `Storage.Put` will fail.
    # You can, however, use `Storage.Get`
    if trigger == Verification():

        print("Running Verification!")

        # This routine is: if the invoker ( or the Address that signed the contract ) is not OWNER,
        # Then we return False, and the TX will not be relayed to the network
        # Otherwise, we know the owner address signed the TX and return True
        is_owner = CheckWitness(OWNER)

        if is_owner:
            print("Is Owner!")
            return True

        print("Not Owner")

        return False

    elif trigger == Application():

        print("Running Application!")

          if not is_valid_addr(addr):
              print("Not Valid Address")
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

    return False


def is_valid_addr(addr):

  if len(addr) == 20:
      return True
  return False
```

`OWNER` 就是我们之前用过的ByteArray, 是我们使用的钱包里的地址。上例将使用`boa.interop.Neo.Runtime.CheckWitness` 方法来验证签名 InvocationTransaction 的钱包是否与  `OWNER` 的一样。首先，构建合约并测试其是否正常执行。我们将打开 `sc-events`以便准确地看到执行过程。

```python
neo>
neo> build docs/source/neo/example/sample4.py test 070202 02 True False add AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy 7
Saved output to docs/source/neo/example/sample4.avm
[I 180303 08:25:12 EventHub:71] [test_mode][SmartContract.Contract.Create] [562d6c29209dc96432c6868621fe489cedd05222] ['{\n    "version": 0,\n    "code": {\n        "hash": "0x562d6c29209dc96432c6868621fe489cedd05222",\n        "script": "0122c56b6a00527ac46a51527ac46a52527ac4140319e029b925857790e41785be9ccec6cab198966a53527ac41152756e6e696e672053616d706c65207634680f4e656f2e52756e74696d652e4c6f6768164e656f2e52756e74696d652e47657454726967676572616a54527ac46a54c301009c6492001552756e6e696e6720566572696669636174696f6e21680f4e656f2e52756e74696d652e4c6f676a53c368184e656f2e52756e74696d652e436865636b5769746e657373616a55527ac46a55c3642200094973204f776e657221680f4e656f2e52756e74696d652e4c6f67516c756661094e6f74204f776e6572680f4e656f2e52756e74696d652e4c6f67006c7566616a54c301109c6454011452756e6e696e67204170706c69636174696f6e21680f4e656f2e52756e74696d652e4c6f676a51c3652d01632a00114e6f742056616c69642041646472657373680f4e656f2e52756e74696d652e4c6f67006c75666168164e656f2e53746f726167652e476574436f6e74657874616a56527ac46a00c3036164649c6450006a56c36a51c37c680f4e656f2e53746f726167652e476574616a57527ac46a57c36a52c3936a58527ac46a56c36a51c36a58c35272680f4e656f2e53746f726167652e507574616a58c36c7566616a00c30672656d6f76659c644c006a56c36a51c37c680f4e656f2e53746f726167652e476574616a57527ac46a56c36a51c36a57c36a52c3945272680f4e656f2e53746f726167652e507574616a57c36a52c3946c7566616a00c30762616c616e63659c641f006a56c36a51c37c680f4e656f2e53746f726167652e476574616c756661006c756656c56b6a00527ac46a00c3c001149c640700516c756661006c7566",\n        "parameters": "070202",\n        "returntype": 2\n    },\n    "name": "test",\n    "code_version": "test",\n    "author": "test",\n    "email": "test",\n    "description": "test",\n    "properties": {\n        "storage": true,\n        "dynamic_invoke": false\n    }\n}']
[I 180303 08:25:12 EventHub:71] [test_mode][SmartContract.Runtime.Log] [562d6c29209dc96432c6868621fe489cedd05222] [b'Running Sample v4']
[I 180303 08:25:12 EventHub:71] [test_mode][SmartContract.Runtime.Log] [562d6c29209dc96432c6868621fe489cedd05222] [b'Running Application!']
[I 180303 08:25:12 EventHub:71] [test_mode][SmartContract.Storage.Get] [562d6c29209dc96432c6868621fe489cedd05222] ['AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy -> 0']
[I 180303 08:25:12 EventHub:71] [test_mode][SmartContract.Storage.Put] [562d6c29209dc96432c6868621fe489cedd05222] ['AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy -> 7']
[I 180303 08:25:12 EventHub:71] [test_mode][SmartContract.Execution.Success] [562d6c29209dc96432c6868621fe489cedd05222] [7]
[I 180303 08:25:12 Invoke:482] Used 1.191 Gas

-----------------------------------------------------------
Calling docs/source/neo/example/sample4.py with arguments ['add', 'AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy', '7']
Test deploy invoke successful
Used total of 136 operations
Result [{'type': 'Integer', 'value': 7}]
Invoke TX gas cost: 0.0001
-------------------------------------------------------------

neo>
```

到这里执行过程跟之前差不多。我们添加了一些新的 print 语句，通过这些语句能看到智能合约的 `Verification` 部分从未执行。另外，合约中的 `SmartContract.Storage.\*` 事件对调试非常有用。目前，为了与智能合约的  `Verification` 阶段交互，你需要部署并使用 `testinvoke`。假设你已经构建并导入合约，将得到如下结果：

```python
neo> contract 2e80ee491a0a54c9bbb0f791672050f9ab367767
{
    "version": 0,
    "code": {
        "hash": "0x2e80ee491a0a54c9bbb0f791672050f9ab367767",
        "script": "0123c56b6a00527ac46a51527ac46a52527ac4140319e029b925857790e41785be9ccec6cab198966a53527ac41152756e6e696e672053616d706c65207634680f4e656f2e52756e74696d652e4c6f6768164e656f2e52756e74696d652e47657454726967676572616a54527ac46a54c3680f4e656f2e52756e74696d652e4c6f676a54c301009c6492001552756e6e696e6720566572696669636174696f6e21680f4e656f2e52756e74696d652e4c6f676a53c368184e656f2e52756e74696d652e436865636b5769746e657373616a55527ac46a55c3642200094973204f776e657221680f4e656f2e52756e74696d652e4c6f67516c756661094e6f74204f776e6572680f4e656f2e52756e74696d652e4c6f67006c7566616a54c301109c6454011452756e6e696e67204170706c69636174696f6e21680f4e656f2e52756e74696d652e4c6f676a51c3652d01632a00114e6f742056616c69642041646472657373680f4e656f2e52756e74696d652e4c6f67006c75666168164e656f2e53746f726167652e476574436f6e74657874616a56527ac46a00c3036164649c6450006a56c36a51c37c680f4e656f2e53746f726167652e476574616a57527ac46a57c36a52c3936a58527ac46a56c36a51c36a58c35272680f4e656f2e53746f726167652e507574616a58c36c7566616a00c30672656d6f76659c644c006a56c36a51c37c680f4e656f2e53746f726167652e476574616a57527ac46a56c36a51c36a57c36a52c3945272680f4e656f2e53746f726167652e507574616a57c36a52c3946c7566616a00c30762616c616e63659c641f006a56c36a51c37c680f4e656f2e53746f726167652e476574616c756661006c756656c56b6a00527ac46a00c3c001149c640700516c756661006c7566",
        "parameters": "070202",
        "returntype": 2
    },
    "name": "test",
    "code_version": "test",
    "author": "test",
    "email": "test",
    "description": "test",
    "properties": {
        "storage": true,
        "dynamic_invoke": false
    }
}

neo>
```

再次测试调用一遍。

```python
neo> testinvoke 0x2e80ee491a0a54c9bbb0f791672050f9ab367767 add AMUUgxnLhGxNSATinNp8gKmndqM1BxDZHR 42
[I 180303 09:08:14 EventHub:71] [test_mode][SmartContract.Runtime.Log] [2e80ee491a0a54c9bbb0f791672050f9ab367767] [b'Running Sample v4']
[I 180303 09:08:14 EventHub:71] [test_mode][SmartContract.Runtime.Log] [2e80ee491a0a54c9bbb0f791672050f9ab367767] [b'\x10']
[I 180303 09:08:14 EventHub:71] [test_mode][SmartContract.Runtime.Log] [2e80ee491a0a54c9bbb0f791672050f9ab367767] [b'Running Application!']
[I 180303 09:08:14 EventHub:71] [test_mode][SmartContract.Storage.Get] [2e80ee491a0a54c9bbb0f791672050f9ab367767] ['AMUUgxnLhGxNSATinNp8gKmndqM1BxDZHR -> 0']
[I 180303 09:08:14 EventHub:71] [test_mode][SmartContract.Storage.Put] [2e80ee491a0a54c9bbb0f791672050f9ab367767] ['AMUUgxnLhGxNSATinNp8gKmndqM1BxDZHR -> 42']
[I 180303 09:08:14 EventHub:71] [test_mode][SmartContract.Execution.Success] [2e80ee491a0a54c9bbb0f791672050f9ab367767] [42]
Used 1.194 Gas

-------------------------------------------------------------------------------------------------------------------------------------
Test invoke successful
Total operations: 140
Results ['Integer: 42 ']
Invoke TX GAS cost: 0.0
Invoke TX fee: 0.0001
-------------------------------------------------------------------------------------------------------------------------------------

Enter your password to continue and invoke on the network

[password]>
```

这里还是没有看到任何验证事件。一旦我们输入密码将其转发到网络，将看到如下结果：

```python
[password]> ***********
[I 180303 08:36:52 Transaction:611] Verifying transaction: b'0fd755e847a5ce54f9894c0c0bbf9303730ac28d8aeacdaddb2f912a2a3fcd40'
[I 180303 08:35:38 EventHub:71] [test_mode][SmartContract.Runtime.Log] [562d6c29209dc96432c6868621fe489cedd05222] [b'Running Sample v4']
[I 180303 08:35:38 EventHub:71] [test_mode][SmartContract.Runtime.Log] [562d6c29209dc96432c6868621fe489cedd05222] [b'Running Verification!']
[I 180303 08:35:38 EventHub:71] [test_mode][SmartContract.Runtime.Log] [562d6c29209dc96432c6868621fe489cedd05222] [b'Is Owner!']
[I 180303 08:36:52 EventHub:89] [SmartContract.Verification.Success][433331] [f64d628af19f53a6b8226a44c93182eff6fcb222] [tx 0fd755e847a5ce54f9894c0c0bbf9303730ac28d8aeacdaddb2f912a2a3fcd40] [True]
Relayed Tx: 0fd755e847a5ce54f9894c0c0bbf9303730ac28d8aeacdaddb2f912a2a3fcd40
neo>
neo>
neo>
neo> [I 180303 08:37:29 EventHub:89] [SmartContract.Runtime.Log][433333] [562d6c29209dc96432c6868621fe489cedd05222] [tx 0fd755e847a5ce54f9894c0c0bbf9303730ac28d8aeacdaddb2f912a2a3fcd40] [b'Running Sample v4']
[I 180303 08:37:29 EventHub:89] [SmartContract.Runtime.Log][433333] [562d6c29209dc96432c6868621fe489cedd05222] [tx 0fd755e847a5ce54f9894c0c0bbf9303730ac28d8aeacdaddb2f912a2a3fcd40] [b'Running Application!']
[I 180303 08:37:29 EventHub:89] [SmartContract.Storage.Get][433333] [562d6c29209dc96432c6868621fe489cedd05222] [tx 0fd755e847a5ce54f9894c0c0bbf9303730ac28d8aeacdaddb2f912a2a3fcd40] ['AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy -> 0']
[I 180303 08:37:29 EventHub:89] [SmartContract.Storage.Put][433333] [562d6c29209dc96432c6868621fe489cedd05222] [tx 0fd755e847a5ce54f9894c0c0bbf9303730ac28d8aeacdaddb2f912a2a3fcd40] ['AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy -> 17']
[I 180303 08:37:29 EventHub:89] [SmartContract.Execution.Success][433333] [562d6c29209dc96432c6868621fe489cedd05222] [tx 0fd755e847a5ce54f9894c0c0bbf9303730ac28d8aeacdaddb2f912a2a3fcd40] [17]
```

和预期的一样。现在我们将打开不同的钱包并尝试调用相同的东西。