# Classe TransactionOutput 

La struttura dati usata per rappresentare la transazione in output. Una transazione in output ha tre campi:

1. Tipi di asset
2. Indirizzo di destinazione
3. Quantitá trasferita

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public class TransactionOutput: IApiInterface
```

## Attributi

| | Nome | Descrizione |
| ---------------------------------------- | ---------------------------------------- | ------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](TransactionOutput/AssetId.md)  | Restituisce l'ID dell'asset |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptHash](TransactionOutput/ScriptHash.md) | Restituisce lo scripthash |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Value](TransactionOutput/Value.md)      | Restituisce la quantitá della transazione |


## Costruttore

L'oggetto TransactionOutput é costruito mediante [GetOutputs()](Transaction/GetOutputs.md) dell'oggetto Transaction.
