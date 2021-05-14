# TriggerType 枚举

定义了触发器类型。触发器可以使合约根据不同的使用场景执行不同的逻辑。

更多关于触发器的知识，请查看 [合约开发基础](../../../../develop/write/basics.md)。

命名[Neo.SmartContract.Framework.Services](../services.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public enum TriggerType : byte
{
    OnPersist = 0x01,
    PostPersist = 0x02,
    Verification = 0x20,
    Application = 0x40,
    System = OnPersist | PostPersist,
    All = OnPersist | PostPersist | Verification | Application
}
```

OnPersist: 表示该合同由系统触发，执行本地合同的OnPersist方法。

PostPersist: 表示该合同由系统触发，执行本地合同的PostPersist方法。

Verification: 表示合同是由一个IVerifiable的验证触发的。

Application: 表示合同是由交易的执行触发的。

System: 所有系统触发器的组合。

All: 所有触发器的组合。