# Runtime 类

提供智能合约运行时的一些方法。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static class Runtime
```

## 属性

|                                          | 名称                            | 说明                         |
| ---------------------------------------- | ----------------------------- | -------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Trigger](Runtime/Trigger.md) | 获得该智能合约的触发条件（鉴权合约 or 应用合约） |

## 方法

|                                          | 名称                                       | 说明                            |
| ---------------------------------------- | ---------------------------------------- | ----------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [CheckWitness(byte[])](Runtime/CheckWitness.md) | 验证调用该智能合约的交易 / 区块是否验证过所需的脚本散列 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Log(string)](Runtime/Log.md)            | 在智能合约中向执行该智能合约的客户端发送日志        |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Notify(params object[])](Runtime/Notify.md) | 在智能合约中向执行该智能合约的客户端发送通知        |


# 构造方法

Runtime 类是静态类，无需构造方法。