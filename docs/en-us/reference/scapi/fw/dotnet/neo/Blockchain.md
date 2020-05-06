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
| [GetAccount(byte[])](Blockchain/GetAccount.md) | Returns an account (address) from the given scripthash |
| [GetAsset(byte[])](Blockchain/GetAsset.md) | Returns an asset from the given asset ID         |
| [GetBlock(byte[])](Blockchain/GetBlock.md) | Returns a block from the given block hash      |
| [GetBlock(uint)](Blockchain/GetBlock2.md) | Returns a block from the given block height          |
| [GetContract(byte[])](Blockchain/GetContract.md) | Returns the contract contents from the given contract hash  |
| [GetHeader(byte[])](Blockchain/GetHeader.md) | Returns a block header from the given block hash     |
| [GetHeader(uint)](Blockchain/GetHeader2.md) | Returns a block header from the given block height         |
| [GetHeight()](Blockchain/GetHeight.md)   | Returns the current block height             |
| [GetTransaction(byte[])](Blockchain/GetTransaction.md) | Returns a transaction from the given transaction ID         |
| [GetValidators()](Blockchain/GetValidators.md) | Returns the public keys of the validators       |

## Constructor

The BlockChain class is a static class and does not require a constructor.
