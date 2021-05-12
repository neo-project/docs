# Neo.SmartContract.Framework.Native

The Neo namespace is the API provided by the Neo blockchain, providing a way to access the block-chain data and manipulate the persistent store. These APIs are divided into these categories:

- Blockchain ledger. The contract can access all the data on the entire blockchain through interops layer, including complete blocks and transactions, as well as each of their fields.
- Native contract. A series of methods of native contracts can be invoked in the smart contract.
- Persistent storage. Each application contract deployed on Neo has a storage space that can only be accessed by the contract itself. These methods provided can access the data in the contract.

## Class

| Class                                   | Description                                                  |
| --------------------------------------- | ------------------------------------------------------------ |
| [Account](neo/Account.md)               | A class representing the Account, providing a method to verify if it is a standard account. |
| [Block](neo/Block.md)                   | A class representing a block, provides a set of block-specific properties. |
| [Contract](neo/Contract.md)             | A class representing a contract.                             |
| [Crypto](neo/Crypto.md)                 | Provides the ECDsa method to verify the signature.           |
| [Helper](neo/Helper.md)                 | An auxiliary method for the contract storage                 |
| [Iterator](neo/Iterator.md)             | The customized iterator in the smart contract.               |
| [Json](neo/Json.md)                     | A data structure                                             |
| [Notification](neo/Notification.md)     | The notification sent when the contract is executed.         |
| [Runtime](neo/Runtime.md)               | Provides a set of methods during smart contract execution    |
| [Storage](neo/Storage.md)               | Provides a set of methods to insert, query, or delete data of a persistent store |
| [StorageContext](neo/StorageContext.md) | A class representing storage context of the persistent storage |
| [StorageMap](neo/StorageMap.md)         | A key-value storage for a specific prefix in the given storage context. |
| [Transaction](neo/Transaction.md)       | The base class representing the transaction                  |

## Native Contract Classes

| Contract Name                                   | Script Hash                                | Description                                                  |
| ----------------------------------------------- | ------------------------------------------ | ------------------------------------------------------------ |
| [ContractManagement](neo/ContractManagement.md) | 0xfffdc93764dbaddd97c48f252a53ea4643faa3fd | The contract that manages contracts                          |
| [CryptoLib](neo/CryptoLib.md)                   | 0x726cb6e0cd8628a1350a611384688911ab75f51b | A contract that integrates cryptographic methods such as hash calculation and signature verification |
| [GasToken](neo/GAS.md)                          | 0xd2a4cff31913016155e38e474a2c06d08be276cf | GAS related contract                                         |
| [LedgerContract](neo/Ledger.md)                 | 0xda65b600f7124ce6c79950c1772a36403104f2be | Blockchain protocol layer contracts                          |
| [NameService](neo/NameService.md)               | 0x7a8fcf0392cd625647907afa8e45cc66872b596b | Neo domain name device contract                              |
| [NeoToken](neo/NEO.md)                          | 0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5 | Neo related contract                                         |
| [OracleContract](neo/Oracle.md)                 | 0xfe924b7cfe89ddd271abaf7210a80a7e11178758 | Oracle contract                                              |
| [PolicyContract](neo/Policy.md)                 | 0xcc5e4edd9f5f8dba8bb65734541df7a1c081c67b | Consensus policy contract                                    |
| [RoleManagement](neo/RoleManagement.md)         | 0x49cf4e5378ffcd4dec034fd98a174c5491e395e2 | Role management contract                                     |
| [StdLib](neo/StdLib.md)                         | 0xacce6fd80d44e1796aa0c2c625e9e4e0ce39efc0 | A contract that integrates methods such as serialization, deserialization, and format conversion |

## Enumeration

| Enumeration                                     | Description                                                  |
| ----------------------------------------------- | ------------------------------------------------------------ |
| [CallFlags](neo/CallFlags.md)                   | Defines the pattern when invoking contracts                  |
| [FindOptions](neo/FindOptions.md)               | Defines search options for searching a storage. Used in the  Storage.Find method. |
| [OracleResponseCode](neo/OracleResponseCode.md) | Defines the response code types of Oracle                    |
| [RecordType](neo/RecordType.md)                 | Defines the DNS types of NameServices                        |
| [Role](neo/Role.md)                             | Defines permission types of RoleManagement                   |
| [StorageFlags](neo/StorageFlags.md)             | Represents the property of written data                      |
| [TriggerType](neo/TriggerType.md)               | Defines the trigger types                                    |

