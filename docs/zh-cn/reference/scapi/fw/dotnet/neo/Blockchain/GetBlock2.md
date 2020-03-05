# Blockchain.GetBlock 方法 (uint)

通过区块高度，查找区块。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Block GetBlock(uint height)
```

参数：

-  height: 区块高度（区块索引），无符号整型。


返回值：区块，[Block](../Block.md) 类型。


## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        Block bl = Blockchain.GetBlock(997027);
    }
}
```



[返回上级](../Blockchain.md)