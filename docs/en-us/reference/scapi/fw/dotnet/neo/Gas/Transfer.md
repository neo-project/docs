# Transfer Method (byte[], byte[], BigInteger)

Transfers GAS

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool Transfer(byte[] from, byte[] to, BigInteger amount);
```

Parameters:

- from: Script hash of the account you transfer from
- to: Script hash of the account you transfer to
- amount: The amount to be transferred.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] from = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();
    private static readonly byte[] to = "NXjtqYERuvSWGawjVux8UerNejvwdYg7eE".ToScriptHash();

    public static object Main()
    {
        BigInterger value = 1000;
        bool result = GAS.Transfer(from, to, value);
        return result;
    }
}
```

[Back](../Gas.md)