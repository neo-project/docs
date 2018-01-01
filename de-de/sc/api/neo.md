# NEO Namespace

Der Neo Namespace enthält eine von der NEO Blockchain zur Verfügung gestellte API. Methoden der API erlauben das Abfragen der Blockchain und die Manipulation des persistenten Speichers.

Anmerkung: 'New' und 'Deprecated' tags bezeichnen Änderungen zwischen der Version 1.6 und Version 2.0

## Read-only API

API für Blockchain Abfragen:

| API                           | Beschreibung                                            |
| ----------------------------- | ------------------------------------------------------- |
| Neo.Blockchain.GetHeight      | Die aktuelle Blockhöhe abrufen                          |
| Neo.Blockchain.GetHeader      | Suchen Sie Blockheader nach Blockhöhe oder Blockhash    |
| Neo.Blockchain.GetBlock       | Suchen Sie einen Block nach Blockhöhe oder Blockhash    |
| Neo.Blockchain.GetTransaction | Suchen Sie eine Transaktion mittels Transaktions ID     |
| Neo.Blockchain.GetAccount     | Ein Konto basierend auf dem Scripthash des Vertrags abrufen  |
| Neo.Blockchain.GetValidators  | `New` Public Key der Consensus Node abrufen             |
| Neo.Blockchain.GetAsset       | Asset anhand der Asset ID abrufen                       |
| Neo.Blockchain.GetContract    | `New` Contract Inhalt basierend auf dem Contract Hash abrufen   |

Block Class API:

| API                           | Beschreibung |
| ----------------------------- | -------------------------- |
| Neo.Header.GetHash            | Hash des Blocks abrufen |
| Neo.Header.GetVersion         | Versionsnummer des Blocks abrufen |
| Neo.Header.GetPrevHash        | Hash des vorherigen Blocks abrufen |
| Neo.Header.GetMerkleRoot      | Merkle Tree Root für alle Transaktionen in diesem Block abrufen |
| Neo.Header.GetTimestamp       | Timestamp für den Block abrufen |
| Neo.Header.GetConsensusData   | Consensus Daten für diesen Block abrufen (Pseudozufallszahl, generiert von der Consensus Node ) |
| Neo.Header.GetNextConsensus   | Hash Wert für den nächsten Bookkeeper Contract abrufen |
| Neo.Block.GetTransactionCount | Anzahl von Transaktionen im aktuellen Block abrufen |
| Neo.Block.GetTransactions     | Alle Transaktionen im aktuellen Block abrufen           |
| Neo.Block.GetTransaction      | Die im aktuellen Block angegebenen Transaktionen abrufen  |

Transaction Class API:

| API | Beschreibung |
| ----------------------------- | ---------------------------------------- |
| Neo.Transaction.GetHash       | Hash für die aktuelle Transaktion abrufen |
| Neo.Transaction.GetType       | Art der aktuellen Transaktion abrufen |
| Neo.Enrollment.GetPublicKey   | `Deprecated` Ersetzt durch Neo.Blockchain.GetValidators |
| Neo.Transaction.GetAttributes | Alle Eigenschaften der aktuellen Transaktion abfragen |
| Neo.Transaction.GetInputs     | Alle Transaktionen für die aktuelle Transaktion abfragen |
| Neo.Transaction.GetOutputs    | Alle Transaktions-Outputs für die aktuelle Transaktion abfragen |
| Neo.Transaction.GetReferences | Abfragen der Transaktionsoutputs, auf die alle Inputs der aktuellen Transaktion verweisen |
| Neo.Attribute.GetUsage        | Zweck der Transaktion abfragen |
| Neo.Attribute.GetData         | Zusätzliche Daten außerhalb des Transaktionszwecks abfragen |
| Neo.Input.GetHash             | Den Hash der referenzierten vorherigen Transaktion abfragen |
| Neo.Input.GetIndex            | Der Index des Inputs in der Output-Liste der referenzierten vorherigen Transaktion |
| Neo.Output.GetAssetId         | Asset ID abfragen |
| Neo.Output.GetValue           | Script Hash abfragen |
| Neo.Output.GetScriptHash      | Transaktionsbetrag abfragen |

