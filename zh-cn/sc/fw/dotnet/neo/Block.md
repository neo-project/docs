# Block 类

表示区块的类，提供了查询区块中交易的方法。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Block : Header
```

## 方法

|                                          | 名称                                       | 说明           |
| ---------------------------------------- | ---------------------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(int)](Block/GetTransaction.md) | 获得当前区块中指定的交易 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactionCount()](Block/GetTransactionCount.md) | 获得当前区块中交易的数量 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactions()](Block/GetTransactions.md) | 获得当前区块中所有的交易 |

## 构造方法

通过 [Blockchain.GetBlock(byte[])](Blockchain/GetBlock.md) 来构造 Block 对象。

通过 [Blockchain.GetBlock(uint)](Blockchain/GetBlock2.md) 来构造 Block 对象。