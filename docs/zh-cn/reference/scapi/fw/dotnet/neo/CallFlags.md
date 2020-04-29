# CallFlags 枚举

定义调用合约方法时的模式。

命名空间：Neo.SmartContract

程序集：Neo.SmartContract.Framework

## 语法

```c#
public enum CallFlags : byte
{
    None = 0,

    AllowModifyStates = 0b00000001,
    AllowCall = 0b00000010,
    AllowNotify = 0b00000100,

    ReadOnly = AllowCall | AllowNotify,
    All = AllowModifyStates | AllowCall | AllowNotify
}
```

