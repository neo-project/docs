# SetMaxBlockSystemFee Method (uint)

Sets the maximum system fee for the block

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool SetMaxBlockSystemFee(long value);
```

Parameter:

- value: the maximum system fee for the block

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        bool result = Policy.SetMaxBlockSystemFee(4007800L);
        return result;
    }
}
```

>[!Note]
>
>The fee should not be less than 4007600.

[Back](../Policy.md)