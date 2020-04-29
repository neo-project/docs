# Block 类

The class that represents blocks, providing a set of related properties.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Block
```

## Attributes

| Name              | Description                                                  |
| ----------------- | ------------------------------------------------------------ |
| Hash              | Gets the block hash                                          |
| Version           | Gets the block version number                                |
| PrevHash          | Gets the hash of the previous block                          |
| MerkleRoot        | Gets the Merkle root of the block                            |
| Timestamp         | Get the time stamp of the block                              |
| Index             | Gets the block index which is counted from 0<br/>Index = Height = Count - 1 |
| NextConsensus     | Get the consensus contract for the next block, i.e. multi-party signed contract composed of more than 2/3 consensus nodes) |
| TransactionsCount | Gets the transaction number of the block                     |

## Constructor

The Block object can be constructed through [Blockchain.GetBlock(byte [])](Blockchain/GetBlock.md).

The Block object can be constructed through [Blockchain.GetBlock(uint)](Blockchain/GetBlock2.md).