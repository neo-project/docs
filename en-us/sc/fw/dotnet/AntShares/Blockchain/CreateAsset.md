# Blockchain.CreateAsset method (byte, string, long, byte, byte[], byte[], byte[])

Calling this method in a smart contract allows you to register an asset in a small block area.

The method is a replacement for RegistTransaction in version 2.0.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public static extern AntShares.SmartContract.Framework.Services.AntShares.Asset CreateAsset (byte asset_type, string name, long amount, byte precision, byte[] owner, byte[] admin, byte[] issuer)
```

parameter:

Asset_type: Asset type, byte type, please refer to [AssetType](../Asset/AssetType.md).

Name: the name of the asset, the string type.

Amount: the total amount of assets, long, the value equal to the actual amount × 10 puts.

Precision: the accuracy of the asset (the minimum number of divisions), the number of bits after the decimal point, the byte type.

Owner: The owner of the asset (public key), 33 bytes of the byte array.

Admin: the administrator of the asset (contract address), the administrator has the right to attribute the assets (such as the total, name, etc.) to modify the 20-byte byte array.

Issuer: the issuer of the asset (contract address), the issuer has the right to carry out the issuance of assets, 20 bytes of byte array.

Return Value: Created asset, [Asset](../Asset.md) type.

## example

```c#
public class Contract1: FunctionCode
{
    public static void Main ()
    {
        Byte assetType = 0x60; // Token
        String name = "Star Wars movie ticket";
        Long amount = 1000;
        Byte precision = 0;
        byte[] owner = {2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202};
        byte[] admin = {36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73};
        byte[] issuer = admin;
        Asset ass = Blockchain.CreateAsset (assetType, name, amount, precision, owner, admin, issuer);
        Uint blockIndex = ass.Renew (1);
    }
}
```



[Return to superior](../Blockchain.md)
