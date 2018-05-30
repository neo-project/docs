# Block Class

A class representing a block, providing a way to query transactions in a block.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Block: Header
```

## Methods

| | Name | description |
| ---------------------------------------- | ---------------------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(int)](Block/GetTransaction.md) | Returns the specified transaction within the block |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactionCount()](Block/GetTransactionCount.md) | Returns the number of transactions within the block |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactions()](Block/GetTransactions.md) | Returns all the transactions within the block |

## Constructor

The Block object is constructed through [Blockchain.GetBlock(byte[])](Blockchain/GetBlock.md).

The Block object is constructed through [Blockchain.GetBlock(uint)](Blockchain/GetBlock2.md).
