# ExecutionEngine.ScriptContainer Property

Returns the script container of the current contract (The initial trigger). This is usually a transaction.

Namespace: [Neo.SmartContract.Framework.Services.System](../../System.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern IScriptContainer ScriptContainer {get;}
```

Attribute value: ScriptContainer as a IScriptContainer. If you know the trigger is a Transaction, you can cast this into a [Transaction](../../neo/Transaction.md).



[Back](../ExecutionEngine.md)
