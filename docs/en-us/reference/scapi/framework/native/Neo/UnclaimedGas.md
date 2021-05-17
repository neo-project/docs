# NEO.UnclaimedGas Method

Gets the number of unclaimed GAS.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern BigInteger UnclaimedGas(UInt160 account, uint end);
```

Parameters

- account: The script hash of the account to be queried;
- end: To which block height the query ends.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();

    public static object Test()
    {
        BigInteger result = NEO.UnclaimedGas(account, 100);
        return result;
    }
}
```

Response body:

```json
{
	"Type":"Integer",
	"value":"100000"
}
```

Response description:

- Integer type: unclaimed GAS amount of this address is successfully requested.

- Others: failed.

[Back](../Neo.md)