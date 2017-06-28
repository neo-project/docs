# Account.GetBalance method (byte[])

Obtain the balance of such assets in the account through the asset ID.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public extern long GetBalance (byte[] asset_id)
```

Parameters: Asset ID, the transaction ID of the RegistTransaction when the asset is registered, and the 32-byte byte array.

Return value: the balance of the assets in the account, long plastic, equal to the actual amount × 10 puts.

## example

```c#
public class Contract1: FunctionCode
{
    public static void Main ()
    {
        byte[] scriptHash = {36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73};
        Account account = Blockchain.GetAccount (scriptHash);
        // Take the AntShares shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        Long balance = account.GetBalance (asset);
    }
}
```



[Return to superior](../Account.md)
