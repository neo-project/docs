# TotalSupply Method ()

Gets the total supply of NEO.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern BigInteger TotalSupply();
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        BigInteger result = NEO.TotalSupply();
        return result;
    }
}
```

[Back](../Neo.md)