# Smart Contract Framework

The .NET framework is an encapsulation of the Smart Contract API, which helps .NET programmers obtain the blockchain data, persistent storage data, and NeoVM execution status easily using the classes, methods, and properties of the core Neo module.

`Neo.SmartContract.Framework` mainly provides the following API methods:

+ Interoperability Layer Methods
+ Framework Methods

## Interoperability services layer methods

The interoperability services layer methods are included in the following namespaces: 

+ **Neo.SmartContract.Framework.Services.NEO** 

  The Neo namespace is the API provided by the NEO blockchain, providing a way to access the blockchain data and manipulate the persistent store.

  | Class                                                 | Description                                                  |
  | ----------------------------------------------------- | ------------------------------------------------------------ |
  | [Account](neo/Account.md)                             | Represents the Account, providing a method to query the balance. |
  | [Asset](neo/Asset.md)                                 | Represents an asset and its data structure.                  |
  | [Block](neo/Block.md)                                 | Represents a block. It provides methods to query transactions in the block. |
  | [Blockchain](neo/Blockchain.md)                       | Provides a set of methods for accessing blockchain data.     |
  | [Contract](neo/Contract.md)                           | Represents a contract.                                       |
  | [Header](neo/Header.md)                               | Represents the data structure of a block header              |
  | [InvocationTransaction](neo/InvocationTransaction.md) | Represents the transaction of contract invocation            |
  | [Iterator](neo/Iterator.md)                           | Represents the enumerator                                    |
  | [Runtime](neo/Runtime.md)                             | Provides a set of methods for running smart contracts.       |
  | [Storage](neo/Storage.md)                             | Provides a set of methods to insert, query, or delete data of a persistent store |
  | [StorageContext](neo/StorageContext.md)               | Represents storage context of the persistent store           |
  | [StorageMap](neo/StorageMap.md)                       | Represents the Map data structure                            |
  | [Transaction](neo/Transaction.md)                     | The base class representing the transaction                  |
  | [TransactionAttribute](neo/TransactionAttribute.md)   | The data structure representing the transaction attributes   |
  | [TransactionInput](neo/TransactionInput.md)           | The data structure representing the transaction inputs       |
  | [TransactionOutput](neo/TransactionOutput.md)         | The data structure representing the transaction outputs      |

  | Enumeration                                           | Description                                          |
  | ----------------------------------------------------- | ---------------------------------------------------- |
  | [ContractPropertyState](neo/ContractPropertyState.md) | Represents the state of the smart contract property  |
  | [TriggerType](neo/TriggerType.md)                     | Represents the trigger conditions of smart contracts |

+ **Neo.SmartContract.Framework.Services.System**

  The System namespace is the API provided by the Smart Contract Execution Engine, providing access to the execution environment that accesses the smart contract.

  | Class                                        | Description                                                  |
  | -------------------------------------------- | ------------------------------------------------------------ |
  | [ExecutionEngine](System/ExecutionEngine.md) | Represents the execution engine of the virtual machine, allowing access to the caller of the contract and the execution container. |

## Framework methods

In addition to calling methods from the Interoperability service layer, smart contracts can also call methods provided by the framework. These methods are found within `Neo.SmartContract.Framework`.

### SmartContract class methods

By inheriting the `SmartContract` class you can use a number of hash algorithms and signature methods it provides.

| Name                                                         | Description                                                |
| ------------------------------------------------------------ | ---------------------------------------------------------- |
| Sha1(byte[])                                                 | Hashes the input bytes using SHA1                          |
| Sha256(byte[])                                               | Hashes the input bytes using SHA256                        |
| Hash160(byte[])                                              | Hashes the input bytes using SHA256, followed by RIPEMD160 |
| Hash256(byte[])                                              | Hashes the input bytes twice using SHA256                  |
| VerifySignature(byte[] signature, byte[] pubkey)             | Verifies the signature using the given pubkey              |
| VerifySignature(byte[] message, byte[] signature, byte[] pubkey); | Verifies the signature                                     |
| VerifySignatures(byte[][] signature, byte[][] pubkey);       | Verifies the signatures                                    |

### Helper extension methods

This table lists a set of extension methods provided by the Helper class in Neo smart contract framwork. 

|                                         | Methods                                                | Description                                                  |
| --------------------------------------- | ------------------------------------------------------ | ------------------------------------------------------------ |
| Conversion between different data types |                                                        |                                                              |
|                                         | byte[] AsByteArray(this source)                        | Source data => byte[]：<br />byte, byte[], sbyte, sbyte[], BigInteger, string, |
|                                         | byte[] HexToBytes(this string hex)                     | Hex string => byte[]                                         |
|                                         | BigInteger AsBigInteger(this byte[] source)            | byte[] => BigInteger                                         |
|                                         | BigInteger ToBigInteger(this source)                   | byte[] => BigInteger<br />string => BigInteger               |
|                                         | string AsString(this byte[] source)                    | byte[] => string                                             |
|                                         | byte ToByte(this source)                               | BigInteger => byte<br />int => byte                          |
|                                         | byte[] ToScriptHash(this string address)               | Account address => ScriptHash                                |
| Byte array related                      |                                                        |                                                              |
|                                         | byte[] Concat(this byte[] first, byte[] second)        | Concatenate 2 byte arrays                                    |
|                                         | byte[] Range(this byte[] source, int index, int count) | Returns a portion of the byte array, params: index, count    |
|                                         | byte[] Take(this byte[] source, int count)             | Returns the left-most X bytes from the byte array，params: count |
|                                         | byte[] Last(this byte[] source, int count)             | Returns the right-most X bytes from the byte array，params: count |
|                                         | byte[] Reverse(this byte[] source)                     | Reverses the byte array                                      |
| Serialization and Deserialization       |                                                        |                                                              |
|                                         | byte[] Serialize(this object source)                   | Converts the object into a byte array                        |
|                                         | object Deserialize(this byte[] source)                 | Converts an byte array into an object                        |