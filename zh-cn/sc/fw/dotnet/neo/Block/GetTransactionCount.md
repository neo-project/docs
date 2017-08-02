# Block.GetTransactionCount 方法 ()

获得当前区块中交易的数量。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public extern int GetTransactionCount()
```

返回值：交易数量，整型。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        Block block = Blockchain.GetBlock(997027);
        int txCount = block.GetTransactionCount();
    }
}
```



[返回上级](../Block.md)