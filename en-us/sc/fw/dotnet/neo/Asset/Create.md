# Asset.CreateAsset Method (byte, string, long, byte, byte[], byte[], byte[])

This method registers an asset on the Neo blockchain.

This method replaces the RegisterTransaction in version 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Asset Create(byte asset_type, string name, long amount, byte precision, byte[] owner, byte[] admin, byte[] issuer)
```

Parameters:

asset_type: An asset type as a byte. For details, please refer to [AssetType](../Asset/AssetType.md).

name: The name of the asset as a string.

amount: The amount of assets as a long. The input value here should be the intended value multipled by 100,000,000.

precision: The smallest division of the asset，or the number of decimals places that the asset can take as byte.

owner: The public key of the owner as a byte array of length 33.

admin: The contract address of the adminstrator as a byte array of length 20.

issuer: The contract address of the issuer as a byte array of length 20.

Return value: The newly registered asset as an [Asset](../Asset.md) object.

## Example

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte assetType = 0x60; //Token
        string name = "StarWarsMovieTicket";
        long amount = 1000;
        byte precision = 0;
        byte[] owner = { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202 };
        byte[] admin = { 36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73 };
        byte[] issuer = admin;
        Asset ass = Asset.Create(assetType, name, amount, precision, owner, admin, issuer);
        uint blockIndex = ass.Renew(1);
    }
}
```



[Back](../Asset.md)