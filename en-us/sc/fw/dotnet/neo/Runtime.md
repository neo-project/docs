# Runtime Class

Provides a set of methods during smart contract execution.

Namespace：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly：Neo.SmartContract.Framework

## Syntax

```c#
public static class Runtime
```

## Attributes

|                                                        | Name                          | Description                                                  |
| ------------------------------------------------------ | ----------------------------- | ------------------------------------------------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Trigger](Runtime/Trigger.md) | Gets the trigger type for the smart contract (verification contract or application contract). |

## Method

|                                                        | Name                                            | Description                                                  |
| ------------------------------------------------------ | ----------------------------------------------- | ------------------------------------------------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [CheckWitness(byte[])](Runtime/CheckWitness.md) | Verifies that the transactions / block of the calling contract has validated the required script hashes. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Log(string)](Runtime/Log.md)                   | Sends a log message to the client executing the smart contract. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Notify(params object[])](Runtime/Notify.md)    | Sends a notification to the client executing the smart contract. |


# Constructor

The Runtime class is a static class and does not require a constructor.