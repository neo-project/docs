# TransactionOutput Klasse

Die Datenstruktur wird benutzt um die Transactionausgabe darzustellen. Die Transactionausgabe hat drei Felder.

1. Typ des Assets
2. Zieladresse
3. Menge versendet

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class TransactionOutput: IApiInterface
```

## Attribute

| | Name | Beschreibung |
| ---------------------------------------- | ---------------------------------------- | ------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](TransactionOutput/AssetId.md)  | Gibt die Asset ID zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptHash](TransactionOutput/ScriptHash.md) | Gibt den Scripthash zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Value](TransactionOutput/Value.md)      | Gibt den Gesamtwert  zurück.|

## Ersteller

Das TransactionOutputobjekt wird erzeugt durch [GetOutputs()](Transaction/GetOutputs.md) von dem Transactionobjekt.
