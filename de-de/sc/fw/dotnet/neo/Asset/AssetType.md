# Asset.AssetType Eigenschaft

Gibt den Typ des Assets zurück.

Namensraum: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## syntax

```c#
public extern byte AssetType {get;}
```

Attributwert: Die aufgezählten Werte des Assets (nicht die aufgezählten Namen).

Die Aufzählung der Assetklasse sieht wie folgt aus: 

```c#
public enum AssetType: byte
{
     CreditFlag = 0x40,
     DutyFlag = 0x80,

     SystemShare = 0x00,
     SystemCoin = 0x01,
     Currency = 0x08,
     Share = DutyFlag | 0x10,
     Invoice = DutyFlag | 0x18,
     Token = CreditFlag | 0x20,
}
```


[Back](../Asset.md)
