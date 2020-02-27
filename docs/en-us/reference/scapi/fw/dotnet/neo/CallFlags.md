# CallFlags Enumerator

Defines the flag when invoking smart contracts.

Namespace：Neo.SmartContract

Assembly：Neo.SmartContract.Framework

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

