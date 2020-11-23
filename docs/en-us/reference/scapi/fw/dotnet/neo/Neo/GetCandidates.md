# GetCandidates Method ()

Gets the list of candidates.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern (string, BigInteger)[] GetCandidates();
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        (string, BigInteger)[] result = NEO.GetCandidates();
        return result;
    }
}
```

[Back](../Neo.md)

