# Block Klasse

Eine Klasse die einen Block repräsentiert und einen Weg bietet um Transaktionen in einen Block abzufragen.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Block: Header
```

## Methoden

| | Name | Beschreibung |
| ---------------------------------------- | ---------------------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(int)](Block/GetTransaction.md) | Gibt die Transaktion zurück die in dem aktuellen Block ausgewählt wurde. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactionCount()](Block/GetTransactionCount.md) | Gibt die Nummer der Transaktionen im ausgewählten Block zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactions()](Block/GetTransactions.md) | Gibt alle Transaktionen im ausgewählten Block zurück. |

## Ersteller

Das Blockobjekt wurde erstellt durch [Blockchain.GetBlock(byte[])](Blockchain/GetBlock.md).

Das Blockobjekt wurde erstellt durch [Blockchain.GetBlock(uint)](Blockchain/GetBlock2.md).
