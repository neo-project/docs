# CallFlags 枚举

定义调用合约方法时允许哪些特殊行为，如连锁调用、发送通知、修改状态等。

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

### 参数说明

None：不允许被调用合约的特殊行为，如连锁调用、发送通知、修改状态等

AllowModifyStates：允许被调用的合约修改状态

AllowCall：允许被调用的合约连锁调用（调用其它合约）

AllowNotify：允许被调用的合约发送通知

ReadOnly：允许被调用的合约连锁调用以及发送通知

All：允许被调用的合约的全部行为

CallFlags 用在 [Call(UInt160, string, CallFlags, params object[])](Contract/Call.md) 方法中

也可以通过 [GetCallFlags()](Contract/GetCallFlags.md) 获得原生合约的 CallFlags。