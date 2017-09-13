# Asset.AssetType プロパティ

アセットのタイプを返します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public extern byte AssetType {get;}
```

属性: アセットクラスの列挙値です (列挙名ではありません)。

アセットクラスの列挙型は次のように定義されます。

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


[戻る](../Asset.md)
