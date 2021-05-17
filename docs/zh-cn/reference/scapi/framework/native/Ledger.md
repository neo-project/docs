# Ledger 类

提供了原生合约GasToken的一系列属性与方法，合约哈希为`0xda65b600f7124ce6c79950c1772a36403104f2be`。

命名空间：[Neo.SmartContract.Framework.Native](../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Ledger
```

## 属性

| 名称         | 说明                                                         |
| ------------ | ------------------------------------------------------------ |
| Hash         | 获取合约哈希                                                 |
| CurrentHash  | 获取当前链上最新区块的哈希                                   |
| CurrentIndex | 获得区块链中最新的区块高度<br/>区块高度 = 区块索引 = 区块数 - 1<br/>Height = Index = Count - 1 |

## 方法

| 名称                                                         | 说明                                                         |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [GetBlock()](../native/Ledger/GetBlock.md)             | 通过区块哈希或区块索引，查找区块                                       |
| [GetTransaction(UInt256 hash)](../native/Ledger/GetTransaction.md) | 通过交易 ID 查找交易                                         |
| [GetTransactionFromBlock()](../native/Ledger/GetTransactionFromBlock.md) | 通过区块和交易索引查询指定的交易                             |
| [GetTransactionHeight(UInt256 hash)](../native/Ledger/GetTransactionHeight.md) | 通过交易哈希，获得交易所在区块的高度 |

