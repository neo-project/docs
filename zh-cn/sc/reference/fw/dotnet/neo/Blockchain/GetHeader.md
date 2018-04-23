# Blockchain.GetHeader 方法 (byte[])

通过区块 hash ，查找区块头。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Header GetHeader(byte[] hash)
```

参数：区块 Hash，32 字节的字节数组。

返回值：区块头，[Header](../Header.md) 类型。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[] Header = new byte[] { 206, 240, 165, 25, 76, 228, 58, 100, 117, 184, 213, 171, 61, 96, 34, 234, 129, 116, 60, 232, 71, 11, 231, 143, 195, 123, 5, 190, 250, 182, 14, 152 };
        Header bl = Blockchain.GetHeader(Header);
    }
}
```



[返回上级](../Blockchain.md)