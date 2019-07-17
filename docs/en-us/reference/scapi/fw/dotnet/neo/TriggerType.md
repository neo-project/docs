# TriggerType Enumeration

An enumeration used to represent the type of smart contract trigger. Using [Runtime.Trigger](Runtime/Trigger.md) you can get whether the trigger type of the current smart contract is **Verification** or **Application**.

For more information on triggers, refer to  [Smart Contract Triggers](../../../../../sc/write/basics.md)

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public enum TriggerType : byte
{
    Verification = 0x00,
    Application = 0x10
}
```

