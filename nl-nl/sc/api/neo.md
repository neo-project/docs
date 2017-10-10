# NEO Namespace

De NEO Namespace is de API die wordt verschaft door de NEO blockchain. Gebruik van de API maakt het mogelijk om data van de blockchain op te vragen en persistente opslag aan te passen.

> [!Note]
> `Nieuw` en `Verouderd` geeft veranderingen tussen versies 1.6 en 2.0 aan.

## Alleen-lezen API

Blockchain Query API:

| API                           | Omschrijving                                             |
| :---------------------------- | :------------------------------------------------------  |
| Neo.Blockchain.GetHeight      | Krijg de huidige blockhoogte                             |
| Neo.Blockchain.GetHeader      | Vind block header a.d.h.v. blockhoogte of blockhash      |
| Neo.Blockchain.GetBlock       | Vind block a.d.h.v. blockhoogte of blockhash             |
| Neo.Blockchain.GetTransaction | Vind transactie via transactie-ID                        |
| Neo.Blockchain.GetAccount     | Krijg een account a.d.h.v. de scripthash van het contract|
| Neo.Blockchain.GetValidators  | `Nieuw` Krijg de public key van de consensus node        |
| Neo.Blockchain.GetAsset       | Krijg een asset a.d.h.v. asset ID                        |
| Neo.Blockchain.GetContract    | `Nieuw` Krijg contractinhoud a.d.h.v. contracthash       |

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
| Neo.Asset.GetOwner     | Krijg de eigenaar van een asset (a.d.h.v. public key)
| Neo.Asset.GetAdmin     | Krijg de administrator (contract adres) van een asset
| Neo.Asset.GetIssuer    | Krijg de verstrekker (contract adres) van een asset 

Contract class API:

| API                    | Omschrijving                         |
| :--------------------- | :----------------------------------- |
| Neo.Contract.GetScript | Krijg de scripthash van het contract |

Storage class API:

| API                    | Omschrijving                                                             |
| :--------------------- | :----------------------------------------------------------------------- |
| Neo.Storage.GetContext | `Nieuw` Krijg de huidige opslagcontext                                   |
| Neo.Storage.Get        | Geeft als return de waarde in persistente opslag a.d.h.v. de gegeven key |

Runtime class API:

| API                      | Omschrijving         |
| :----------------------- | :-------------------------------- |
| Neo.Runtime.CheckWitness | `Nieuw` Bevestigd dat het contract dat een aanvraag doet de benodigde script hashes van de transactie/het block heeft geverifiëerd 
| Neo.Runtime.Notify       | `Nieuw` Toont een notificatie in de client wanneer het smart contract wordt uitgevoerd |
| Neo.Runtime.Log          | `Nieuw` Toont een log-bericht wanneer het smart contract wordt uitgevoerd|

> [!Note]
> De broncode kan worden gevonden onder `NEO` in `src/neo/SmartContract/StateReader.cs`.

## Read/Write API

Dit type API past de status van het smart contract aan.

| API                            | Omschrijving |
| :----------------------------- | :------------------------------- |
| Neo.Account.SetVotes           | Verandert de stem-informatie van deze account
| Neo.Validator.Register         | `Nieuw` Aanmelden als Bookkeeper node
| Neo.Asset.Create               | `Nieuw` Registreer een nieuwe asset
| Neo.Asset.Renew                | `Nieuw` Vernieuw een asset |
| Neo.Contract.Create            | `Nieuw` Publiceer een smart contract |
| Neo.Contract.Migrate           | `Nieuw` Migreer of vernieuw een smart contract |
| Neo.Contract.Destroy           | `Nieuw` Vernietig een smart contract |
| Neo.Contract.GetStorageContext | `Nieuw` Krijg de opslag-context van het contract |
| Neo.Storage.Put                | Voert een waarde toe aan de persistente opslag a.d.h.v. een gegeven key |
| Neo.Storage.Delete             | Verwijderd een waarde van de persistente opslag a.d.h.v. een gegeven key |

> [!Note]
> De broncode voor bovenstaande API kan worden gevonden onder `NEO` in `src/neo/SmartContract/StateMachine.cs`.
