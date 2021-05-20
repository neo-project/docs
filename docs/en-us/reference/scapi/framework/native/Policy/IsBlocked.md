# Policy.IsBlocked Method

Verifies if the specified account is blocked.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool IsBlocked(UInt160 account);
```

Parameter:

- account: the specified account

Return:

- Whether the account is blocked

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();

    public static object Test()
    {
        var isBlocked= Policy.IsBlocked(account);
    }
}
```
[Back](../Policy.md)

