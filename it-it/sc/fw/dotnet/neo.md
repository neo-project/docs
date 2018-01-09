# NEO Namespace

Il NEO namespace e l'API fornita dalla blockchain NEO, realizzando un modo per accedere ai dati della blockchain e manipolare la memoria persistente. Queste APIs sono divise in due categorie:

1. Registro blockchain. Il contratto puó accedere a tutti i dati dell'intera blockchain attraverso al livello di interoperabilitá, inclusi blocchi e transazioni, cosí come ongiuno dei loro campi.

2. Memoria persistente. Ogni applicazione contratto implementata su NEO ha uno spazio di memmoria al quale puó accedere solo il contratto stesso. Questi metodi forniti possono accedere ai dati nel contratto.

Nota: I tags `New` e `Deprecated` di questo articolo sono cambiamenti alla 2.0 relativi alla versione 1.6.

## Class

| | Class | Description |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Account](neo/Account.md)          | A class representing the Account, providing a method to query the balance.      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Asset](neo/Asset.md)              | A class representing an asset and its data structure.         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Block](neo/Block.md)              | A class representing a block, provides methods to query transactions in the block.  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Blockchain](neo/Blockchain.md)    | Provides a set of methods for accessing blockchain data.    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Contract](neo/Contract.md)        | A class representing a contract.                |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Enrollment](neo/Enrollment.md)    | `New` Represents the data structure of the registration transaction of a bookkeeper. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Header](neo/Header.md)            | Represents the data structure of a block header           |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Runtime](neo/Runtime.md)          | `New` Provides a set of methods during smart contract execution   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Storage](neo/Storage.md)          | Provides a set of methods to insert, query, or delete data of a persistent store   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [StorageContext](neo/StorageContext.md) | `New` A class representing storage context of the persistent store  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Transaction](neo/Transaction.md)  |  The base class representing the transaction            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionAttribute](neo/TransactionAttribute.md) | The data structure representing the transaction attributes          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionInput](neo/TransactionInput.md) | The data structure representing the transaction inputs         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionOutput](neo/TransactionOutput.md) | The data structure representing the transaction outputs         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Validator](neo/Validator.md)      | `New` Provides a set of methods for consensus nodes      |

## Enumeration

|  | Enumeration | Description |
| ---------------------------------------- | ---------------------------------------- | ----------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [StorageContext](neo/StorageContext2.md) | `Deprecated`  Represents the enum of the storage context. |
