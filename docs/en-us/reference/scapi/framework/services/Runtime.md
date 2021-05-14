# Runtime Class

Provides a set of methods during smart contract execution.

Namespace：[Neo.SmartContract.Framework.Services](../services.md)

Assembly：Neo.SmartContract.Framework

## Syntax

```c#
public static class Runtime
```

## Attributes

| Name                          | Description                                                  |
| ----------------------------- | ------------------------------------------------------------ |
| [Trigger](Runtime/Trigger.md) | Gets the trigger type for the smart contract (verification contract or application contract). |
| Platform                      | Gets information of the platform on which the smart contract is currently executed |
| ScriptContainer               | Gets the current script container                            |
| ExecutingScriptHash           | Gets the script hash of the current context                  |
| CallingScriptHash             | Gets the script hash of the calling contract                 |
| EntryScriptHash               | Gets the script hash of the entry context                    |
| Time                          | Gets the timestamp of the current block                      |
| InvocationCounter             | Gets the call number of the current contract                 |
| GasLeft                       | Gets the left GAS of the fee of current transaction          |

## Method

| Name                                                         | Description                                                  |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [GetNotifications(UInt160 hash = null)](Runtime/GetNotifications.md) | Gets all notifications of the execution of a contract        |
| [Log(string)](Runtime/Log.md)                                | Sends a log message to the client executing the smart contract. |
| [CheckWitness()](Runtime/CheckWitness.md)                    | Determines whether the specified account has witnessed the current transaction |
| BurnGas                                                      | Burning GAS to benefit the Neo ecosystem                     |

## Constructor

The Runtime class is a static class and does not require a constructor.