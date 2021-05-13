# CallFlags Enumerator

Defines special behaviors allowed when invoking smart contracts, such as chain calls, sending notifications, modifying states, etc.

Namespace：[Neo.SmartContract.Framework.Services](../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public enum CallFlags : byte
{
    None = 0,

    AllowModifyStates = 0b00000001,
    AllowCall = 0b00000010,
    AllowNotify = 0b00000100,

    ReadOnly = AllowCall | AllowNotify,
    All = AllowModifyStates | AllowCall | AllowNotify
}
```

### Parameters description

None: Special behaviors of the invoked contract are not allowed, such as chain calls, sending notifications, modifying state, etc.

AllowModifyStates: Allows the invoked contract to modify status.

AllowCall: Allows the invoked contract to do chain calls.

AllowNotify: Allows the invoked contract to send notifications.

ReadOnly: Allows the invoked contract to do chain calls and send notifications.

All: All behaviors of the invoked contract are allowed.

CallFlags is used in the method [Call(UInt160, string, CallFlags, params object[])](Contract/Call.md).

You can also get CallFlags of native contract by [GetCallFlags()](Contract/GetCallFlags.md) .