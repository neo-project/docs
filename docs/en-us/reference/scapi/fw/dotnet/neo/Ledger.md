# Ledger Class

Provides a series attributes and methods of the native contract GasToken, which hash is`0x971d69c6dd10ce88e7dfffec1dc603c6125a8764`.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Ledger
```

## Attributes

| Name         | Description                                                  |
| ------------ | ------------------------------------------------------------ |
| Hash         | Gets the contract hash.                                      |
| CurrentHash  | Gets hash of the latest block                                |
| CurrentIndex | Gets latest block height in current blockchain<br/>Block height = Block index = Block count - 1<br/> |

## Methods

| Name                                                         | Description                                                  |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [GetBlock()](Blockchain/GetBlock.md)                         | Gets block by the block hash or index                        |
| [GetTransaction(UInt256 hash)](Blockchain/GetTransaction.md) | Gets transaction by transaction ID                           |
| [GetTransactionFromBlock()](Blockchain/GetTransactionFromBlock.md) | Gets the specified transaction by the block and transaction indexes |
| [GetTransactionHeight(UInt256 hash)](Blockchain/GetTransactionHeight.md) | Gets the block height where the transaction occurs by the transaction hash |

