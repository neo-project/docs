# Runtime.Trigger Attribute

Gets the trigger type for the smart contract, verification contract or application contract. 

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.TriggerType Trigger { get; }
```

Attribute：[TriggerType](../TriggerType.md).

## Example

```c#
public static bool Main()
{
    if (Runtime.Trigger == TriggerType.Verification)
    {
        // do something;
    }
    else if (Runtime.Trigger == TriggerType.Application)
    {
        // do something;
    }
}
```



[Back](../Runtime.md)