# Runtime Class

Provides a set of methods during smart contract execution.

Namespace：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly：Neo.SmartContract.Framework

## Syntax

```c#
public static class Runtime
```

## Attributes

| Name                          | Description                                                  |
| ----------------------------- | ------------------------------------------------------------ |
| [Time](Runtime/Time.md)       | Gets the time stamp of the current block                     |
| [Trigger](Runtime/Trigger.md) | Gets the trigger type for the smart contract (verification contract or application contract). |

## Method

| Name                                            | Description                                                  |
| ----------------------------------------------- | ------------------------------------------------------------ |
| [CheckWitness(byte[])](Runtime/CheckWitness.md) | Verifies that the transactions / block of the calling contract has validated the required script hashes. |
| [Log(string)](Runtime/Log.md)                   | Sends a log message to the client executing the smart contract. |
| [Notify(params object[])](Runtime/Notify.md)    | Sends a notification to the client executing the smart contract. |


# Constructor

The Runtime class is a static class and does not require a constructor.