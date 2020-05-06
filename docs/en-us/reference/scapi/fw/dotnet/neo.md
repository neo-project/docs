# Neo Namespace

The Neo namespace is the API provided by the Neo blockchain, providing a way to access the block-chain data and manipulate the persistent store. These APIs are divided into two categories:

- Blockchain ledger. The contract can access all the data on the entire blockchain through interops layer, including complete blocks and transactions, as well as each of their fields.

- Persistent store. Each application contract deployed on Neo has a storage space that can only be accessed by the contract itself. These methods provided can access the data in the contract.

## Class

| Class | Description |
| ---------------------------------------- | ---------------------- |
| [Account](neo/Account.md)          | Represents the Account, providing a method to query the balance.      |
| [Asset](neo/Asset.md)              | Represents an asset and its data structure.         |
| [Block](neo/Block.md)              | Represents a block. It provides methods to query transactions in the block. |
| [Blockchain](neo/Blockchain.md)    | Provides a set of methods for accessing blockchain data.    |
| [Contract](neo/Contract.md)        | Represents a contract.                |
| [Header](neo/Header.md)            | Represents the data structure of a block header           |
| [InvocationTransaction](neo/InvocationTransaction.md) | Represents the transaction of contract invocation |
| [Iterator](neo/Iterator.md)                           | Represents the enumerator |
| [Runtime](neo/Runtime.md)                             | Provides a set of methods for running smart contracts. |
| [Storage](neo/Storage.md)          | Provides a set of methods to insert, query, or delete data of a persistent store   |
| [StorageContext](neo/StorageContext.md) | Represents storage context of the persistent store |
| [StorageMap](neo/StorageMap.md) | Represents the Map data structure |
| [Transaction](neo/Transaction.md)  |  The base class representing the transaction            |
| [TransactionAttribute](neo/TransactionAttribute.md) | The data structure representing the transaction attributes          |
| [TransactionInput](neo/TransactionInput.md) | The data structure representing the transaction inputs         |
| [TransactionOutput](neo/TransactionOutput.md) | The data structure representing the transaction outputs         |

## Enumeration

| Enumeration                                           | Description                                          |
| ----------------------------------------------------- | ---------------------------------------------------- |
| [ContractPropertyState](neo/ContractPropertyState.md) | Represents the state of the smart contract property  |
| [TriggerType](neo/TriggerType.md)                     | Represents the trigger conditions of smart contracts |