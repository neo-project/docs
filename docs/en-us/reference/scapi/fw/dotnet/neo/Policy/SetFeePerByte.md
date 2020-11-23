# SetFeePerByte Method (long)

Sets fee per byte

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool SetFeePerByte(long value);
```

Parameter:

- value: fee per byte

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        bool result = Policy.SetFeePerByte(1200);
        return result;
    }
}
```

[Back](../Policy.md)