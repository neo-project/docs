# Proprietà Asset.AssetType

Restituisce il valore dell'asset.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public extern byte AssetType {get;}
```

Valore dell'attributo: Il valore di enumerazione della classe di asset (non il nome di enumerazione).

L'enumerazione della classe di asset è definita come segue:

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


[Indietro](../Asset.md)
