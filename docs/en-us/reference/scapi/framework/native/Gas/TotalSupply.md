# GAS.TotalSupply Method

Gets the total supply of GAS.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern BigInteger TotalSupply();
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        BigInteger result = GAS.TotalSupply();
        return result;
    }
}
```

[Back](../Gas.md)