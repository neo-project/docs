# Asset.AssetType Property

Возвращает тип данного актива.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## syntax

```c#
public extern byte AssetType {get;}
```

Значение атрибута: Перечисляемое значение класса актива (а не перечисляемое имя).

Перечисление класса актива определяется следующим образом:

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
