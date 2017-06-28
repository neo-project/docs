# Asset class

Used to represent the data structure of an asset.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public class Asset
```

## Attributes

| | Name | description |
| ---------------------------------------- | ------------------------------- | ------------------------------------- |
[Admin](Asset/Admin.md) | Obtain the administrator (contract address) of the asset, [url] Have the right to modify the attributes of the asset (such as total, name, etc)
|[]() {Amount (Asset/Amount.md) | Get the total amount of the asset |
[AssetId](Asset/AssetId.md) | Get the ID of the asset |
[AssetType](Asset/AssetType.md) | Get the category of this asset |
[Available](Asset/Available.md) | Get the quantity of the asset that has been issued? |[]()
[Issuer](Asset/Issuer.md) | Obtain the issuer (contract address) of the asset, and (s) The right to carry out the issue of assets
[Owner](Asset/Owner.md) | Obtain the owner (public key) of the asset | |[][](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg)
(Precision) (Asset/Precision.md) | Get the accuracy of the asset (the minimum number of divisions), [ The number of digits after the decimal point

## method

| | Name | description |
| ---------------------------------------- | ----------------------------- | ----------- |
|[]() (Https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Renew (byte)](Asset/Renew.md) | `new` for asset renewal |

## Construction method

Constructs an Asset object with the [Blockchain.GetAsset (byte[])](Blockchain/GetAsset.md) method.

(Blockchain/CreateAsset.md) method to create a new asset on the blockchain and return the Asset object (blockchain, string, long, byte, byte[], byte[], byte[]) The
