# Classe TransactionInput 

Usata per rappresentare la struttura dati della transazione in input.

In un sistema UTXO, l'input della transazione deve venire dall'output di un'altra transazione esistita precedentemente.

Per confermare gli outputs delle precedenti transazioni, sono richieste due cose:

1.  The hash of the previous transaction referenced ([PrevHash](TransactionInput/PrevHash.md))
2.  The index of this input in the output list of the previous transaction ([PrevIndex](TransactionInput/PrevIndex.md))

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public class TransactionInput: IApiInterface
```

## Attributi

| | Nome | Descrizione |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash](TransactionInput/PrevHash.md) | Returns the hash of the previous transaction            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevIndex](TransactionInput/PrevIndex.md) | Returns the index of this input in the output list of the previous transaction |

## Costruttore

The TransactionInput object is constructed through [GetInputs()](Transaction/GetInputs.md) of the Transaction object.
