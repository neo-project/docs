# Classe del Block

Una classe rappresentante un blocco, fornisce il modo per interrogare la transazione in un blocco.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public class Block: Header
```

## Metodi

| | Nome | Descrizione |
| ---------------------------------------- | ---------------------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(int)](Block/GetTransaction.md) | Returns the specified transaction within the block |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactionCount()](Block/GetTransactionCount.md) | Returns the number of transactions within the block |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactions()](Block/GetTransactions.md) | Returns all the transactions within the block |

## Costruttore

The Block object is constructed through [Blockchain.GetBlock(byte[])](Blockchain/GetBlock.md).

The Block object is constructed through [Blockchain.GetBlock(uint)](Blockchain/GetBlock2.md).
