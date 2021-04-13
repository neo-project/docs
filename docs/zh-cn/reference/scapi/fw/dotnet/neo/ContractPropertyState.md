# ContractPropertyState 枚举

用来表示智能合约属性状态的枚举。

命名[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public enum ContractPropertyState : byte
{
    NoProperty = 0,

    HasStorage = 1 << 0,
    HasDynamicInvoke = 1 << 1,
    Payable = 1 << 2
}
```

