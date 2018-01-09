# NEO Namespace

Il NEO Namespace contiene una API fornita dalla blockchain NEO. I metodi delle API permettono di interrogare la blockchain e la manipolazione della memoria persistente.

Nota: I tags `New` e `Deprecated` denotano cambiamenti tra la versione 1.6 e la versione 2.0.

## API di Sola Lettura

Blockchain Query API:

| API                           | Descrizione                                             |
| ----------------------------- | ------------------------------------------------------- |
| Neo.Blockchain.GetHeight      | Ottenere l'altezza del blocco corrente                            |
| Neo.Blockchain.GetHeader      | Trovare l'intestazione del blocco tramite l'altezza del blocco o l'hash del blocco         |
| Neo.Blockchain.GetBlock       | Trovare il blocco tramite l'altezza del blocco o l'hash del blocco                |
| Neo.Blockchain.GetTransaction | Trovare la transazione tramite l'ID della transazione                     |
| Neo.Blockchain.GetAccount     | Ottenere un account basato sullo scripthash del contratto  |
| Neo.Blockchain.GetValidators  | `New` Ottenere la chiave pubblica del Consensus Node          |
| Neo.Blockchain.GetAsset       | Ottenere assets in base all'ID dell'asset                             |
| Neo.Blockchain.GetContract    | `New` Ottenere il contenuto del contratto basato sull'hash del contratto       |

Block Class API::

| API                           | Descrizione |
| ----------------------------- | -------------------------- |
| Neo.Header.GetHash            | Ottenere l'hash del blocco |
| Neo.Header.GetVersion         | Ottenere il numero di versione del blocco |
| Neo.Header.GetPrevHash        | Ottenere l'hash del precedente blocco |
| Neo.Header.GetMerkleRoot      | Ottenere la radice Merkle Tree per tutte le transazioni in quel blocco |
| Neo.Header.GetTimestamp       | Ottenere il timestamp del blocco |
| Neo.Header.GetConsensusData   | Ottenere dati di consenso per questo blocco (pseudo numeri generati casualmente dal consensus node) |
| Neo.Header.GetNextConsensus   | Ottenere il valore hash del prossimo contratto bokkeeper |
| Neo.Block.GetTransactionCount | Ottenere il numero delle transazioni nel blocco corrente |
| Neo.Block.GetTransactions     | Ottenere tutte le transazioni nel blocco corrente           |
| Neo.Block.GetTransaction      | Ottenere la transazione specificata nel blocco corrente  |

Transaction Class API:

| API | Descrizione |
| ----------------------------- | ---------------------------------------- |
| Neo.Transaction.GetHash       | Ottenere l'hash della transazione corrente |
| Neo.Transaction.GetType       | Ottenere il tipo della transazione corrente |
| Neo.Enrollment.GetPublicKey   | `Deprecated` Rimpiazzato con Neo.Blockchain.GetValidators |
| Neo.Transaction.GetAttributes | Interrogare tutte le proprietá della transazione corrente |
| Neo.Transaction.GetInputs     | Interrogare tutte le transazioni per le transazioni correnti
| Neo.Transaction.GetOutputs    | Interrogare tutti gli output di transazione per la transazione corrente |
| Neo.Transaction.GetReferences | Interrogare l'output della transazione a cui fanno riferimento tutti gli input della transazione corrente |
| Neo.Attribute.GetUsage        | Ottenere lo scopo della transazione |
| Neo.Attribute.GetData         | Ottenere i dati extra al di fuori dello scopo della transazione |
| Neo.Input.GetHash             | Ottenere l'hash della transazione precedente riferita |
| Neo.Input.GetIndex            | L'indice dell'input nell'elenco di output della transazione precedente riferita |
| Neo.Output.GetAssetId         | Ottenere l'ID dell'asset |
| Neo.Output.GetValue           | Ottenere l'hash dello script |
| Neo.Output.GetScriptHash      | Ottenere la quantitá della transazione |

Account class API:

| API | Descrizione |
| ------------------------- | ------------------ |
| Neo.Account.GetScriptHash | Ottenere l'hash script dell'account del contratto |
| Neo.Account.GetVotes      | Ottenere informazioni sui voti che questo account ha emesso |
| Neo.Account.GetBalance    | Ottenere il saldo di questo asset nell'account fornito dell'ID|

Asset class API:

| API | Descrizione |
| ---------------------------- | ------------------------------------- |
| Neo.Asset.GetAssetId   | Ottenere l'ID dell'asset |
| Neo.Asset.GetAssetType | Ottenere la categoria dell'asset |
| Neo.Asset.GetAmount    | Ottenere la quantitá totale dell'asset |
| Neo.Asset.GetAvailable | Ottenere la quantitá dell'asset emesso |
| Neo.Asset.GetPrecision | Ottenere il numero di divisioni per questo asset, il numero di cifre dopo il punto decimale |
| Neo.Asset.GetOwner     | Ottenere il proprietario dell'asset (chiave pubblica) |
| Neo.Asset.GetAdmin     | Ottenere l'amministratore (indirizzo del contratto) dell'asset |
| Neo.Asset.GetIssuer    | Ottenere l'emittente (indirizzo del contratto) dell'asset |

Contract class API:

| API | Descrizione |
| ---------------------- | -------- |
| Neo.Contract.GetScript | Ottenere lo scripthash del contract |

Storage class API:

| API | Descrizione |
| ---------------------- | ------------------------------- |
| Neo.Storage.GetContext | `New` Ottenere il contesto attuale della memoria |
| Neo.Storage.Get        | Restituisce il valore della memoria permanente in base alla chiave fornita |

Runtime class API:

| API | Descrizione |
| ------------------------ | --------------------------------- |
| Neo.Runtime.CheckWitness | `New` verifica che il contratto chiamante abbia verificato gli hash dello script richiesti della transazione/blocco |
| Neo.Runtime.Notify       | `New` Notifica il client con una notificazione durante l'esecuzione di uno smart contract      |
| Neo.Runtime.Log          | `New` Notifica il client con un messaggio log durante l'esecuzione di uno smart contract      |

Nota: Il codice sorgente puó essere trovato sotto `NEO` nel file `src/neo/SmartContract/StateReader.cs`.

## Leggere/Scrivere API

Questo tipo di API modificherá lo stato dello smart contract

| API | Description |
| ------------------------------ | -------------------------------- |
| Neo.Account.SetVotes           | Impostare le informazioni di voto per questo account |
| Neo.Validator.Register         | `New` Registrarsi come bookkeeper |
| Neo.Asset.Create               | `New` Registrare un nuovo asset |
| Neo.Asset.Renew                | `New` Rinnovare un asset |
| Neo.Contract.Create            | `New` Pubblicare uno smart contract |
| Neo.Contract.Migrate           | `New` Migrare/Rinnovare uno smart contract |
| Neo.Contract.Destroy           | `New` Distruggere uno smart contract |
| Neo.Contract.GetStorageContext | `New` Ottenere il contesto di memoria del contratto |
| Neo.Storage.Put                | Inserisce un valore nella memoria permanente in base alla chiave specificata |
| Neo.Storage.Delete             | Elimina un valore dalla memoria permanente in base alla chiave specificata |

Nota: The source code for the above API can be found under `NEO` in the `src/neo/SmartContract/StateMachine.cs` file.
