# TransactionInput Class

Wordt gebruikt om de datastructuur van de transactie-input te weergeven.

In een UTXO-systeem moet de transactie-input komen vanuit de output van een andere, voorafgaande transactie.

Om de outputs van vorige transacties te bevestigen zijn twee zaken nodig:

1. De transactiehash van de voorafgaande transactie ([PrevHash](TransactionInput/PrevHash.md))
2. De index van deze input in de lijst van outputs van de voorafgaande transactie ([PrevIndex](TransactionInput/PrevIndex.md))

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class TransactionInput: IApiInterface
```

## Eigenschappen

| | Naam | Omschrijving |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash](TransactionInput/PrevHash.md) | Geeft als `return` de hash van de voorafgaande transactie |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevIndex](TransactionInput/PrevIndex.md) | Geeft als `return` de index van deze input in de lijst van outputs van de voorafgaande transactie |

## Constructor

Het TransactionInput object wordt gemaakt door [GetInputs()](Transaction/GetInputs.md) van het Transaction object.
