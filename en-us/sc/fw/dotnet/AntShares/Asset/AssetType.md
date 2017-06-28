# Asset.AssetType property

Get the category of the asset.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public extern byte AssetType {get;}
```

Attribute value: the enumeration value of the asset class (not the enumeration name), the enumeration of the asset class is defined as follows:

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



[Return to superior](../Asset.md)
