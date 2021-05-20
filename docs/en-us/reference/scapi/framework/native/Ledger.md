# Ledger Class

Provides a series attributes and methods of the native contract GasToken, which hash is`0xda65b600f7124ce6c79950c1772a36403104f2be`.

Namespace：[Neo.SmartContract.Framework.Native](../native.md)

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
| [GetBlock()](Ledger/GetBlock.md)                             | Gets block by the block hash or index                        |
| [GetTransaction(UInt256 hash)](Ledger/GetTransaction.md)     | Gets transaction by transaction ID                           |
| [GetTransactionFromBlock()](Ledger/GetTransactionFromBlock.md) | Gets the specified transaction by the block and transaction indexes |
| [GetTransactionHeight(UInt256 hash)](Ledger/GetTransactionHeight.md) | Gets the block height where the transaction occurs by the transaction hash |

