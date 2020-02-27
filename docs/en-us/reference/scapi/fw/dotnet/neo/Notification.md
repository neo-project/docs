# Notification Class

Represents the notification sent when the smart contract executes.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Notification : IApiInterface
```

## Attributes

| Name                                   | Description              |
| ---------------------------------------- | -------------------------- |
| ScriptHash | The script hash of the notification sender |
| State          |   The object representing the notification content, which can be of any type such as value, string, array, etc.   |

## Constructor

Gets Notification objects from [Runtime.GetNotifications(byte[] hash = null)](Runtime/GetNotifications.md) .
