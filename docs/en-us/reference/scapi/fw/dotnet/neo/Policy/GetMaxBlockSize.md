# GetMaxBlockSize Method ()

Gets max block size

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern uint GetMaxBlockSize()；
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        uint result = Policy.GetMaxBlockSize();
        return result;
    }
}
```

[Back](../Policy.md)