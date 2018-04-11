# Block.GetTransactions 方法 ()

获得当前区块中所有的交易。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public extern Neo.SmartContract.Framework.Services.Neo.Transaction[] GetTransactions()
```

返回值：交易数组，Transaction[] 类型。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        Block block = Blockchain.GetBlock(997027);
        Transaction[] txs = block.GetTransactions();
    }
}
```



[返回上级](../Block.md)