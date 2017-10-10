# Asset Class

Staat voor de datastructuur van een asset.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Asset
```

## Eigenschappen

| | Naam | Omschrijving |
| ---------------------------------------- | ------------------------------- | ------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Admin](Asset/Admin.md) | Geeft als `return` de administrator (contractadres) van de asset (heeft het recht om de eigenschappen van een asset aan te passen).|
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Amount](Asset/Amount.md) | Geeft als `return` de totale hoeveelheid van een asset.|
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](Asset/AssetId.md) | Geeft als `return` de ID van de asset. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetType](Asset/AssetType.md) | Geeft als `return` het type van deze asset. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Available](Asset/Available.md) | Geeft als `return` de gedistribueerde hoeveelheid van een asset.|
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Issuer](Asset/Issuer.md) | Geeft als `return` het contractadres van degene die een asset heeft gedistribueerd. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Owner](Asset/Owner.md) | Geeft als `return` de eigenaar (public key) van de asset. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Precision](Asset/Precision.md) | Geeft als `return` de nauwkeurigheid van een asset (hoeveel getallen achter de komma).|

## Methods

| | Naam | Omschrijving |
| ---------------------------------------- | ----------------------------- | ----------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Create(byte, string, long, byte, byte[], byte[], byte[])](Asset/Create.md) | `Nieuw` Registreer een asset op de blockchain. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Renew(byte)](Asset/Renew.md)            | `Nieuw` Vernieuw een asset. |

## Constructor

Het Asset object wordt gemaakt door de [Blockchain.GetAsset (byte[])](Blockchain/GetAsset.md) method.

De [Asset.Create(byte, string, long, byte, byte[], byte[], byte[])](Asset/Create.md) method wordt gebruikt om een nieuwe asset op de blockchain te registreren en geeft als `return` een Asset object.
