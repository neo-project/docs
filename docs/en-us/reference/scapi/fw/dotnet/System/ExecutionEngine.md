# ExecutionEngine class

The execution engine of the virtual machine, allowing access to the caller and execution container.

Namespace: [Neo.SmartContract.Framework.Services.System](../System.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static ExecutionEngine
```

## Attributes

| Name | description |
| ---------------------------------------- | -------------------------- |
| [CallingScriptHash](ExecutionEngine/CallingScriptHash.md) | Returns the scripthash of the caller of the contract           |
| [EntryScriptHash](ExecutionEngine/EntryScriptHash.md) | Returns the scripthash of the entry points of the contract(in the contract invocation chain) |
| [ExecutingScriptHash](ExecutionEngine/ExecutingScriptHash.md) | Returns the scripthash of the executing contract             |
| [ScriptContainer](ExecutionEngine/ScriptContainer.md) | Returns the script container of the current contract (The initial trigger)      |

## Constructor

ExecutionEngine is a static class. A constructor is not required.  