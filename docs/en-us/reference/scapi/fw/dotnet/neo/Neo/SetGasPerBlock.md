# SetGasPerBlock Method (BigInteger)

Sets the number of GAS generated for each block

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool SetGasPerBlock(BigInteger gasPerBlock);
```

Parameter：

- gasPerBlock: the number of GAS generated for each block

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        BigInteger gasPerBlock  = 10;
        bool result = NEO.SetGasPerBlock(gasPerBlock);
        return result;
    }
}
```

[Back](../Neo.md)