Account Class API:

| API | Beschreibung |
| ------------------------- | ------------------ |
| Neo.Account.GetScriptHash | Script Hash des Contract Accounts erhalten |
| Neo.Account.GetVotes      | Informationen zu den Stimmen, die dieses Konto abgegeben hat abfragen |
| Neo.Account.GetBalance    | Den Saldo dieses Asset im Account mit der gegebenen Asset ID abfragen |

Asset Class API:

| API | Beschreibung |
| ---------------------------- | ------------------------------------- |
| Neo.Asset.GetAssetId   | ID des Asset abfragen |
| Neo.Asset.GetAssetType | Kategorie des Asset abfragen |
| Neo.Asset.GetAmount    | Gesamtmenge des Asset abfragen |
| Neo.Asset.GetAvailable | Die ausgegebene Menge des Assets abfragen |
| Neo.Asset.GetPrecision | Die Anzahl der Divisionen des Assets abfragen, d.h. die Anzahl der Stellen hinter dem Dezimalpunkt |
| Neo.Asset.GetOwner     | Inhaber des Assets abfragen (Public Key) |
| Neo.Asset.GetAdmin     | Administrator (Contract Adresse) des Assets erhalten |
| Neo.Asset.GetIssuer    | Herausgeber (Contract Adresse) des Assets erhalten |

Contract class API:

| API | Beschreibung |
| ---------------------- | -------- |
| Neo.Contract.GetScript | Scripthash des Contracts abfragen |

Storage class API:

| API | Beschreibung |
| ---------------------- | ------------------------------- |
| Neo.Storage.GetContext | `New` Den aktuellen Kontext des Speichers erhalten |
| Neo.Storage.Get        | Gibt den Wert im persistenten Speicher basierend auf dem angegebenen Schlüssel zurück |

Runtime class API:

| API | Beschreibung |
| ------------------------ | --------------------------------- |
| Neo.Runtime.CheckWitness | `New` Überprüft, ob der anrufende Vertrag die erforderlichen Skript-Hashes der Transaktion / des Blocks bestätigt hat |
| Neo.Runtime.Notify       | `New` Benachrichtigt den Client während der Smart Contract-Ausführung mit einer Benachrichtigung      |
| Neo.Runtime.Log          | `New` Benachrichtigt den Client während der Smart Contract-Ausführung mit einer log Message      |

Anmerkung: Den Sourcecode finden sie unter 'NEO' in der Datei `src/neo/SmartContract/StateReader.cs`

## Read/Write API

Dieser API Typ ändert den Status eines Smart Contract

| API | Beschreibung |
| ------------------------------ | -------------------------------- |
| Neo.Account.SetVotes           | Legen Sie die Abstimmungsinformationen dieses Kontos fest |
| Neo.Validator.Register         | `New` Als Bookkeeper registrieren |
| Neo.Asset.Create               | `New` Einen neuen Asset registrieren |
| Neo.Asset.Renew                | `New` Einen Asset erneuern |
| Neo.Contract.Create            | `New` Einen Smart Contract veröffentlichen |
| Neo.Contract.Migrate           | `New` Migrieren / Erneuern eines Smart Contracts |
| Neo.Contract.Destroy           | `New` Einen Smart Contract zerstören |
| Neo.Contract.GetStorageContext | `New` Den Speicherkontext des Vertrags abfragen |
| Neo.Storage.Put                | Fügt einen Wert in den persistenten Speicher ein, basierend auf dem angegebenen Schlüssel |
| Neo.Storage.Delete             | Löscht einen Wert aus dem persistenten Speicher basierend auf dem angegebenen Schlüssel |

Anmerkung: Den Sourcecode für die oben angegebene API finden Sie unter 'NEO' in der Datei `src/neo/SmartContract/StateMachine.cs`

