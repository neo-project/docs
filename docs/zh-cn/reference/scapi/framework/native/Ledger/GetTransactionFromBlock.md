# Ledger.GetTransactionFromBlock 方法

通过区块和交易索引查询指定的交易，其中区块可以通过区块索引（区块高度）或区块哈希指定。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Transaction GetTransactionFromBlock(UInt256 blockHash, int txIndex);
public static extern Transaction GetTransactionFromBlock(uint blockHeight, int txIndex);
```

参数：

- blockHash：指定区块的哈希

- blockHeight: 指定区块的索引（区块高度）
- txIndex：交易索引，区块中的交易索引从 0 开始，依次递增

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void GetFirstTransaction(uint block)
    {
        var tx = Ledger.GetTransactionFromBlock(block, 0);
    }
    public static void GetFirstTransaction(UInt256 block)
    {
        var tx = Ledger.GetTransactionFromBlock(block, 0);
    }
}
```
[返回上级](../Ledger.md)