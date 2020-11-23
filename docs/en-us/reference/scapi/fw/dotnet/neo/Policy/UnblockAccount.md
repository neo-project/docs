# UnblockAccount Method (byte[])

Unblocks accounts.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool UnblockAccount(byte[] account);
```

Parameter：

- account: The script hash of the account to be unblocked.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] account = "NirHUAteaMr6CqWuAAMaEUScPcS3FDKebM".ToScriptHash();

    public static object Main()
    {
        bool result = Policy.UnblockAccount(account);
        return result;
    }
}
```

[Back](../Policy.md)

