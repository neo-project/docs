# Runtime.Trigger Attribute

Gets the trigger type for the smart contract. 

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern TriggerType Trigger { get; }
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

For details, refer to [Template](https://github.com/neo-project/examples/blob/master/csharp/ICO_Template/ICO_Template.cs).



[Back](../Runtime.md)