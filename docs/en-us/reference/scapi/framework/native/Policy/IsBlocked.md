# IsBlocked Method

Verifies whether the account is blocked.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

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

    public static object Test()
    {
        string[] result = Policy.IsBlocked(account);
        return result;
    }
}
```

Response body:

```json
{
	"type":"Boolean",
	"value":"false"
}
```

Response description:

- Boolean type: true means the account is blocked.

- Others: failed

[Back](../Policy.md)