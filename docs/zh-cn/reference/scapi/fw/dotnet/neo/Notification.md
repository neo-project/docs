# Notification 类

表示合约执行发送的通知。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Notification : IApiInterface
```

## 属性

| 名称                                       | 说明                         |
| ---------------------------------------- | -------------------------- |
| ScriptHash | 通知发送者Sender的脚本哈希    |
| State          |   代表通知内容的对象，可为任意类型（数值、字符串、数组）               |

## 构造方法

通过 [Runtime.GetNotifications(byte[] hash = null)](Runtime/GetNotifications.md) 来获得 Notification 对象。
