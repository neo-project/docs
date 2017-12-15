# TransactionInput Klasse

Wir benutzt um die Datenstruktur des Transaction Inputs darzustellen.

In einem UTXO System, muss die Eingabe einer Transaction von der Ausgabe einer anderen bereits existierenden Transaction kommen.

Um die Ausgaben der vorherigen Transaction zu bestätigen, brauchen Sie zwei Dinge.

1.  Einen referenzierten Hash der vorherigen Transaction ([PrevHash](TransactionInput/PrevHash.md))
2.  Der Index für die Eingabe in der Ausgabeliste der vorherigen Transaction ([PrevIndex](TransactionInput/PrevIndex.md))

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class TransactionInput: IApiInterface
```

## Attribute

| | Name | Beschreibung |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash](TransactionInput/PrevHash.md) | Gibt den Transaktionshash der vorhergehenden Transaktion zurück.            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevIndex](TransactionInput/PrevIndex.md) | Gibt den Index der Eingabe in die Ausgabeliste der vorhergehenden Transaktion aus. |

## Ersteller

Das TransactionInputobjekt wird erstellt durch [GetInputs()](Transaction/GetInputs.md) des Transactionobjekts.
