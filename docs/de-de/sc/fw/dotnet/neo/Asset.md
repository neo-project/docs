# Asset Klasse

Repräsentiert die Datenstruktur eines Assets.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Asset
```

## Attribute

| | Name | Description |
| ---------------------------------------- | ------------------------------- | ------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Admin](Asset/Admin.md) | Gibt als Wert den Administrator (Contract Address) des Assets zurück. Der Administrator hat das Recht Attribute des Assets zu ändern (z.B. total Amount, name, etc.). |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Amount](Asset/Amount.md) | Gibt den Gesamtwert des Assets zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](Asset/AssetId.md) | Gibt die ID des Assets zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetType](Asset/AssetType.md) | Gibt den Typ des Assets zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Available](Asset/Available.md) | Gibt zurück wie oft das Asset ausgeführt wurde. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Issuer](Asset/Issuer.md) | Gibt den Aussteller (Contract Address) des Assets zurück. Der Aussteller hat das Recht das Asset auszuführen |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Owner](Asset/Owner.md) | Gibt den öffentlichen Schlüssel vom Besitzer des Assets zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Precision](Asset/Precision.md) | Gibt die kleinste Stelle oder die Anzahl der Dezimalstellen des Assets zurück. |

## Methods

| | Name | Description |
| ---------------------------------------- | ----------------------------- | ----------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Create(byte, string, long, byte, byte[], byte[], byte[])](Asset/Create.md) |  Registriert ein Asset in der Neo Blockchain. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Renew(byte)](Asset/Renew.md)            |  Für Asset Erneuerungen |

## Ersteller
Das Assetobjekt ist erstellt von [Blockchain.GetAsset (byte[])](Blockchain/GetAsset.md) Methode.

Die [Asset.Create(byte, string, long, byte, byte[], byte[], byte[])](Asset/Create.md) Methode wird benutzt um ein neues Asset auf der Blockchain zu registrieren und gibt das Assetobjekt zurück.
