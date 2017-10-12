# TransactionOutput Class

De datastructuur die staat voor de transactie-output. Deze bevat drie velden:

1. Type assets
2. Doel-adres
3. Hoeveelheid die is overgemaakt

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class TransactionOutput: IApiInterface
```

## Eigenschappen

| | Naam | Omschrijving |
| ---------------------------------------- | ---------------------------------------- | ------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](TransactionOutput/AssetId.md)  | Geeft als `return` de asset-ID |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptHash](TransactionOutput/ScriptHash.md) | Geeft als `return` de  scripthash |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Value](TransactionOutput/Value.md)      | Geeft als `return` het overgemaakte bedrag |


## Constructor

HEt TransactionOutput object wordt gemaakt door [GetOutputs()](Transaction/GetOutputs.md) van het Transaction object.
