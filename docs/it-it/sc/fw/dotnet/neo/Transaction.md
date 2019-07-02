# Classe Transaction 

Usata per rappresentare la classe base di una transazione.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public class Transaction: IScriptContainer
```

## Attributi

| | Nome | Descrizione |
| ---------------------------------------- | --------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Hash](Transaction/Hash.md) | Restituisce l'hash della transazione |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Type](Transaction/Type.md) | Restituisce il tipo di transazione |

## Metodi

| | Nome | Descrizione |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAttributes()](Transaction/GetAttributes.md) | Restituisce tutti gli attributi della transazione |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetInputs()](Transaction/GetInputs.md)  | Restituisce tutti i [TransactionInput](TransactionInput.md) della transazione |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetOutputs()](Transaction/GetOutputs.md) | Restituisce tutti [TransactionOutput](TransactionOutput.md) della transazione |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetReferences()](Transaction/GetReferences.md) | Restituisce tutti gli output a cui fanno riferimento gli input della transazione |

## Costruttore

L'oggetto Transaction é costruito mediante [Blockchain.GetTransaction(byte[])](Blockchain/GetTransaction.md).
