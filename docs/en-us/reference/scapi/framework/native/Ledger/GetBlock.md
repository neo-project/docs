# Ledger.GetBlock Method

Gets block by the block hash or index.

Namespace：[Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Block GetBlock(uint index);
public static extern Block GetBlock(UInt256 hash);
```

Parameters：

- index: Index of the block to query
- hash: Hash of the block to query

## Example

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
[Back](../Ledger.md)