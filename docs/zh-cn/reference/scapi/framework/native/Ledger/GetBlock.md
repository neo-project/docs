# Ledger.GetBlock 方法

通过区块索引或区块哈希 ，查找区块。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Block GetBlock(uint index);
public static extern Block GetBlock(UInt256 hash);
```

参数：

- index: 所查询区块的索引（区块高度）
- hash：所查询区块的哈希

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Test()
    {
        var block = Ledger.GetBlock(100);
    }
    public static void Test2(UInt256 hash)
    {
        var block = Ledger.GetBlock(hash);
    }
}
```
[返回上级](../Ledger.md)