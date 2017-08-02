# NEO namespace

The NEO namespace is the API provided by the small-ants blockchain, providing a way to access the block-chain data and manipulate the persistent store. These APIs are divided into two categories.

1. read-only API, contract procedures can be accessed through the API to the entire chain of all the data on the chain, including the complete block and transactions, as well as their every field.

2. read and write API. Smart contracts can modify the status of contracts through such APIs, such as reading and writing persistent storage areas.

Note: The new and deprecated places in this article are the changed to version 2.0 relative to version 1.6.

## read-only API

Query the data from the blockchain API:

| API | Description |
| ----------------------------------- | -------------------- |
| Neo.Blockchain.GetHeight | Get the current block height |
| Neo.Blockchain.GetHeader | Find block header by block height or block hash |
| Neo.Blockchain.GetBlock | Find Blocks by Block Height or Block Hash |
| Neo.Blockchain.GetTransaction | Find deals via transaction ID |
| Neo.Blockchain.GetAccount | Get an account based on the hash of the contract script |
| Neo.Blockchain.GetValidators | `new` Get the public key of the consensus person
Neo.Blockchain.GetAsset | Find assets based on asset ID
| Neo.Blockchain.GetContract | `new` Get contract content based on contract hash |

Block class API:

| API | Description |
| ----------------------------------- | -------------------------- |
| Neo.Header.GetHash | Get the hash of the block |
| Neo.Header.GetVersion | Get Block Version Number |
| Neo.Header.GetPrevHash | Get the hash of the previous block |
| Neo.Header.GetMerkleRoot | Get the root of Merkle Tree for all transactions in that block |
| Neo.Header.GetTimestamp | Get the timestamp of the block
| Neo.Header.GetConsensusData | Get consensus data for this block (consensus node-generated pseudo-random number) |
| Neo.Header.GetNextConsensus | Get the hash value for the next billing contract |
| Neo.Block.GetTransactionCount | Get the number of transactions in the current block |
| Neo.Block.GetTransactions | Get all transactions in the current block |
| Neo.Block.GetTransaction | Get the transaction specified in the current block |

Transaction class API:

| API | Description |
| ----------------------------------- | ---------------------------------------- |
| Neo.Transaction.GetHash | Get Hash for the current transaction
| Neo.Transaction.GetType | Get the current transaction type |
| Neo.Enrollment.GetPublicKey | `deprecated` already replaced with Neo.Blockchain.GetValidators |
| Neo.Transaction.GetAttributes | Query all properties of the current transaction |
| Neo.Transaction.GetInputs | Query all transactions for current transactions
| Neo.Transaction.GetOutputs | Query all transaction output for current transaction |
| Neo.Transaction.GetReferences | Query the transaction output referenced by all inputs of the current transaction |
| Neo.Attribute.GetUsage | Get used in this transaction feature
| Neo.Attribute.GetData | Get extra data outside of the purpose of this transaction feature |
| Neo.Input.GetHash | The transaction that is quoted by the transaction
| Neo.Input.GetIndex | The index of the transaction that is referenced in its all transaction output list |
| Neo.Output.GetAssetId | Get Asset ID |
| Neo.Output.GetValue | Get Script Hash |
| Neo.Output.GetScriptHash | Get the transaction amount

Account class API:

| API | Description |
| ------------------------------- | ------------------ |
| Neo.Account.GetScriptHash | Get the script hash of the contract account
| Neo.Account.GetVotes | Get voting information for this contract account to other people |
| Neo.Account.GetBalance | Get the balance of this asset in the account with the asset ID |

Asset class API:

| API | Description |
| ---------------------------- | ------------------------------------- |
| Neo.Asset.GetAssetId | Get ID of the asset
| Neo.Asset.GetAssetType | Get the category of the asset
| Neo.Asset.GetAmount | Get the total amount of the asset
| Neo.Asset.GetAvailable | Get the quantity of the asset that has been issued |
| Neo.Asset.GetPrecision | Get the accuracy of the asset (the minimum number of divisions), the number of digits after the decimal point |
| Neo.Asset.GetOwner | Get the owner of the asset (public key) |
| Neo.Asset.GetAdmin | Obtain the administrator (contract address) of the asset and have the right to modify the attributes of the asset (such as total, name, etc.)
| Neo.Asset.GetIssuer | Obtain the issuer (contract address) of the asset and have the right to issue the asset.

Contract class API:

| API | Description |
| ---------------------------- | -------- |
| Neo.Contract.GetScript | Get the script for the contract |

Contract class API:

| API | Description |
| ---------------------------- | ------------------------------- |
| Neo.Storage.GetContext | `new` Get the current store context |
| Neo.Storage.Get | query operation, in the persistent storage area through the key query the corresponding value |

## read and write API

This type of API will modify the status of the smart contract

| API | Description |
| -------------------------------------- | -------------------------------- |
Neo.Blockchain.RegisterValidator | `new` Sign up as a
Neo.Blockchain.CreateAsset | `new` register an asset
Neo.Blockchain.CreateContract | `new` Announces Smart Contract
| Neo.Account.SetVotes | Set the voting information for the contract account to other people |
Neo.Asset.Renew | `new` for asset renewal
Neo.Contract.Destroy | `new` destroy contract
| Neo.Storage.Put | Insert operation, insert data in the form of key-value into the persistent storage area |
| Neo.Storage.Delete | delete operation, in the persistent storage area through the key to delete the corresponding value |
