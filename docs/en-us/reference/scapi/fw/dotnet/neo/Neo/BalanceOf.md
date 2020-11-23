# BalanceOf Method (byte[])

Gets the NEO balance in the account.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern BigInteger BalanceOf(byte[] account);
```

Parameters:

- account: Script hash of the account

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();

    public static object Main()
    {
        BigInteger result = NEO.BalanceOf(account);
        return result;
    }
}
```

[Back](../Neo.md)