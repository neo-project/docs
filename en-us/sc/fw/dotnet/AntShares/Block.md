# Block class

A class that represents a block that provides a way to query transactions in a block.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public class Block: Header
```

## method

| | Name | description |
| ---------------------------------------- | ---------------------------------------- | ------------ |
[GetTransaction (int)](Block/GetTransaction.md) | Get the transaction specified in the current block (| https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | |
(Get/RemoveTransactionCount.md) | Get the number of transactions in the current block |
(Get/RemoveTransactions.md) | Get all the transactions in the current block |

## Construction method

The Block object is constructed by [Blockchain.GetBlock (byte[])](Blockchain/GetBlock.md).

The Block object is constructed by [Blockchain.GetBlock (uint)](Blockchain/GetBlock2.md).
