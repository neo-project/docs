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

|                                          | Name                                     | Description                              |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Sha1(byte[])                             | Hashes the input bytes using SHA1        |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Sha256(byte[])                           | Hashes the input bytes using SHA256      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Hash160(byte[])                          | Hashes the input bytes using SHA256, followed by RIPEMD160 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Hash256(byte[])                          | Hashes the input bytes twice using SHA256 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | VerifySignature(byte[] pubkey, byte[] signature) | Verifies the signature using the given pubkey |

### Byte Array Helper Methods

The methods below are helper methods for byte arrays provided by the .NET framework's Helper class.

|                                          | Name                         | Description                              |
| ---------------------------------------- | ---------------------------- | ---------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Concat(this byte[], byte[])  | Concatenate 2 byte arrays                |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Range(this byte[], int, int) | Returns a portion of the byte array, params: index, count |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Take(this byte[], int)       | Returns the left-most X bytes from the byte array，params: count |