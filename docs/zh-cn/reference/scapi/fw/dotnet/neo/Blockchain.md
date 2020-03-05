# Blockchain 类

该类提供了访问区块链数据的一系列方法。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static class Blockchain
```

## 方法

| 名称                                                         | 说明                                                         |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [GetBlock(byte\[\] hash)](Blockchain/GetBlock.md)            | 通过区块 hash ，查找区块                                     |
| [GetBlock(uint height)](Blockchain/GetBlock2.md)             | 通过区块高度，查找区块                                       |
| [GetContract(byte\[\] script_hash)](Blockchain/GetContract.md) | 通过合约散列获取合约内容                                     |
| [GetHeight()](Blockchain/GetHeight.md)                       | 获得区块链中最新的区块高度<br/>区块高度 = 区块索引 = 区块数 - 1<br/>Height = Index = Count - 1 |
| [GetTransaction(byte\[\] hash)](Blockchain/GetTransaction.md) | 通过交易 ID 查找交易                                         |
| [GetTransactionFromBlock(byte\[\] blockHash, int txIndex)](Blockchain/GetTransactionFromBlock.md) | 通过区块 hash 和交易索引查找交易                             |
| [GetTransactionFromBlock(uint blockIndex, int txIndex)](Blockchain/GetTransactionFromBlock2.md) | 通过区块索引和交易索引查找交易                               |
| [GetTransactionHeight(byte\[\] hash)](Blockchain/GetTransactionHeight.md) | 通过区块 hash ，获得区块中的交易高度<br/>交易高度 = 交易索引 = 交易数 - 1<br/>Height = Index = Count - 1 |

# 构造方法

BlockChain 类是静态类，无需构造方法。