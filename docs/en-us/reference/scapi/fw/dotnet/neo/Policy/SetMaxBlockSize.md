# SetMaxBlockSize Method  (uint)

Sets the max block size.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool SetMaxBlockSize(uint value);
```

Parameter:

- value: the max block size

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        bool result = Policy.SetMaxBlockSize(1024);
        return result;
    }
}
```

[Back](../Policy.md)

