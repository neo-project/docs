# System Namespace

The interop service layer provides APIs for smart contracts to access the blockchain data, including the block information, transaction information, contract information, asset information, etc. Besides, the interop service layer provides the persistence capability for each contract.

**Binary API**:
| API                           | Description                              |
|--|--|
| System.Binary.Serialize| Convert StackItem to byte array     |
| System.Binary.Deserialize | Convert byte array to StackItem             |

**BlockChain API**:
| API                           | Description                              |
|--|--|
| System.Blockchain.GetHeight | Get the height of the current block           |
| System.Blockchain.GetBlock | Get a block with the hash or block height |
| System.Blockchain.GetTransaction | Get a transaction with the txid |
|System.Blockchain.GetTransactionHeight|Get the height of the block where the transaction included with the txid|
|System.Blockchain.GetTransactionFromBlock|Get a transaction with the txid in the block|
|System.Blockchain.GetContract|Get a contract with the hash|

**Contract API**:
| API                           | Description                              |
|--|--|
|System.Contract.Create|Deploy a contract|
|System.Contract.Update|Upgrade a contract|
|System.Contract.Destroy|Destroy a contract|
|System.Contract.Call|Invoke a contract|
|System.Contract.CallEx|Invoke a contract with the Flag|
|System.Contract.IsStandard|Check whether the contract is a standard contract|

**Enumerator API**:
| API                           | Description                              |
|--|--|
|System.Enumerator.Create|Create a enumerator|
|System.Enumerator.Next|Check if the enumerator has more element|
|System.Enumerator.Value|Get the current value of the enumerator|
|System.Enumerator.Concat|Concat two enumerators|

**Iterator API**:
| API                           | Description                              |
|--|--|
|System.Iterator.Create|Create an iterator|
|System.Iterator.Key|Get the current key of the iterator|
|System.Iterator.Keys|Get all keys of the iterator|
|System.Iterator.Values|Get all values of the iterator|
|System.Iterator.Concat|Concat two iterators|

**Json API**:
| API                           | Description                              |
|--|--|
|System.Json.Serialize|Serialize a stack item to byte array|
|System.Json.Deserialize|Convert json object to stack item|

**Runtime API**:
| API                           | Description                              |
|--|--|
|System.Runtime.Platform|Get the platform information of the contract being executed|
|System.Runtime.GetTrigger|Get the triggering condition of the contract|
|System.Runtime.GetTime|Get the timestamp of the current block |
|System.Runtime.GetScriptContainer|Get the script container of the contract|
|System.Runtime.GetExecutingScriptHash|Get the scripthash of the executing smart contract|
|System.Runtime.GetCallingScriptHash|Get the scripthash of the caller for this smart contract|
|System.Runtime.GetEntryScriptHash|Get the scripthash of the entry point for the smart contract (the starting point of the contract call chain)|
|System.Runtime.CheckWitness|Verify whether the container calling the contract is signed by the<br/>script hash of the specific account|
|System.Runtime.GetInvocationCounter|Get invocation count of the current contract|
|System.Runtime.Log|Record the log|
|System.Runtime.Notify|Notify the client executing the contract|
|System.Runtime.GetNotifications|Get notifications of a contract|

**Storage API**:
| API                           | Description                              |
|--|--|
|System.Storage.GetContext|Get storage context of the current contract|
|System.Storage.GetReadOnlyContext|Get storage context of the current contract in read-only mode|
|System.Storage.Get|Get value from the storage by key|
|System.Storage.Find|Find the data in the storage area of the current storage context with the specified prefix |
|System.Storage.Put|Put key-value into storage based on the storage context|
|System.Storage.PutEx|Put Key-Value into the storage based on the storage context and the flag|
|System.Storage.Delete|Delete the stored Key-Value data from the storage area by the Key|
|System.StorageContext.AsReadOnly|Set the current context to read-only mode|

> [!Note]
>
> The source code for the API above can be found under `Neo` in the `src\neo\SmartContract\InteropService.cs` file.