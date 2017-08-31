# TriggerType 枚举

用来表示智能合约触发条件的枚举，通过 [Runtime.Trigger](Runtime/Trigger.md) 可以获得当前智能合约是以 **鉴权合约（Verification）** 的方式触发的，还是以 **应用合约（Application）** 的方式触发的 。

| 触发器 Trigger      | 鉴权合约 Verification | 应用合约 Application                         |
| ---------------- | ----------------- | ---------------------------------------- |
| 继承的基类            | VerificationCode  | FunctionCode                             |
| 触发方式             | 从该合约地址转账会自动触发合约   | 1、发送交易（Invocation Transaction）来触发合约；2、从该合约地址转账会自动触发合约（需额外编程） |
| 可发布到区块链上 被其它合约调用 | 否                 | 是                                        |



命名[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public enum TriggerType : byte
{
    Verification = 0x00,
    Application = 0x10
}
```

