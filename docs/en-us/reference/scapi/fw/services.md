# Neo.SmartContract.Framework.Services

## Class

| Class                                                        | Description                                                  |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [Block](Neo.SmartContract.Framework.Services/Block.md)       | A class representing a block, provides a set of block-specific properties. |
| [Contract](Neo.SmartContract.Framework.Services/Contract.md) | A class representing a contract.                             |
| [Crypto](Neo.SmartContract.Framework.Services/Crypto.md)     | Provides the ECDsa method to verify the signature.           |
| [Iterator](Neo.SmartContract.Framework.Services/Iterator.md) | The customized iterator in the smart contract.               |
| [Notification](Neo.SmartContract.Framework.Services/Notification.md) | The notification sent when the contract is executed.         |
| [Runtime](Neo.SmartContract.Framework.Services/Runtime.md)   | Provides a set of methods during smart contract execution    |
| [Storage](Neo.SmartContract.Framework.Services/Storage.md)   | Provides a set of methods to insert, query, or delete data of a persistent store |
| [StorageContext](Neo.SmartContract.Framework.Services/StorageContext.md) | A class representing storage context of the persistent storage |
| [StorageMap](Neo.SmartContract.Framework.Services/StorageMap.md) | A key-value storage for a specific prefix in the given storage context. |
| [Transaction](Neo.SmartContract.Framework.Services/Transaction.md) | The base class representing the transaction                  |

## Enumeration

| Enumeration                                                  | Description                                                  |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [CallFlags](Neo.SmartContract.Framework.Service/CallFlags.md) | Defines the pattern when invoking contracts                  |
| [FindOptions](Neo.SmartContract.Framework.Service/FindOptions.md) | Defines search options for searching a storage. Used in the  Storage.Find method. |
| [StorageFlags](Neo.SmartContract.Framework.Service/StorageFlags.md) | Represents the property of written data                      |
| [TriggerType](Neo.SmartContract.Framework.Service/TriggerType.md) | Defines the trigger types                                    |

