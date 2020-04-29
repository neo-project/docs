# Smart Contract .NET framework

The .NET Framework is an encapsulation of the Smart Contract API so that .NET programmers can use the classes, methods, and properties of .NET directly to interact with the API to obtain blockchain data, storage data and so on.

## Interoperability Layer Methods

The namespace for interoperability layer is divided into `Neo.SmartContract.Framework.Services.NEO` and `Neo.SmartContract.Framework.Services.System`. Click on the links for more details.

| Namespace                  | description                              |
| -------------------------- | ---------------------------------------- |
| [Neo](dotnet/neo.md)       | The NEO namespace is the API provided by the NEO blockchain, providing a way to access the blockchain data and manipulate the persistent store. |
| [System](dotnet/system.md) | System namespace is the API provided by the Smart Contract Execution Engine (NeoVM), which provides access to the execution environment. |

## Framework Methods

In addition to calling methods from the Interoperability layer, smart contracts can also call methods provided by the framework. These methods are found within `Neo.SmartContract.Framework` and can be called directly by smart contracts.

### SmartContract Class Methods

The `SmartContract` class provides us with the hash algorithms and signature methods.

| Name                                             | Description                                                |
| ------------------------------------------------ | ---------------------------------------------------------- |
| Sha1(byte[])                                     | Hashes the input bytes using SHA1                          |
| Sha256(byte[])                                   | Hashes the input bytes using SHA256                        |
| Hash160(byte[])                                  | Hashes the input bytes using SHA256, followed by RIPEMD160 |
| Hash256(byte[])                                  | Hashes the input bytes twice using SHA256                  |
| VerifySignature(byte[] signature, byte[] pubkey) | Verifies the signature using the given pubkey              |

**Note:** These methods are available through inheritance. If you can't find these methods, make sure your class inherits from the SmartContract class.

### Serialization and Deserialization

You can use extension methods in order to persist and retrieve objects from the SmartContract storage.


| Name                         | Description                              |
| ---------------------------- | ---------------------------------------- |
| Serialize(this object[])  | Converts the object array into a byte array                |
| Deserialize(this byte[]) | Converts an byte array into an object array |

You can find an example [here](https://github.com/Red4Sec/NEO-SmartVote/blob/master/CSharp/SmartVote.cs).

### Byte Array Helper Methods

The methods below are helper methods for byte arrays provided by the .NET framework's Helper class.

| Name                         | Description                                                  |
| ---------------------------- | ------------------------------------------------------------ |
| Concat(this byte[], byte[])  | Concatenate 2 byte arrays                                    |
| Range(this byte[], int, int) | Returns a portion of the byte array, params: index, count    |
| Take(this byte[], int)       | Returns the left-most X bytes from the byte array，params: count |
