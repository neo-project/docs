# StorageContext.EntryContract 枚举

合约入口点（合约调用链的起始点）的存储上下文。

> [!Caution]
> 注：在 2.0 版本中已经弃用。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public enum StorageContext : byte
{
    Current = 1,
    CallingContract = 2,
    EntryContract = 4
}
```

枚举值：4。



[返回上级](../StorageContext.md)
