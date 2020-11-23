# UnclaimedGas Method (byte[], uint)

Gets the number of unclaimed GAS.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern BigInteger UnclaimedGas(byte[] account, uint end);
```

Parameters

- account: The script hash of the account to be queried;
- end: To which block height the query ends.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();

    public static object Main()
    {
        BigInteger result = NEO.UnclaimedGas(account, 100);
        return result;
    }
}
```

[Back](../Neo.md)