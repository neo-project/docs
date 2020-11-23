# GetMaxBlockSystemFee Method ()

Gets the maximum system fee for the block

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern long GetMaxBlockSystemFee();
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        long result = Policy.GetMaxBlockSystemFee();
        return result;
    }
}
```

[Back](../Policy.md)