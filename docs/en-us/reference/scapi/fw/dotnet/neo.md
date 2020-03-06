# NEO Namespace

The NEO namespace is the API provided by the Neo blockchain, providing a way to access the block-chain data and manipulate the persistent store. These APIs are divided into two categories:

- Blockchain ledger. The contract can access all the data on the entire blockchain through interops layer, including complete blocks and transactions, as well as each of their fields.

- Persistent storage. Each application contract deployed on NEO has a storage space that can only be accessed by the contract itself. These methods provided can access the data in the contract.

## Class

| Class | Description |
| ---------------------------------------- | ---------------------- |
| [Account](neo/Account.md)          | A class representing the Account, providing a method to verify if it is a standard account. |
| [Block](neo/Block.md)              | A class representing a block, provides a set of block-specific properties. |
| [Blockchain](neo/Blockchain.md)    | Provides a set of methods for accessing blockchain data.    |
| [Contract](neo/Contract.md)        | A class representing a contract.                |
| [Crypto](neo/Crypto.md) | Provides the ECDsa method to verify the signature. |
| [Enumerator](neo/Enumerator.md) | The customized enumerator in the smart contract. |
| [Helper](neo/Helper.md) | An auxiliary method for the contract storage |
| [Iterator](neo/Iterator.md) | The customized iterator in the smart contract. |
| [Json](neo/Json.md) | A data structure |
| [Native](neo/Native.md) | A class representing the native contract on the Neo blockchain. |
| [Notification](neo/Notification.md) | The notification sent when the contract is executed. |
| [Runtime](neo/Runtime.md)          | Provides a set of methods during smart contract execution   |
| [Storage](neo/Storage.md)          | Provides a set of methods to insert, query, or delete data of a persistent store   |
| [StorageContext](neo/StorageContext.md) | A class representing storage context of the persistent storage |
| [StorageFlags](neo/StorageFlags.md) | The property of the written data |
| [StorageMap](neo/StorageMap.md) | A key-value storage for a specific prefix in the given storage context. |
| [Transaction](neo/Transaction.md)  |  The base class representing the transaction            |

## Enumeration

| Enumeration | Description |
| ---------------------------------------- | ----------------------- |
| [CallFlags](neo/CallFlags.md) | Defines the pattern when invoking contracts |
| [TriggerType](neo/TriggerType.md) | Defines the trigger type |
