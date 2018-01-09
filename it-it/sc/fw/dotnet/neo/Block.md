# Classe Block

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
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(int)](Block/GetTransaction.md) | Restituisce la transazione specificata all'interno del blocco |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactionCount()](Block/GetTransactionCount.md) | Restituisce il numero di transazioni all'interno del blocco |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactions()](Block/GetTransactions.md) | Restituisce tutte le transazioni all'interno del blocco |

## Costruttore

L'oggetto Block viene costruito mediante [Blockchain.GetBlock(byte[])](Blockchain/GetBlock.md).

L'oggetto Block viene costruito mediante [Blockchain.GetBlock(uint)](Blockchain/GetBlock2.md).
