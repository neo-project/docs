# Neo.SmartContract.Framework.Services

## Class

| Class                                                        | Description                                                  |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [Block](services/Block.md)       | A class representing a block, provides a set of block-specific properties. |
| [Contract](services/Contract.md) | A class representing a contract.                             |
| [Crypto](services/Crypto.md)     | Provides the ECDsa method to verify the signature.           |
| [Iterator](services/Iterator.md) | The customized iterator in the smart contract.               |
| [Notification](services/Notification.md) | The notification sent when the contract is executed.         |
| [Runtime](services/Runtime.md)   | Provides a set of methods during smart contract execution    |
| [Storage](services/Storage.md)   | Provides a set of methods to insert, query, or delete data of a persistent store |
| [StorageContext](services/StorageContext.md) | A class representing storage context of the persistent storage |
| [StorageMap](services/StorageMap.md) | A key-value storage for a specific prefix in the given storage context. |
| [Transaction](services/Transaction.md) | The base class representing the transaction                  |

## Enumeration

| Enumeration                            | Description                                                  |
| -------------------------------------- | ------------------------------------------------------------ |
| [CallFlags](services/CallFlags.md)     | Defines the pattern when invoking contracts                  |
| [FindOptions](services/FindOptions.md) | Defines search options for searching a storage. Used in the  Storage.Find method. |
| [TriggerType](services/TriggerType.md) | Defines the trigger types                                    |

