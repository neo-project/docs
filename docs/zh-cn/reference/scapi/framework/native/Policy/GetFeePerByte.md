# Policy.GetFeePerByte方法

获取交易每字节网络费。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern long GetFeePerByte();
```

返回值：

- 交易每字节网络费

## 示例

```c#
public static void Test()
{
    var feePerByte = Policy.GetFeePerByte();
}
```
[返回上级](../Policy.md)

