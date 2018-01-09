# Classe TransactionOutput 

La struttura dati usata per rappresentare la transazione in output. Una transazione in output ha tre campi:

1. Tipi di assets
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
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](TransactionOutput/AssetId.md)  | Returns asset ID |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptHash](TransactionOutput/ScriptHash.md) | Returns the scripthash |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Value](TransactionOutput/Value.md)      | Returns the transaction amount |


## Costruttore

The TransactionOutput object is constructed through [GetOutputs()](Transaction/GetOutputs.md) of the Transaction object.
