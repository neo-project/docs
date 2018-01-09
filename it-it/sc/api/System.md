# Sistema Namespace

Il sistema namespace é l'API fornita dallo Smart Contract Execution Engine (NeoVM), il quale fornisce un modo di accedere all'esecuzione dell'ambiente dello smart contract.

| API | Descrizione |
| ---------------------------------------- | -------------------------- |
| System.ExecutionEngine.GetScriptContainer | Ottenere il container script per questo smart contract (il primo innescato) |
| System.ExecutionEngine.GetExecutingScriptHash | Ottenere lo scripthash dello smart contract in esecuzione |
| System.ExecutionEngine.GetCallingScriptHash | Ottenere lo scripthash del chiamante di questo smart contract |
| System.ExecutionEngine.GetEntryScriptHash | Ottenere lo scripthash del punto di entrata dello smart contract (il punto di inizio della chiamata dello smart contract nella chain) |

Nota: Il codice sorgente dell'API sopra puó essere trovato sotto `Neo.VM` nel file `src\Neo.VM\InteropService.cs`.
