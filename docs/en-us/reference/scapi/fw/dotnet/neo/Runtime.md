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
| [Trigger](Runtime/Trigger.md) | Gets the trigger type for the smart contract (verification contract or application contract). |
| Platform                      | Gets information of the platform on which the smart contract is currently executed |
| Time                          | Gets the timestamp of the current block                      |
| InvocationCounter             | Gets the call number of the current contract                 |

## Method

| Name                                                         | Description                                                  |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [GetNotifications(byte[] hash = null)](Runtime/GetNotifications.md) | Gets all notifications of the execution of a contract        |
| [CheckWitness(byte[])](Runtime/CheckWitness.md)              | Verifies that the transactions / block of the calling contract has validated the required script hashes. |
| [Log(string)](Runtime/Log.md)                                | Sends a log message to the client executing the smart contract. |
| [Notify(params object[])](Runtime/Notify.md)                 | Sends a notification to the client executing the smart contract. |


## Constructor

The Runtime class is a static class and does not require a constructor.