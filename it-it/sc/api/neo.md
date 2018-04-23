# NEO Namespace

Il NEO Namespace contiene una API fornita dalla blockchain NEO. I metodi delle API permettono di interrogare la blockchain e la manipolazione della memoria persistente.

Nota: I tag `New` e `Deprecated` denotano cambiamenti tra la versione 1.6 e la versione 2.0.

## API di Sola Lettura

Blockchain Query API:

| API                           | Descrizione                                             |
| ----------------------------- | ------------------------------------------------------- |
| Neo.Blockchain.GetHeight      | Ottiene l'altezza del blocco corrente                            |
| Neo.Blockchain.GetHeader      | Trova l'intestazione del blocco tramite l'altezza del blocco o l'hash del blocco         |
| Neo.Blockchain.GetBlock       | Trova il blocco tramite l'altezza del blocco o l'hash del blocco                |
| Neo.Blockchain.GetTransaction | Trova la transazione tramite l'ID della transazione                     |
| Neo.Blockchain.GetAccount     | Ottiene un account basato sullo scripthash del contratto  |
| Neo.Blockchain.GetValidators  | `New` Ottiene la chiave pubblica del Nodo di Consenso          |
| Neo.Blockchain.GetAsset       | Ottiene l'asset in base all'ID dell'asset                             |
| Neo.Blockchain.GetContract    | `New` Ottiene il contenuto del contratto basato sull'hash del contratto       |

Block Class API::

| API                           | Descrizione |
| ----------------------------- | -------------------------- |
| Neo.Header.GetHash            | Ottiene l'hash del blocco |
| Neo.Header.GetVersion         | Ottiene il numero di versione del blocco |
| Neo.Header.GetPrevHash        | Ottiene l'hash del blocco precedente |
| Neo.Header.GetMerkleRoot      | Ottiene la radice Merkle Tree per tutte le transazioni in quel blocco |
| Neo.Header.GetTimestamp       | Ottiene il timestamp del blocco |
| Neo.Header.GetConsensusData   | Ottiene dati sul consenso per questo blocco (pseudo numeri generati casualmente dal nodo di consenso) |
| Neo.Header.GetNextConsensus   | Ottiene il valore hash del prossimo contratto bookkeeper |
| Neo.Block.GetTransactionCount | Ottiene il numero delle transazioni nel blocco corrente |
| Neo.Block.GetTransactions     | Ottiene tutte le transazioni nel blocco corrente           |
| Neo.Block.GetTransaction      | Ottiene la transazione specificata nel blocco corrente  |

Transaction Class API:

| API | Descrizione |
| ----------------------------- | ---------------------------------------- |
| Neo.Transaction.GetHash       | Ottiene l'hash della transazione corrente |
| Neo.Transaction.GetType       | Ottiene il tipo della transazione corrente |
| Neo.Enrollment.GetPublicKey   | `Deprecated` Rimpiazzato con Neo.Blockchain.GetValidators |
| Neo.Transaction.GetAttributes | Interroga tutte le proprietá della transazione corrente |
| Neo.Transaction.GetInputs     | Interroga tutte le transazioni per le transazioni correnti
| Neo.Transaction.GetOutputs    | Interroga tutti gli output di transazione per la transazione corrente |
| Neo.Transaction.GetReferences | Interroga l'output della transazione a cui fanno riferimento tutti gli input della transazione corrente |
| Neo.Attribute.GetUsage        | Ottiene lo scopo della transazione |
| Neo.Attribute.GetData         | Ottiene i dati extra al di fuori dello scopo della transazione |
| Neo.Input.GetHash             | Ottiene l'hash della transazione precedente riferita |
| Neo.Input.GetIndex            | L'indice dell'input nell'elenco output della transazione precedente riferita |
| Neo.Output.GetAssetId         | Ottiene l'ID dell'asset |
| Neo.Output.GetValue           | Ottiene l'importo della transazione |
| Neo.Output.GetScriptHash      | Ottiene l'hash dello script |

Account class API:

| API | Descrizione |
| ------------------------- | ------------------ |
| Neo.Account.GetScriptHash | Ottiene l'hash dello script dell'account del contratto |
| Neo.Account.GetVotes      | Ottiene informazioni sui voti che questo account ha emesso |
| Neo.Account.GetBalance    | Ottiene il saldo di questo asset nell'account, dato l'ID dell'asset|

Asset class API:

| API | Descrizione |
| ---------------------------- | ------------------------------------- |
| Neo.Asset.GetAssetId   | Ottiene l'ID dell'asset |
| Neo.Asset.GetAssetType | Ottiene la categoria dell'asset |
| Neo.Asset.GetAmount    | Ottiene la quantitá totale dell'asset |
| Neo.Asset.GetAvailable | Ottiene la quantitá dell'asset emesso |
| Neo.Asset.GetPrecision | Ottiene il numero di divisioni per questo asset, il numero di cifre dopo il punto decimale |
| Neo.Asset.GetOwner     | Ottiene il proprietario dell'asset (chiave pubblica) |
| Neo.Asset.GetAdmin     | Ottiene l'amministratore (indirizzo del contratto) dell'asset |
| Neo.Asset.GetIssuer    | Ottiene l'emittente (indirizzo del contratto) dell'asset |

Contract class API:

| API | Descrizione |
| ---------------------- | -------- |
| Neo.Contract.GetScript | Ottiene lo scripthash del contratto |

Storage class API:

| API | Descrizione |
| ---------------------- | ------------------------------- |
| Neo.Storage.GetContext | `New` Ottiene il contesto attuale della memoria |
| Neo.Storage.Get        | Restituisce il valore della memoria permanente in base alla chiave fornita |

Runtime class API:

| API | Descrizione |
| ------------------------ | --------------------------------- |
| Neo.Runtime.CheckWitness | `New` Verifica che il contratto chiamante abbia verificato gli hash dello script richiesti della transazione/blocco |
| Neo.Runtime.Notify       | `New` Avverte il client con una notifica durante l'esecuzione di uno smart contract      |
| Neo.Runtime.Log          | `New` Avverte il client con un messaggio di log durante l'esecuzione di uno smart contract      |

Nota: Il codice sorgente puó essere trovato sotto `NEO` nel file `src/neo/SmartContract/StateReader.cs`.

## Leggere/Scrivere API

Questo tipo di API modificherá lo stato dello smart contract

| API | Descrizione |
| ------------------------------ | -------------------------------- |
| Neo.Account.SetVotes           | Imposta le informazioni di voto per questo account |
| Neo.Validator.Register         | `New` Registra come bookkeeper |
| Neo.Asset.Create               | `New` Registra un nuovo asset |
| Neo.Asset.Renew                | `New` Rinnova un asset |
| Neo.Contract.Create            | `New` Pubblica uno smart contract |
| Neo.Contract.Migrate           | `New` Migrare/Rinnovare uno smart contract |
| Neo.Contract.Destroy           | `New` Distrugge uno smart contract |
| Neo.Contract.GetStorageContext | `New` Ottiene il contesto di memoria del contratto |
| Neo.Storage.Put                | Inserisce un valore nella memoria permanente in base alla chiave specificata |
| Neo.Storage.Delete             | Elimina un valore dalla memoria permanente in base alla chiave specificata |

Nota: Il codice sorgente per le API soprastante puó essere trovato su `NEO` nel file `src/neo/SmartContract/StateMachine.cs`.
