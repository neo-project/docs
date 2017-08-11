# Propiedad Transaction.Type

Devuelve el tipo de la transacción actual.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public extern byte Type {get;}
```

Valor del atributo: el tipo de la transacción, byte.

Descripción del valor del atributo:

```c#
// consensus transaction, special transaction for allocating byte charges
MinerTransaction = 0x00,
//Special transactions for the distribution of assets
IssueTransaction = 0x01,
// special deals for the distribution of small coins
ClaimTransaction = 0x02,
//Special transaction for registration as a book of candidates
EnrollmentTransaction = 0x20,
//Special transactions for asset registration
RegisterTransaction = 0x40,
// contract transaction, which is the most commonly used deal
ContractTransaction = 0x80,
// commissioned by the transaction
AgencyTransaction = 0xb0,
// issue a deal with a smart contract
PublishTransaction = 0xd0,
// Invoke smart contract transactions
InvocationTransaction = 0xd1
```



[Volver arriba](../Transaction.md)
