# NEO Namespace

Il NEO Namespace contiene un API fornita dalla blockchain NEO. I metodi delle API permettono di interrogare la blockchain e la manipolazione della memoria persistente.

Nota: I tags `New` e `Deprecated` denotano cambiamenti tra la versione 1.6 e la versione 2.0.

## API di Sola Lettura

Blockchain Query API:

| API                           | Descrizione                                             |
| ----------------------------- | ------------------------------------------------------- |
| Neo.Blockchain.GetHeight      | Ottieni l'altezza del blocco corrente                            |
| Neo.Blockchain.GetHeader      | Trova l'intestazione del blocco tramite l'altezza del blocco o l'hash del blocco         |
| Neo.Blockchain.GetBlock       | Trova il blocco tramite l'altezza del blocco o l'hash del blocco                |
| Neo.Blockchain.GetTransaction | Trova la transazione tramite l'ID della transazione                     |
| Neo.Blockchain.GetAccount     | Ottieni un account basato sullo scripthash del contratto  |
| Neo.Blockchain.GetValidators  | Ottieni la `New` chiave pubblica del Consensus Node          |
| Neo.Blockchain.GetAsset       | Ottieni assets in base all'ID dell'asset                             |
| Neo.Blockchain.GetContract    | Ottieni il `New` contenuto del contratto basato sull'hash del contratto       |

Classe API del Blocco:

| API                           | Descrizione |
| ----------------------------- | -------------------------- |
| Neo.Header.GetHash            | Ottieni l'hash del blocco |
| Neo.Header.GetVersion         | Ottieni il numero di versione del blocco |
| Neo.Header.GetPrevHash        | Ottieni l'hash del precedente blocco |
| Neo.Header.GetMerkleRoot      | ottieni la radice Merkle Tree per tutte le transazioni in quel blocco |
| Neo.Header.GetTimestamp       | Ottieni il timestamp del blocco |
| Neo.Header.GetConsensusData   | Ottieni dati di consenso per questo blocco (pseudo numeri generati casualmente dal consensus node) |
| Neo.Header.GetNextConsensus   | Ottieni il valore hash del prossimo contratto bokkeeper |
| Neo.Block.GetTransactionCount | Ottieni il numero delle transazioni nel blocco corrente |
| Neo.Block.GetTransactions     | Ottieni tutte le transazioni nel blocco corrente           |
| Neo.Block.GetTransaction      | Ottieni la transazione specificata nel blocco corrente  |

Classe di transazione API:

| API | Descrizione |
| ----------------------------- | ---------------------------------------- |
| Neo.Transaction.GetHash       | Get Hash for the current transaction |
| Neo.Transaction.GetType       | Get the current transaction type |
| Neo.Enrollment.GetPublicKey   | `Deprecated` Replaced with Neo.Blockchain.GetValidators |
| Neo.Transaction.GetAttributes | Query all properties of the current transaction |
| Neo.Transaction.GetInputs     | Query all transactions for current transactions
| Neo.Transaction.GetOutputs    | Query all transaction output for current transaction |
| Neo.Transaction.GetReferences | Query the transaction output referenced by all inputs of the current transaction |
| Neo.Attribute.GetUsage        | Get purpose of transaction |
| Neo.Attribute.GetData         | Get extra data outside of the purpose of transaction |
| Neo.Input.GetHash             | Get the hash of the referenced previous transaction |
| Neo.Input.GetIndex            | The index of the input in the output list of the referenced previous transaction |
| Neo.Output.GetAssetId         | Get Asset ID |
| Neo.Output.GetValue           | Get Script Hash |
| Neo.Output.GetScriptHash      | Get the transaction amount |

Account class API:

| API | Description |
| ------------------------- | ------------------ |
| Neo.Account.GetScriptHash | Get the script hash of the contract account |
| Neo.Account.GetVotes      | Get information of the votes that this account has casted |
| Neo.Account.GetBalance    | Get the balance of this asset in the account given the asset ID |

Asset class API:

| API | Description |
| ---------------------------- | ------------------------------------- |
| Neo.Asset.GetAssetId   | Get ID of the asset |
| Neo.Asset.GetAssetType | Get the category of the asset |
| Neo.Asset.GetAmount    | Get the total amount of the asset |
| Neo.Asset.GetAvailable | Get the quantity of the asset that has been issued |
| Neo.Asset.GetPrecision | Get the number of divisions for this asset, the number of digits after the decimal point |
| Neo.Asset.GetOwner     | Get the owner of the asset (public key) |
| Neo.Asset.GetAdmin     | Obtain the administrator (contract address) of the asset |
| Neo.Asset.GetIssuer    | Obtain the issuer (contract address) of the asset |

Contract class API:

| API | Description |
| ---------------------- | -------- |
| Neo.Contract.GetScript | Get the scripthash of the contract |

Storage class API:

| API | Description |
| ---------------------- | ------------------------------- |
| Neo.Storage.GetContext | `New` Get the current store context |
| Neo.Storage.Get        | Returns the value in the persistent store based off the key given |

Runtime class API:

| API | Description |
| ------------------------ | --------------------------------- |
| Neo.Runtime.CheckWitness | `New` Verifies that the calling contract has verified the required script hashes of the transaction/block |
| Neo.Runtime.Notify       | `New` Notifies the client with a notification during smart contract execution      |
| Neo.Runtime.Log          | `New` Notifies the client with a log message during smart contract execution      |

Note: The source code can be found under `NEO` in the `src/neo/SmartContract/StateReader.cs` file.

## Read/Write API

This type of API will modify the status of the smart contract

| API | Description |
| ------------------------------ | -------------------------------- |
| Neo.Account.SetVotes           | Set the voting information of this account |
| Neo.Validator.Register         | `New` Register as a bookkeeper |
| Neo.Asset.Create               | `New` Register a new asset |
| Neo.Asset.Renew                | `New` Renew an asset |
| Neo.Contract.Create            | `New` Publish a smart contract |
| Neo.Contract.Migrate           | `New` Migrate/Renew a smart contract |
| Neo.Contract.Destroy           | `New` Destroy a smart contract |
| Neo.Contract.GetStorageContext | `New` Get the storage context of the contract |
| Neo.Storage.Put                | Inserts a value into the persistent store based off the given key |
| Neo.Storage.Delete             | Deletes a value from the persistent store based off the given key |

Note: The source code for the above API can be found under `NEO` in the `src/neo/SmartContract/StateMachine.cs` file.
