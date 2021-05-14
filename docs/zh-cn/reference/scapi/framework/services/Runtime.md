# Runtime 类

提供智能合约运行时的一些方法。

命名空间：[Neo.SmartContract.Framework.Services](../services.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static class Runtime
```

## 属性

| 名称                            | 说明                         |
| ----------------------------- | -------------------------- |
| [Trigger](Runtime/Trigger.md) | 获得该智能合约的触发条件 |
| Platform | 获取当前执行智能合约的平台信息 |
| ScriptContainer | 获取当前的脚本容器 |
| ExecutingScriptHash | 获取当前上下文的脚本散列 |
| CallingScriptHash | 获取调用合约的脚本散列 |
| EntryScriptHash | 获取上下文入口点的脚本散列 |
| Time | 获取当前区块的时间戳 |
| InvocationCounter | 获取当前合约的调用次数 |
| GasLeft | 获取当前交易剩余的 GAS 费用数量 |


## 方法

| 名称                                                         | 说明                                         |
| ------------------------------------------------------------ | -------------------------------------------- |
| [GetNotifications(UInt160 hash = null)](Runtime/GetNotifications.md) | 获取某智能合约执行时的所有通知               |
| [Log(string message)](Runtime/Log.md)                        | 在智能合约中向执行该智能合约的客户端发送日志 |
| [CheckWitness()](Runtime/CheckWitness.md)                    | 确定指定账户是否见证了当前交易               |
| BurnGas                                                      | 燃烧 GAS，造福 Neo 生态系统                  |

## 构造方法

Runtime 类是静态类，无需构造方法。