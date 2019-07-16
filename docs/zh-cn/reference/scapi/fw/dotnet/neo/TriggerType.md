# TriggerType 枚举

用来表示智能合约触发器类型的枚举，通过 [Runtime.Trigger](Runtime/Trigger.md) 可以获得当前智能合约的触发器类型是 **验证合约（Verification）** 还是以 **应用合约（Application）** 。

更多关于触发器的知识，请查看 [合约开发基础](../../../../../sc/write/basics.md)。

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

