# Proprietà ExecutionEngine.ScriptContainer 

Restituisce il container di script del contratto corrente (L'avvio iniziale). Questa è solitamente una transazione, se questo contratto è stato innescato da una transazione dall'account del contratto, allora lo ScriptContainer sarà di quella transazione. Se il contratto corrente è stato innescato da una Invocation Transaction, allora lo ScriptContainer sarà di questa Invocation Transaction.

Namespace: [Neo.SmartContract.Framework.Services.System](../../System.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public extern Neo.SmartContract.Framework.IScriptContainer ScriptContainer {get;}
```

Valore dell'attributo: ScriptContainer come IScriptContainer. Se sai che l'innescatore è una Transazione, puoi lanciarlo in una [Transazione](../../neo/Transaction.md).



[Indietro](../ExecutionEngine.md)