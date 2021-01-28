# Ledger 类

提供了原生合约GasToken的一系列属性与方法，合约哈希为`0x971d69c6dd10ce88e7dfffec1dc603c6125a8764`。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

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
| [GetBlock(UInt256 hash)](Blockchain/GetBlock.md)             | 通过区块 hash ，查找区块                                     |
| [GetBlock(uint height)](Blockchain/GetBlock2.md)             | 通过区块高度，查找区块                                       |
| [GetTransaction(UInt256 hash)](Blockchain/GetTransaction.md) | 通过交易 ID 查找交易                                         |
| [GetTransactionFromBlock(UInt256 blockHash, int txIndex)](Blockchain/GetTransactionFromBlock.md) | 通过区块 hash 和交易索引查找交易                             |
| [GetTransactionFromBlock(uint blockIndex, int txIndex)](Blockchain/GetTransactionFromBlock2.md) | 通过区块索引和交易索引查找交易                               |
| [GetTransactionHeight(UInt256 hash)](Blockchain/GetTransactionHeight.md) | 通过区块 hash ，获得区块中的交易高度<br/>交易高度 = 交易索引 = 交易数 - 1<br/>Height = Index = Count - 1 |

