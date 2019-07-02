# Classe TransactionInput 

Usata per rappresentare la struttura dati della transazione in input.

In un sistema UTXO, l'input della transazione deve venire dall'output di un'altra transazione esistita precedentemente.

Per confermare gli outputs delle precedenti transazioni, sono richieste due specifiche:

1.  Il riferimento all'hash della transazione precedente ([PrevHash](TransactionInput/PrevHash.md))
2.  L'indice di questo input nella lista output delle transazioni precedenti ([PrevIndex](TransactionInput/PrevIndex.md))

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public class TransactionInput: IApiInterface
```

## Attributi

| | Nome | Descrizione |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash](TransactionInput/PrevHash.md) | Restituisce l'hash della transazione precedente            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevIndex](TransactionInput/PrevIndex.md) | Restituisce l'indice di questo input nella lista output delle transazioni precedenti |

## Costruttore

L'oggetto TransactionInput é costruito mediante [GetInputs()](Transaction/GetInputs.md) dell'oggetto Transaction.
