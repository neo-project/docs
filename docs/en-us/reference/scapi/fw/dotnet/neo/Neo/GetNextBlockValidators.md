# GetNextBlockValidators Method ()

Gets the list of validators for the next block

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern string[] GetNextBlockValidators();
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        string[] result = NEO.GetNextBlockValidators();
        return result;
    }
}
```

[Back](../Neo.md)