# Transaction.Type Eigenschaften

Gibt den Transaktionstyp zurück.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern byte Type {get;}
```

Attributwert: Transaktionstyp als Byte.

Types:

```c#
// Konsenstransaktion, speziell für die Zuweisung von Byte Charges
MinerTransaction = 0x00,
//Spezielle Transaktion für die Verteilung von Assets
IssueTransaction = 0x01,
// Spezielle Abmachung für die Verteilung kleiner Coins
ClaimTransaction = 0x02,
//Spezielle Transaktion für die Registration als ein Book of Candidates
EnrollmentTransaction = 0x20,
//Spezielle Transaktion für die Asset Registration
RegisterTransaction = 0x40,
// Contract Transaktion, welches die meist genutzte Abmachung ist.
ContractTransaction = 0x80,
// Beauftragt von der Transaktion
AgencyTransaction = 0xb0,
// Erteilung einer Abmachung mit einem Smart Contract
PublishTransaction = 0xd0,
// Aufrufen von Smart Contract Transactions
InvocationTransaction = 0xd1
```



[Back](../Transaction.md)
