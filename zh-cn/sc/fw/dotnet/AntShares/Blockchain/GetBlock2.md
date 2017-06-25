# Blockchain.GetBlock 方法 (uint)

通过区块高度，查找区块。

命名空间：[AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

程序集：AntShares.SmartContract.Framework

## 语法

```c#
public static extern AntShares.SmartContract.Framework.Services.AntShares.Block GetBlock(uint height)
```

参数：区块高度（区块索引），无符号整型。

返回值：区块，[Block](../Block.md) 类型。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        Block bl = Blockchain.GetBlock(997027);
    }
}
```





[返回上级](../Blockchain.md)