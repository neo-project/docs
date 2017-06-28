# ExecutionEngine.ScriptContainer property

The script container (the first trigger) of the smart contract is usually a transaction, and if the contract is triggered by the contract account transfer, the ScriptContainer is the transfer transaction if the contract is triggered by Invocation Transaction Then the ScriptContainer is the Invocation Transaction.

Namespace: [AntShares.SmartContract.Framework.Services.System](../../System.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public extern AntShares.SmartContract.Framework.IScriptContainer ScriptContainer {get;}
```

Attribute value: script container, IScriptContainer type, if you know that it is a transaction triggered, you can turn it into [Transaction](../../AntShares/Transaction.md) type.



[Return to superior](../ExecutionEngine.md)
