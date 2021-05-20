# Policy.GetStoragePrice方法

获取链上每字节数据存储费用。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern uint GetStoragePrice();
```

返回值：

- 每字节数据存储费用

## 示例

```c#
public static void Test()
{
    var price = Policy.GetStoragePrice();
}
```
[返回上级](../Policy.md)

