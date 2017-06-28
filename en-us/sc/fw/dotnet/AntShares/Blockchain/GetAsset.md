# Blockchain.GetAsset method (byte[])

Find the asset in the blockchain based on the asset ID.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public static extern AntShares.SmartContract.Framework.Services.AntShares.Asset GetAsset (byte[] asset_id)
```

Parameters: Asset ID, 32 bytes of byte array.

Return Value: Asset, [Asset](../Asset.md) Type.

## example

```c#
public class Contract1: FunctionCode
{
    public static void Main ()
    {
        // Take the AntShares shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        Asset ass = Blockchain.GetAsset (asset);
    }
}
```

Where asset can be obtained in advance from the outside, can also be passed as a parameter into the smart contract. The following is the external code in the call to the ID of the asset ID hexadecimal string into a byte array.

```c#
Static void Main (string[] args)
{
    byte[] asset = AntShares.Helper.HexToBytes ("c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b");
}
```



[Return to superior](../Blockchain.md)
