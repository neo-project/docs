# Blockchain Class

This class provides a set of methods for accessing blockchain data.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Blockchain
```

## Methods

| | Name | Description |
| ---------------------------------------- | ---------------------------------------- | -------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAccount(byte[])](Blockchain/GetAccount.md) | Returns an account (address) from the given scripthash |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAsset(byte[])](Blockchain/GetAsset.md) | Returns an asset from the given asset ID         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBlock(byte[])](Blockchain/GetBlock.md) | Returns a block from the given block hash      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBlock(uint)](Blockchain/GetBlock2.md) | Returns a block from the given block height          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetContract(byte[])](Blockchain/GetContract.md) | `New` Returns the contract contens from the given contract hash   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeader(byte[])](Blockchain/GetHeader.md) | Returns a block header from the given block hash     |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeader(uint)](Blockchain/GetHeader2.md) | Returns a block header from the given block height         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeight()](Blockchain/GetHeight.md)   | Returns the current block height             |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(byte[])](Blockchain/GetTransaction.md) | Returns a transaction from the given transaction ID         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetValidators()](Blockchain/GetValidators.md) | `New` Returns the public keys of the validators       |

## Constructor

The BlockChain class is a static class and does not require a constructor.
