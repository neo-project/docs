# Smart Contract API Reference

The NEO Smart Contract API expands the capabilities of the Smart Contract to access the blockchain data, manipulate persistent storage, and query the execution environment. It is part of the Neo Virtual Machine (NeoVM) Interoperability Service Layer.

In addition to the following smart contract APIs, Neo3 also introduces a number of native contracts. See [Neo Native Contracts](native.md).

For more information on how to use the framework to easily call APIs in high-level languages, see [Smart Contracts Framework](fw.md).

**Binary API**:

| API                        | Description                                         |
| -------------------------- | --------------------------------------------------- |
| System.Binary.Base64Decode | Decodes the base64-encoded string into byte array   |
| System.Binary.Base64Encode | Encodes the byte array into Base64 string           |
| System.Binary.Serialize    | Serializes stack elements into byte arrays          |
| System.Binary.Deserialize  | Deserializes the byte array to stack elements       |
| System.Binary.Base58Decode | Decodes the Base58 encoded string into a byte array |
| System.Binary.Base58Encode | Encodes the byte array into base58-encoded string   |
| System.Binary.Itoa         | Converts integers to strings                        |
| System.Binary.Atoi         | Converts strings to integers                        |

**Contract API**:

| API                                   | Description                                                  |
| ------------------------------------- | ------------------------------------------------------------ |
| System.Contract.Call                  | Invokes the contract                                         |
| System.Contract.CallNative            | Invokes the native contract                                  |
| System.Contract.IsStandard            | Determines whether the contract is a standard contract or multi-signed contract |
| System.Contract.GetCallFlags          | Gets the execution permissions for the current context       |
| System.Contract.CreateStandardAccount | Creates a standard account                                   |
| System.Contract.NativeOnPersist       | Trigger the OnPersist method of native contract              |
| System.Contract.NativePostPersist     | Trigger the PostPersist method of native contract            |

**Crypto API**:

| API                                        | Description                                                  |
| ------------------------------------------ | ------------------------------------------------------------ |
| Neo.Crypto.RIPEMD160                       | Calculates the RIPEMD160 hash value of stack elements        |
| Neo.Crypto.SHA256                          | Calculates the Sha256 hash value of stack elements           |
| Neo.Crypto.VerifyWithECDsaSecp256r1        | Verifies the signature using the Secp256r1 curve             |
| Neo.Crypto.VerifyWithECDsaSecp256k1        | Verifies the signature using the Secp256k1 curve             |
| Neo.Crypto.CheckMultisigWithECDsaSecp256r1 | Verifies multi-party signatures using the Secp256r1 curve    |
| Neo.Crypto.CheckMultisigWithECDsaSecp256k1 | Verifies the multi-party signatures using the Secp256k1 curve |

**Iterator API**:

| API                    | Description                      |
| ---------------------- | -------------------------------- |
| System.Iterator.Create | Creates a iterator               |
| System.Iterator.Next   | Moves the iterator flow to next  |
| System.Iterator.Values | Gets all the values of iterators |

**Json API**:

| API                     | Description                                    |
| ----------------------- | ---------------------------------------------- |
| System.Json.Serialize   | Serializes the stack elements to byte array    |
| System.Json.Deserialize | Deserializes the Json object to stack elements |

**Runtime API**:

| API                                   | Description                                                  |
| ------------------------------------- | ------------------------------------------------------------ |
| System.Runtime.Platform               | Gets information of the platform that executes the smart contract. |
| System.Runtime.GetTrigger             | Gets the trigger condition for the smart contract            |
| System.Runtime.GetTime                | Gets the timestamp of the current block                      |
| System.Runtime.GetScriptContainer     | Gets the script container of the smart contract (the original trigger) |
| System.Runtime.GetExecutingScriptHash | Gets the hash of the script executed by the smart contract   |
| System.Runtime.GetCallingScriptHash   | Gets the script hash of the caller of the smart contract     |
| System.Runtime.GetEntryScriptHash     | Gets the script hash of the entry point of the smart contract (the starting point of the contract invocation chain) |
| System.Runtime.CheckWitness           | Verifies that whether the container calling the contract is signed by the specified script hash account |
| System.Runtime.GetInvocationCounter   | Gets the invocation count of the current contract            |
| System.Runtime.Log                    | Records the contract log information                         |
| System.Runtime.Notify                 | Records the contract notifications                           |
| System.Runtime.GetNotifications       | Gets all notifications executed by a contract                |
| System.Runtime.GasLeft                | Gets the number of remaining GAS                             |

**Storage API**:

| API                               | Description                                                  |
| --------------------------------- | ------------------------------------------------------------ |
| System.Storage.GetContext         | Gets the context of the current contract storage             |
| System.Storage.GetReadOnlyContext | Gets the context of the current contract storage in read-only mode |
| System.StorageContext.AsReadOnly  | Changes the current context to read-only mode                |
| System.Storage.Get                | Gets the corresponding value from the storage.               |
| System.Storage.Find               | Finds the specified prefix content in the context of the current storage. |
| System.Storage.Put                | Writes a Key to the storage  based on the storage context    |
| System.Storage.PutEx              | Writes a Key to the storage according to the storage context and flag. |
| System.Storage.Delete             | Deletes the Key from the storage based on the Key value      |

> [!Note]
>
> The source code of above API can be found under the path [src\neo\SmartContract](https://github.com/neo-project/neo/tree/master/src/neo/SmartContract) of Neo project.

