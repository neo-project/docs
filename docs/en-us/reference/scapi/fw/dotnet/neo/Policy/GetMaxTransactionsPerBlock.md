# GetMaxTransactionsPerBlock Method ()

Sets max transaction per block

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern uint GetMaxTransactionsPerBlock();
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        uint result = Policy.GetMaxTransactionsPerBlock();
        return result;
    }
}
```

[Back](../Policy.md)



