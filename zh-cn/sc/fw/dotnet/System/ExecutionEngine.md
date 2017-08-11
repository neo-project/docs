# ExecutionEngine 类

虚拟机的执行引擎，可以获取当前合约的调用者和执行容器

命名空间：[Neo.SmartContract.Framework.Services.System](../System.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class ExecutionEngine
```

## 属性

|                                          | 名称                                       | 说明                         |
| ---------------------------------------- | ---------------------------------------- | -------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [CallingScriptHash](ExecutionEngine/CallingScriptHash.md) | 获得该智能合约的调用者的脚本散列           |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [EntryScriptHash](ExecutionEngine/EntryScriptHash.md) | 获得该智能合约的入口点（合约调用链的起点）的脚本散列 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ExecutingScriptHash](ExecutionEngine/ExecutingScriptHash.md) | 获得该智能合约执行的脚本散列             |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptContainer](ExecutionEngine/ScriptContainer.md) | 获得该智能合约的脚本容器（最开始的触发者）      |
