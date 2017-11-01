# NEO Namespace

De NEO Namespace is de API die wordt verschaft door de NEO blockchain. Gebruik van maakt het mogelijk om data van de blockchain op te vragen en persistente opslag aan te passen. Deze API's zijn verdeeld in twee groepen:

1. **Blockchain ledger**. Het contract heeft toegang tot alle data op de gehele blockchain d.m.v. de interops layer, inclusief complete blocks en transacties en elk veld in deze transacties.
2. **Persistente opslag**. Elk applicatiecontract op NEO heeft opslagruimte die alleen kan worden gebruikt door het contract zelf. De methods in deze groep geven toegang tot de data in het contract.

> [!Note]
> `Nieuw` en `Verouderd` toont veranderingen tussen versies 1.6 en 2.0 aan.

## Class

| | Class | Omschrijving |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Account](neo/Account.md)          | Een class die staat voor de Account, waarmee het saldo opgevraagd kan worden.      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Asset](neo/Asset.md)              | Een class die staat voor een asset en diens datastructuur.         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Block](neo/Block.md)              | Een class die staat voor een block, waarmee transacties in het block opgevraagd kunnen worden.  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Blockchain](neo/Blockchain.md)    | Geeft een set methods voor toegang tot blockchaindata.  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Contract](neo/Contract.md)        | Een class die staat voor een contract.                |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Enrollment](neo/Enrollment.md)    | `Nieuw` Staat voor de datastructuur van de registratietransactie van een Bookkeeper node. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Header](neo/Header.md)            | Staat voor de datastructuur van een block header           |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Runtime](neo/Runtime.md)          | `Nieuw` Geeft een set methods voor tijdens het uitvoeren van een smart contract   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Storage](neo/Storage.md)          | Geeft een set methods om data aan de opslag toe te voegen, toegang te vragen, of data te verwijderen. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [StorageContext](neo/StorageContext.md) | `Nieuw` Een class die staat voor de opslagruimtecontext van de persistente opslag|
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Transaction](neo/Transaction.md)  |  De basis class die staat voor een transactie            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionAttribute](neo/TransactionAttribute.md) | De datastructuur die staat voor transactie-eigenschappen          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionInput](neo/TransactionInput.md) | De datastructuur die staat voor de transactie-inputs         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionOutput](neo/TransactionOutput.md) | De datastructuur die staat voor de transactie-outputs         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Validator](neo/Validator.md)      | `Nieuw` Geeft een set methods voor consensus nodes  |

## Opsomming

|  | Opsomming | Omschrijving |
| ---------------------------------------- | ---------------------------------------- | ----------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [StorageContext](neo/StorageContext2.md) | `Verouderd`  Staat voor de som van de opslagcontext. |
