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
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Amount](Asset/Amount.md) | Restituisce la quantitá totale dell'asset |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](Asset/AssetId.md) | Restituisce l'ID dell'asset |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetType](Asset/AssetType.md) | Restituisce il tipo di questo asset |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Available](Asset/Available.md) | Restituisce la quantitá dell'asset che é stato emesso |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Issuer](Asset/Issuer.md) | Restituisce l'emittente (indirizzo del contratto) dell'asset che ha il diritto di emettere l'asset |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Owner](Asset/Owner.md) | Restituisce il proprietario (chiave pubblica) dell'asset |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Precision](Asset/Precision.md) | Restituisce l'accuratezza dell'asset (divisione del numero), o il numero di cifre dopo il punto decimale |

## Metodi

| | Nome  | Descrizione |
| ---------------------------------------- | ----------------------------- | ----------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Create(byte, string, long, byte, byte[], byte[], byte[])](Asset/Create.md) | `new` Register an asset on the blockchain |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Renew(byte)](Asset/Renew.md)            | `new` For asset renewal       |

## Constructor

The Asset object is constructed through [Blockchain.GetAsset (byte[])](Blockchain/GetAsset.md) method.

The [Asset.Create(byte, string, long, byte, byte[], byte[], byte[])](Asset/Create.md) method is used to register a new asset on the blockchain and returns an Asset object.
