# Classe dell'Asset

Rappresenta la struttura dei dati di un asset.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public class Asset
```

## Attributi

| | Nome | Descrizione |
| ---------------------------------------- | ------------------------------- | ------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Admin](Asset/Admin.md) | Restituisce l'amministratore (indirizzo del contratto) dell'asset che ha il diritto di modificare gli attributi dell'asset (come totale, nome, etc) |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Amount](Asset/Amount.md) | Returns the total amount of the asset |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](Asset/AssetId.md) | Returns the ID of the asset |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetType](Asset/AssetType.md) | Returns the type of this asset |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Available](Asset/Available.md) | Returns the quantity of the asset that has been issued |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Issuer](Asset/Issuer.md) | Returns the issuer (contract address) of the asset who has the right to issue the asset |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Owner](Asset/Owner.md) | Returns the owner (public key) of the asset |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Precision](Asset/Precision.md) | Returns the accuracy of the asset (the smallest division), or the number of digits after the decimal point |

## Methods

| | Name | Description |
| ---------------------------------------- | ----------------------------- | ----------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Create(byte, string, long, byte, byte[], byte[], byte[])](Asset/Create.md) | `new` Register an asset on the blockchain |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Renew(byte)](Asset/Renew.md)            | `new` For asset renewal       |

## Constructor

The Asset object is constructed through [Blockchain.GetAsset (byte[])](Blockchain/GetAsset.md) method.

The [Asset.Create(byte, string, long, byte, byte[], byte[], byte[])](Asset/Create.md) method is used to register a new asset on the blockchain and returns an Asset object.
