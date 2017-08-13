# Account.GetBalance Method (byte[])

Obtain the balance of specified assets in the account through the asset ID.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern long GetBalance (byte[] asset_id)
```

Parameters: Asset ID, the transaction ID of the RegisterTransaction when the asset is registered. It is a byte array of length 32.

Return value: The balance of the assets in the account as a long, equal to the actual amount multiplied by 100,000,000.

## Example

```c#
public class Contract1: FunctionCode
{
    public static void Main()
    {
        byte[] scriptHash = {36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73};
        Account account = Blockchain.GetAccount(scriptHash);
        // Take NEO shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        long balance = account.GetBalance(asset);
    }
}
```



[Back](../Account.md)
