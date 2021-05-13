# Ledger.GetTransaction 方法

通过交易哈希 ，查找交易。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Transaction GetTransaction(UInt256 hash);
```

参数：

- hash: 所查询交易的哈希

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Test(UInt256 hash)
    {
        var tx = Ledger.GetTransaction(hash);
    }
}
```
[返回上级](../Ledger.md)