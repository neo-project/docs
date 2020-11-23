# GetGasPerBlock Method ()

Gets the number of GAS generated for each block.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern BigInteger GetGasPerBlock();
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        BigInteger result = NEO.GetGasPerBlock();
        return result;
    }
}
```

[Back](../Neo.md)