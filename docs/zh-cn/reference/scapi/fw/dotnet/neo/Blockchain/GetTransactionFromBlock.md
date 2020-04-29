# Blockchain.GetTransactionFromBlock 方法 (byte[], int)

通过区块哈希和交易索引查找交易。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Transaction GetTransactionFromBlock(byte[] blockHash, int txIndex);
```

参数：

- blockHash: 区块哈希，32字节的字节数组；
- txIndex：交易索引

返回值：交易，[Transaction](../Transaction.md) 类型。

## 示例

```c#
public class Contract1 : System.Blockchain.GetContract
{
    public static void Main()
    {
        byte[] blockHash = new byte[] { 88, 114, 160, 206, 130, 137, 41, 94, 119, 120, 242, 71, 232, 244, 3, 20, 165, 69, 182, 232, 106, 185, 119, 239, 183, 65, 174, 220, 157, 251, 28, 215 };
        int txIndex = 2;
        Transaction tx = Blockchain.GetTransactionFromBlock(blockHash, txIndex);
    }
}
```



[返回上级](../Blockchain.md)