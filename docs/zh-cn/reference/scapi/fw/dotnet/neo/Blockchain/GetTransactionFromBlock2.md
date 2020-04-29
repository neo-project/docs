# Blockchain.GetTransactionFromBlock 方法 (uint, int)

通过区块索引和交易索引查找交易。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Transaction GetTransactionFromBlock(uint blockIndex, int txIndex)
```

参数：

- blockIndex: 区块索引；
- txIndex：交易索引

返回值：交易，[Transaction](../Transaction.md) 类型。

## 示例

```c#
public class Contract1 : System.Blockchain.GetContract
{
    public static void Main()
    {
        uint blockIndex = 241400;
        int txIndex = 2;
        Transaction tx = Blockchain.GetTransactionFromBlock(blockIndex, txIndex);
    }
}
```



[返回上级](../Blockchain.md)