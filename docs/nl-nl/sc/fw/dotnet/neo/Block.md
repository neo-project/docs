# Block Class

Een class die staat voor een block, waardoor transacties in een block kunnen worden opgevraagd.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Block: Header
```

## Methods

| | Naam | Omschrijving |
| ---------------------------------------- | ---------------------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(int)](Block/GetTransaction.md) | Geeft als `return` de gespecificeerde transactie binnen het block. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactionCount()](Block/GetTransactionCount.md) | Geeft als `return` het aantal transacties binnen het block. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactions()](Block/GetTransactions.md) | Geeft als `return` alle transacties binnen het block. |

## Constructor

Het Block object wordt gemaakt door [Blockchain.GetBlock(byte[])](Blockchain/GetBlock.md) en [Blockchain.GetBlock(uint)](Blockchain/GetBlock2.md).
