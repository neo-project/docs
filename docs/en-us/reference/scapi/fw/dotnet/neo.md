# Neo Namespace

The Neo namespace is the API provided by the Neo blockchain, providing a way to access the block-chain data and manipulate the persistent store. These APIs are divided into these categories:

- Blockchain ledger. The contract can access all the data on the entire blockchain through interops layer, including complete blocks and transactions, as well as each of their fields.
- Native contract. A series of methods of native contracts can be invoked in the smart contract.
- Persistent storage. Each application contract deployed on Neo has a storage space that can only be accessed by the contract itself. These methods provided can access the data in the contract.

## Class

| Class | Description |
| ---------------------------------------- | ---------------------- |
| [Account](neo/Account.md)          | A class representing the Account, providing a method to verify if it is a standard account. |
| [Block](neo/Block.md)              | A class representing a block, provides a set of block-specific properties. |
| [Contract](neo/Contract.md)        | A class representing a contract.                |
| [ContractManagement](neo/ContractManagement.md) | A contract that manages other contracts. |
| [Crypto](neo/Crypto.md) | Provides the ECDsa method to verify the signature. |
| [GAS](neo/Gas.md) | A set of properties and methods of the native contract GasToken. |
| [Helper](neo/Helper.md) | An auxiliary method for the contract storage |
| [Iterator](neo/Iterator.md) | The customized iterator in the smart contract. |
| [Json](neo/Json.md) | A data structure |
| [Ledger](neo/Ledger.md) | A set of properties and methods of the native contract LedgerContract |
| [NameService](neo/NameService.md) | A set of properties and methods of the native contract NameService |
| [NEO](neo/Neo.md) | A set of properties and methods of the native contract NeoToken. |
| [Notification](neo/Notification.md) | The notification sent when the contract is executed. |
| [Oracle](neo/Oracle.md)        |        Provides methods to initiate Oracle requests.        |
| [Policy](neo/Policy.md)        |     Provides methods to access and modify system parameters.     |
| [RoleManagement](neo/RoleManagement.md) | A set of properties and methods of the native contract RoleManagement. |
| [Runtime](neo/Runtime.md)          | Provides a set of methods during smart contract execution   |
| [Storage](neo/Storage.md)          | Provides a set of methods to insert, query, or delete data of a persistent store   |
| [StorageContext](neo/StorageContext.md) | A class representing storage context of the persistent storage |
| [StorageMap](neo/StorageMap.md) | A key-value storage for a specific prefix in the given storage context. |
| [Transaction](neo/Transaction.md)  |  The base class representing the transaction            |

## Enumeration

| Enumeration | Description |
| ---------------------------------------- | ----------------------- |
| [CallFlags](neo/CallFlags.md) | Defines the pattern when invoking contracts |
| [FindOptions](neo/FindOptions.md) | Defines search options for searching a storage. Used in the  Storage.Find method. |
| [OracleResponseCode](neo/OracleResponseCode.md) | Defines the response code types of Oracle |
| [RecordType](neo/RecordType.md) | Defines the DNS types of NameServices |
| [Role](neo/Role.md) | Defines permission types of RoleManagement |
| [StorageFlags](neo/StorageFlags.md) | Represents the property of written data |
| [TriggerType](neo/TriggerType.md) | Defines the trigger types |
