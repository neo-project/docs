# ExecutionEngine 类

虚拟机的执行引擎，可以获取当前合约的调用者和执行容器。

命名空间：[Neo.SmartContract.Framework.Services.System](../System.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static class ExecutionEngine
```

## 属性

| 名称                                                         | 说明                                                 |
| ------------------------------------------------------------ | ---------------------------------------------------- |
| [CallingScriptHash](ExecutionEngine/CallingScriptHash.md)    | 获得该智能合约的调用者的脚本散列                     |
| [EntryScriptHash](ExecutionEngine/EntryScriptHash.md)        | 获得该智能合约的入口点（合约调用链的起点）的脚本散列 |
| [ExecutingScriptHash](ExecutionEngine/ExecutingScriptHash.md) | 获得该智能合约执行的脚本散列                         |
| [ScriptContainer](ExecutionEngine/ScriptContainer.md)        | 获得该智能合约的脚本容器（最开始的触发者）           |

## 构造方法

ExecutionEngine 类是静态类，无需构造方法。