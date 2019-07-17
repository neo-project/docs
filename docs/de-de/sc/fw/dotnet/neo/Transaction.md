# Transaction Klasse

Repräsentiert die Base Class der Transaktion.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Transaction: IScriptContainer
```

## Attribute

| | Name | Beschreibung |
| ---------------------------------------- | --------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Hash](Transaction/Hash.md) | Gibt den Transaktionshash zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Type](Transaction/Type.md) | Gibt den Transaktionstyp zurück. |

## Methoden

| | Name | Beschreibung |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAttributes()](Transaction/GetAttributes.md) | Gibt alle Attribute der Transaktion zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetInputs()](Transaction/GetInputs.md)  | Gibt alle Transaktionseingaben der Transaktion zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetOutputs()](Transaction/GetOutputs.md) | Gibt alle Transaktionsausgaben der Transaktion zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetReferences()](Transaction/GetReferences.md) | Gibt alle Transaktionsausgaben bezogen auf die Transaktionseingaben der Transaktion aus. |

## Ersteller

Das Transactionobjekt wird erstellt durch [Blockchain.GetTransaction(byte[])](Blockchain/GetTransaction.md).
