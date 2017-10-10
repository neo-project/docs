# NEO Namespace

De NEO Namespace bevat een API die wordt verschaft door de NEO blockchain. Gebruik van de API maakt het mogelijk om data van de blockchain op te vragen en persistente opslag aan te passen.

> [!Note]
> `Nieww` en `Verouderd` geeft veranderingen tussen versies 1.6 en 2.0 aan.

## Alleen-lezen API

Blockchain Query API:

| API                           | Omschrijving                                            |
| :---------------------------- | :------------------------------------------------------ |
| Neo.Blockchain.GetHeight      | Krijg de huidige blockhoogte                            |
| Neo.Blockchain.GetHeader      | Vind block header a.d.h.v. blockhoogte of blockhash     |
| Neo.Blockchain.GetBlock       | Find block by block Height or block Hash                |
| Neo.Blockchain.GetTransaction | Find transaction via transaction ID                     |
| Neo.Blockchain.GetAccount     | Get an account based on the scripthash of the contract  |
| Neo.Blockchain.GetValidators  | `New` Get the public key of the consensus node          |
| Neo.Blockchain.GetAsset       | Get asset based on asset ID                             |
| Neo.Blockchain.GetContract    | `New` Get contract content based on contract hash       |

Block class API:

| API                           | Omschrijving                                                                          |
| :---------------------------- | :------------------------------------------------------------------------------------ |
| Neo.Header.GetHash            | Krijg de hash van het block                                                           |
| Neo.Header.GetVersion         | Krijg het versienummer van het block                                                  |
| Neo.Header.GetPrevHash        | Krijg de hash van het vorige block                                                    |
| Neo.Header.GetMerkleRoot      | Krijg de Merkle Tree root voor allle transacties in dat block                         |
| Neo.Header.GetTimestamp       | Krijg de tijdstempel van het block                                                    |
| Neo.Header.GetConsensusData   | Krijg consensusdata voor dit block (pseudo-willekeurig getal, gegenereerd door node)  |
| Neo.Header.GetNextConsensus   | Krijg de hashwaarde van het volgende bookkeeper-contract                              |
| Neo.Block.GetTransactionCount | Krijg het aantal transacties in het huidige block                                     |
| Neo.Block.GetTransactions     | Krijg alle transacties in het huidige block                                           |
| Neo.Block.GetTransaction      | Krijg de gespecificeerde transactie in het huidige block                              |

Transaction class API:

| API                           | Omschrijving                                                                          |
| :---------------------------- | :------------------------------------------------------------------------------------ |
| Neo.Transaction.GetHash       | Krijg de hash voor de huidige transactie                                                   
| Neo.Transaction.GetType       | Krijg het huidige transactietype
| Neo.Enrollment.GetPublicKey   | `Verouderd` Vervangen door Neo.Blockchain.GetValidators 
| Neo.Transaction.GetAttributes | Vraag alle eigenschappen van de huidige transactie op
| Neo.Transaction.GetInputs     | Vraag alle inputs voor huidige transacties op
| Neo.Transaction.GetOutputs    | Vraag alle transactie-outputs op voor de huidige transacties
| Neo.Transaction.GetReferences | Vraag de transactie-output op die wordt gerefereerd door alle inputs van huidige transacties 
| Neo.Attribute.GetUsage        | Krijg het nut van de transactie 
| Neo.Attribute.GetData         | Krijg extra data naast het nut van de transactie 
| Neo.Input.GetHash             | Krijg de hash van een gerefereerde vorige transactie 
| Neo.Input.GetIndex            | Krijg de index van de input in de output-lijst van de gerefereerde vorige transactie 
| Neo.Output.GetAssetId         | Krijg het Asset ID 
| Neo.Output.GetValue           | Krijg de Script Hash 
| Neo.Output.GetScriptHash      | Krijg de transactie-hoeveelheid

Account class API:

| API                       | Omschrijving                                                                           |
| :------------------------ | :-----------------------------------------------------------------------------------   |
| Neo.Account.GetScriptHash | Krijg de script hash van de contract-account                                           |
| Neo.Account.GetVotes      | Krijg informatie over de stemmen die deze account heeft uitgebracht                    |
| Neo.Account.GetBalance    | Krijg het saldo van deze asset in de account (geef het asset ID)                       |

Asset class API:

| API                    | Omschrijving                                                                              |
| :--------------------- | :---------------------------------------------------------------------------------------- |
| Neo.Asset.GetAssetId   | Krijg de ID van een asset 
| Neo.Asset.GetAssetType | Krijg de categorie van een asset
| Neo.Asset.GetAmount    | Krijg de totale hoeveelheid van een asset
| Neo.Asset.GetAvailable | Krijg de gedistribueerde hoeveelheid van een asset 
| Neo.Asset.GetPrecision | Krijg de nauwkeurigheid van een asset (het aantal getallen achter de komma)              
| Neo.Asset.GetOwner     | Get the owner of the asset (public key) 
| Neo.Asset.GetAdmin     | Obtain the administrator (contract address) of the asset 
| Neo.Asset.GetIssuer    | Obtain the issuer (contract address) of the asset 

Contract class API:

| API | Description |
| :--------------------- | :------- |
| Neo.Contract.GetScript | Get the scripthash of the contract |

Storage class API:

| API | Description |
| :--------------------- | :------------------------------ |
| Neo.Storage.GetContext | `New` Get the current store context |
| Neo.Storage.Get        | Returns the value in the persistent store based off the key given |

Runtime class API:

| API | Description |
| :----------------------- | :-------------------------------- |
| Neo.Runtime.CheckWitness | `New` Verifies that the calling contract has verified the required script hashes of the transaction/block |
| Neo.Runtime.Notify       | `New` Notifies the client with a notification during smart contract execution      |
| Neo.Runtime.Log          | `New` Notifies the client with a log message during smart contract execution      |

Note: The source code can be found under `NEO` in the `src/neo/SmartContract/StateReader.cs` file.

## Read/Write API

This type of API will modify the status of the smart contract

| API | Description |
| :----------------------------- | :------------------------------- |
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
