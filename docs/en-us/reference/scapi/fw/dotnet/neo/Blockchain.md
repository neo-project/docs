# Blockchain Class

This class provides a set of methods for accessing blockchain data.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Blockchain
```

## Methods

| Name | Description |
| ---------------------------------------- | -------------------- |
| [GetBlock(byte[] hash)](Blockchain/GetBlock.md) | Returns a block from the given block hash      |
| [GetBlock(uint height)](Blockchain/GetBlock2.md) | Returns a block from the given block height          |
| [GetContract(byte[] script_hash)](Blockchain/GetContract.md) | Returns the contract contents from the given contract hash  |
| [GetHeight()](Blockchain/GetHeight.md)   | Returns the current block height<br>Height = Index = Count - 1 |
| [GetTransaction(byte[] hash)](Blockchain/GetTransaction.md) | Returns a transaction from the given transaction ID         |
| [GetTransactionFromBlock(byte[] blockHash, int txIndex)](Blockchain/GetTransactionFromBlock.md) | Returns a transaction from the given block hash and transaction index |
| [GetTransactionFromBlock(uint blockIndex, int txIndex)](Blockchain/GetTransactionFromBlock2.md) | Returns a transaction from the given block index and transaction index |
| [GetTransactionHeight(byte[] hash)](Blockchain/GetTransactionHeight.md) | Returns the transaction height from the given block hash<br>Height = Index = Count - 1 |

## Constructor

The Blockchain class is a static class and does not require a constructor.
