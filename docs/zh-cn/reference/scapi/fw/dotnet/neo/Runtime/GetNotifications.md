# Runtime.GetNotifications 方法 (byte[])

获取给定合约执行的所有通知。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Notification[] GetNotifications(byte[] hash = null)
```

参数：

- hash：合约哈希，20字节长的数组。当数组值全为0时，则返回当前存在的所有通知。

返回值：合约执行的所有通知。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        Notification[] result1 = Runtime.GetNotifications();
        byte[] hash = { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238};
        Notification[] result2 = Runtime.GetNotifications(hash);
    }
}
```

[返回上级](../Runtime.md)