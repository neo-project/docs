# ExecutionEngine.ScriptContainer 属性

获得该智能合约的脚本容器（最开始的触发者），通常是一笔交易。

命名空间：[Neo.SmartContract.Framework.Services.System](../../System.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern IScriptContainer ScriptContainer { get; }
```

属性值：脚本容器，IScriptContainer 类型，如果你明确知道它是一笔交易触发的，则可以将其转成 [Transaction](../../neo/Transaction.md) 类型。


[返回上级](../ExecutionEngine.md)
