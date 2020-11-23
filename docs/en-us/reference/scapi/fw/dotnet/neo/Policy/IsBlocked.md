# IsBlocked Method (byte[])

Verifies whether the account is blocked.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern string[] IsBlocked(byte[] account);
```

Parameter:

- account: the account script hash

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();

    public static object Main()
    {
        string[] result = Policy.IsBlocked(account);
        return result;
    }
}
```

[Back](../Policy.md)