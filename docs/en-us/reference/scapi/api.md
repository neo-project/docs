# Smart Contract API Reference

The NEO Smart Contract API expands the capabilities of the Smart Contract to access the blockchain data, manipulate persistent storage, and query the execution environment. It is part of the Neo Virtual Machine (NeoVM) Interoperability Service Layer.

In addition to the following smart contract APIs, Neo3 also introduces a number of native contracts. See [Neo Native Contracts](native.md).

For more information on how to use the framework to easily call APIs in high-level languages, see [Smart Contracts Framework](fw.md).

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

**Iterator API**:

| API                    | Description                      |
| ---------------------- | -------------------------------- |
| System.Iterator.Create | Creates a iterator               |
| System.Iterator.Next   | Moves the iterator flow to next  |
| System.Iterator.Values | Gets all the values of iterators |

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

