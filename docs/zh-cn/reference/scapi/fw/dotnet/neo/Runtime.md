# Runtime 类

提供智能合约运行时的一些方法。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

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
| Time | 获取当前区块的时间戳 |
| InvocationCounter | 获取当前合约的调用次数 |

## 方法

| 名称                                                         | 说明                                                    |
| ------------------------------------------------------------ | ------------------------------------------------------- |
| [GetNotifications(byte [] hash = null)](Runtime/GetNotifications.md) | 获取某智能合约执行时的所有通知                          |
| [Log(string message)](Runtime/Log.md)                        | 在智能合约中向执行该智能合约的客户端发送日志            |
| [Notify(params object [] state)](Runtime/Notify.md)          | 在智能合约中向执行该智能合约的客户端发送通知            |
| [CheckWitness(byte [] hashOrPubkey)](Runtime/CheckWitness.md) | 验证调用该智能合约的交易 / 区块是否验证过所需的脚本散列 |

## 构造方法

Runtime 类是静态类，无需构造方法。