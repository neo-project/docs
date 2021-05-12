# UnblockAccount Method

Unblocks accounts.

Namespace: [Neo.SmartContract.Framework.Native](../../Neo.SmartContract.Framework.Native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool UnblockAccount(UInt160 account);
```

Parameter：

- account: The script hash of the account to be unblocked.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 account = "NirHUAteaMr6CqWuAAMaEUScPcS3FDKebM".ToScriptHash();

    public static object Test()
    {
        bool result = Policy.UnblockAccount(account);
        return result;
    }
}
```

Response body:

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

Response description:

- true: The account is successfully unblocked.

- Others: failed.

[Back](../Policy.md)

