# AntShares namespace

The AntShares namespace is the API provided by the small-ants blockchain, providing a way to access the block-chain data and manipulate the persistent store. These APIs are divided into two categories.

1, read-only API, contract procedures can be accessed through the API to the entire chain of all the data on the chain, including the complete block and transactions, as well as their every field.

2, read and write API. Smart contracts can modify the status of contracts through such APIs, such as reading and writing persistent storage areas.

Note: The new and deprecated places in this article are the changed to version 2.0 relative to version 1.6.

## read-only API

Query the data from the blockchain API:

| API | Description |
| ----------------------------------- | -------------------- |
| AntShares.Blockchain.GetHeight | Get the current block height |
| AntShares.Blockchain.GetHeader | Find block header by block height or block hash |
| AntShares.Blockchain.GetBlock | Find Blocks by Block Height or Block Hash |
| AntShares.Blockchain.GetTransaction | Find deals via transaction ID |
| AntShares.Blockchain.GetAccount | Get an account based on the hash of the contract script |
| AntShares.Blockchain.GetValidators | `new` Get the public key of the consensus person
AntShares.Blockchain.GetAsset | Find assets based on asset ID
| AntShares.Blockchain.GetContract | `new` Get contract content based on contract hash |

Block class API:

| API | Description |
| ----------------------------------- | -------------------------- |
| AntShares.Header.GetHash | Get the hash of the block |
| AntShares.Header.GetVersion | Get Block Version Number |
| AntShares.Header.GetPrevHash | Get the hash of the previous block |
| AntShares.Header.GetMerkleRoot | Get the root of Merkle Tree for all transactions in that block |
| AntShares.Header.GetTimestamp | Get the timestamp of the block
| AntShares.Header.GetConsensusData | Get consensus data for this block (consensus node-generated pseudo-random number) |
| AntShares.Header.GetNextConsensus | Get the hash value for the next billing contract |
| AntShares.Block.GetTransactionCount | Get the number of transactions in the current block |
| AntShares.Block.GetTransactions | Get all transactions in the current block |
| AntShares.Block.GetTransaction | Get the transaction specified in the current block |

Transaction class API:

| API | Description |
| ----------------------------------- | ---------------------------------------- |
| AntShares.Transaction.GetHash | Get Hash for the current transaction
| AntShares.Transaction.GetType | Get the current transaction type |
| AntShares.Enrollment.GetPublicKey | `deprecated` already replaced with AntShares.Blockchain.GetValidators |
| AntShares.Transaction.GetAttributes | Query all properties of the current transaction |
| AntShares.Transaction.GetInputs | Query all transactions for current transactions
| AntShares.Transaction.GetOutputs | Query all transaction output for current transaction |
| AntShares.Transaction.GetReferences | Query the transaction output referenced by all inputs of the current transaction |
| AntShares.Attribute.GetUsage | Get used in this transaction feature
| AntShares.Attribute.GetData | Get extra data outside of the purpose of this transaction feature |
| AntShares.Input.GetHash | The transaction that is quoted by the transaction
| AntShares.Input.GetIndex | The index of the transaction that is referenced in its all transaction output list |
| AntShares.Output.GetAssetId | Get Asset ID |
| AntShares.Output.GetValue | Get Script Hash |
| AntShares.Output.GetScriptHash | Get the transaction amount

Account class API:

| API | Description |
| ------------------------------- | ------------------ |
| AntShares.Account.GetScriptHash | Get the script hash of the contract account
| AntShares.Account.GetVotes | Get voting information for this contract account to other people |
| AntShares.Account.GetBalance | Get the balance of this asset in the account with the asset ID |

Asset class API:

| API | Description |
| ---------------------------- | ------------------------------------- |
| AntShares.Asset.GetAssetId | Get ID of the asset
| AntShares.Asset.GetAssetType | Get the category of the asset
| AntShares.Asset.GetAmount | Get the total amount of the asset
| AntShares.Asset.GetAvailable | Get the quantity of the asset that has been issued |
| AntShares.Asset.GetPrecision | Get the accuracy of the asset (the minimum number of divisions), the number of digits after the decimal point |
| AntShares.Asset.GetOwner | Get the owner of the asset (public key) |
| AntShares.Asset.GetAdmin | Obtain the administrator (contract address) of the asset and have the right to modify the attributes of the asset (such as total, name, etc.)
| AntShares.Asset.GetIssuer | Obtain the issuer (contract address) of the asset and have the right to issue the asset.

Contract class API:

| API | Description |
| ---------------------------- | -------- |
| AntShares.Contract.GetScript | Get the script for the contract |

Contract class API:

| API | Description |
| ---------------------------- | ------------------------------- |
| AntShares.Storage.GetContext | `new` Get the current store context |
| AntShares.Storage.Get | query operation, in the persistent storage area through the key query the corresponding value |

## read and write API

This type of API will modify the status of the smart contract

| API | Description |
| -------------------------------------- | -------------------------------- |
AntShares.Blockchain.RegisterValidator | `new` Sign up as a
AntShares.Blockchain.CreateAsset | `new` register an asset
AntShares.Blockchain.CreateContract | `new` Announces Smart Contract
| AntShares.Account.SetVotes | Set the voting information for the contract account to other people |
AntShares.Asset.Renew | `new` for asset renewal
AntShares.Contract.Destroy | `new` destroy contract
| AntShares.Storage.Put | Insert operation, insert data in the form of key-value into the persistent storage area |
| AntShares.Storage.Delete | delete operation, in the persistent storage area through the key to delete the corresponding value |
