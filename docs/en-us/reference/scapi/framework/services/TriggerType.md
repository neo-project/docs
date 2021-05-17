# TriggerType Enumeration

This enumeration represents the type of smart contract triggers. Triggers enable the contract to execute different logic under different usage scenarios.

For more information about triggers, refer to [Smart Contract Basics](../../../../develop/write/basics.md).

Namespace：[Neo.SmartContract.Framework.Services](../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public enum TriggerType : byte
{
    OnPersist = 0x01,
    PostPersist = 0x02,
    Verification = 0x20,
    Application = 0x40,
    System = OnPersist | PostPersist,
    All = OnPersist | PostPersist | Verification | Application
}
```

OnPersist: Indicate that the contract is triggered by the system to execute the OnPersist method of the native contracts.

PostPersist: Indicate that the contract is triggered by the system to execute the PostPersist method of the native contracts.

Verification: Indicates that the contract is triggered by the verification of a IVerifiable.

Application: Indicates that the contract is triggered by the execution of transactions.

System: The combination of all system triggers.

All: The combination of all triggers.