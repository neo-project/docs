# Runtime.Trigger 属性

获得该智能合约的触发器类型（鉴权合约 or 应用合约）。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.TriggerType Trigger { get; }
```

属性值：[TriggerType](../TriggerType.md)。

## 示例

```c#
public static bool Main()
{
    if (Runtime.Trigger == TriggerType.Verification)
    {
        // do something;
    }
    else if (Runtime.Trigger == TriggerType.Application)
    {
        // do something;
    }
}
```

详细示例可参考 [ICO_Template](https://github.com/neo-project/examples-csharp/blob/master/ICO_Template/ICO_Template.cs)。



[返回上级](../Runtime.md)