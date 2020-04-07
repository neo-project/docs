# System Namespace

The interop service layer provides APIs for smart contracts to access the blockchain data, including the block information, transaction information, contract information, asset information, etc. Besides, the interop service layer provides the persistent storage for each contract.

**Binary API**:

| API                           | Description                              |
|--|--|
| System.Binary.Serialize| Converts StackItem to byte array    |
| System.Binary.Deserialize | Converts byte array to StackItem            |

**BlockChain API**:

| API                           | Description                              |
|--|--|
| System.Blockchain.GetHeight | Gets the height of the current block          |
| System.Blockchain.GetBlock | Gets a block with the hash or block height |
| System.Blockchain.GetTransaction | Gets a transaction with the txid |
|System.Blockchain.GetTransactionHeight|Gets the height of the block where the transaction included with the txid|
|System.Blockchain.GetTransactionFromBlock|Gets a transaction with the txid in the block|
|System.Blockchain.GetContract|Gets a contract with the hash|

**Contract API**:

| API                           | Description                              |
|--|--|
|System.Contract.Create|Deploys a contract|
|System.Contract.Update|Upgrades a contract|
|System.Contract.Destroy|Destroys a contract|
|System.Contract.Call|Invokes a contract|
|System.Contract.CallEx|Invokes a contract with the Flag|
|System.Contract.IsStandard|Checks whether the contract is a standard contract|

**Enumerator API**:

| API                           | Description                              |
|--|--|
|System.Enumerator.Create|Creates a enumerator|
|System.Enumerator.Next|Checks if the enumerator has more element|
|System.Enumerator.Value|Gets the current value of the enumerator|
|System.Enumerator.Concat|Concats two enumerators|

**Iterator API**:

| API                           | Description                              |
|--|--|
|System.Iterator.Create|Creates an iterator|
|System.Iterator.Key|Gets the current key of the iterator|
|System.Iterator.Keys|Gets all keys of the iterator|
|System.Iterator.Values|Gets all values of the iterator|
|System.Iterator.Concat|Concats two iterators|

**Json API**:

| API                           | Description                              |
|--|--|
|System.Json.Serialize|Serializes a stack item to byte array|
|System.Json.Deserialize|Converts json object to stack item|

**Runtime API**:

| API                           | Description                              |
|--|--|
|System.Runtime.Platform|Gets the platform information of the contract being executed|
|System.Runtime.GetTrigger|Gets the triggering condition of the contract|
|System.Runtime.GetTime|Gets the timestamp of the current block |
|System.Runtime.GetScriptContainer|Gets the script container of the contract|
|System.Runtime.GetExecutingScriptHash|Gets the scripthash of the executing smart contract|
|System.Runtime.GetCallingScriptHash|Gets the scripthash of the caller for this smart contract|
|System.Runtime.GetEntryScriptHash|Gets the scripthash of the entry point for the smart contract (the starting point of the contract call chain)|
|System.Runtime.CheckWitness|Verifies whether the container calling the contract is signed by the<br/>script hash of the specific account|
|System.Runtime.GetInvocationCounter|Gets invocation count of the current contract|
|System.Runtime.Log|Records the log|
|System.Runtime.Notify|Notifies the client executing the contract|
|System.Runtime.GetNotifications|Gets notifications of a contract|
|System.Runtime.GasLeft|Gets the unconsumed gas|

**Storage API**:

| API                           | Description                              |
|--|--|
|System.Storage.GetContext|Gets storage context of the current contract|
|System.Storage.GetReadOnlyContext|Gets storage context of the current contract in read-only mode|
|System.Storage.AsReadOnly|Sets the current context to read-only mode|
|System.Storage.Get|Gets value from the storage by key|
|System.Storage.Find|Finds the data in the storage area of the current storage context with the specified prefix |
|System.Storage.Put|Puts key-value into storage based on the storage context|
|System.Storage.PutEx|Puts Key-Value into the storage based on the storage context and the flag|
|System.Storage.Delete|Deletes the stored Key-Value data from the storage area by the Key|

> [!Note]
>
> The source code for the API above can be found under `Neo` in the `src\neo\SmartContract\InteropService.cs` file.