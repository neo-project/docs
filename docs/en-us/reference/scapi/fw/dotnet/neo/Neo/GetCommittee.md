# GetCommittee Method ()

Gets the list of committee members

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern string[] GetCommittee();
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        string[] result = NEO.GetCommittee();
        return result;
    }
}
```

[Back](../Neo.md)