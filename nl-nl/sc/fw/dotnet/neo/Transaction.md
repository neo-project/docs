# Transaction Class

Wordt gebruikt om de basis class van een transactie te weergeven.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Transaction: IScriptContainer
```

## Attributes

| | Naam | Omschrijving |
| ---------------------------------------- | --------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Hash](Transaction/Hash.md) | Geeft als `return` de transactiehash |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Type](Transaction/Type.md) | Geeft als `return` het transactietype |

## Methods

| | Naam | Omschrijving |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAttributes()](Transaction/GetAttributes.md) | Geeft als `return` alle transactie-attributen |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetInputs()](Transaction/GetInputs.md)  | Geeft als `return` alle [TransactionInput](TransactionInput.md)s |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetOutputs()](Transaction/GetOutputs.md) | Geeft als `return` alle [TransactionOutput](TransactionOutput.md)s |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetReferences()](Transaction/GetReferences.md) | Geeft als `return` alle outputs waarnaar wordt verwezen in de transactie-inputs |

## Constructor

Het Transaction object wordt gemaakt door [Blockchain.GetTransaction(byte[])](Blockchain/GetTransaction.md).
