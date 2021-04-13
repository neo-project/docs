# ContractPropertyState Enumeration

This enumeration represents the state of the smart contract attribute.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public enum ContractPropertyState : byte
{
    NoProperty = 0,
    HasStorage = 1 << 0,
    HasDynamicInvoke = 1 << 1,
    Payable = 1 << 2
}
```


