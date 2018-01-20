# Sistema Namespace

Il sistema namespace é l'API fornita dallo Smart Contract Execution Engine (NeoVM), il quale fornisce un modo di accedere all'esecuzione dell'ambiente dello smart contract.

| API | Descrizione |
| ---------------------------------------- | -------------------------- |
| System.ExecutionEngine.GetScriptContainer | Ottiene il container dello script per questo smart contract (il primo innescato) |
| System.ExecutionEngine.GetExecutingScriptHash | Ottiene lo scripthash dello smart contract in esecuzione |
| System.ExecutionEngine.GetCallingScriptHash | Ottiene lo scripthash del chiamante di questo smart contract |
| System.ExecutionEngine.GetEntryScriptHash | Ottiene lo scripthash del punto di entrata dello smart contract (il punto di inizio della chiamata dello smart contract nella chain) |

Nota: Il codice sorgente dell'API soprastante puó essere trovato in `Neo.VM` nel file `src\Neo.VM\InteropService.cs`.
