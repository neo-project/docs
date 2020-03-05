# Blockchain.GetTransaction 方法 (byte[])

通过交易哈希查找交易。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Transaction GetTransaction(byte[] hash)
```

参数：

- hash: 交易ID（交易哈希），32字节的字节数组。

返回值：交易，[Transaction](../Transaction.md) 类型。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        byte[] transaction = new byte[] { 88, 114, 160, 206, 130, 137, 41, 94, 119, 120, 242, 71, 232, 244, 3, 20, 165, 69, 182, 232, 106, 185, 119, 239, 183, 65, 174, 220, 157, 251, 28, 215 };
        Transaction tx = Blockchain.GetTransaction(transaction);
    }
}
```



[返回上级](../Blockchain.md)