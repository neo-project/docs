# Asset.AssetType 属性

获得该资产的类别。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public extern byte AssetType { get; }
```

属性值：资产类别的枚举值（而非枚举名称），资产类别的枚举定义如下：

```c#
public enum AssetType : byte
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



[返回上级](../Asset.md)