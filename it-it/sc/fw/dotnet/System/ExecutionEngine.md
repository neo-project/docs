# Classe ExecutionEngine 

Il motore di esecuzione della macchina virtuale, permette l'accesso al chiamante e al container di esecuzione.

Namespace: [Neo.SmartContract.Framework.Services.System](../System.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public class ExecutionEngine
```

## Attributi

| | Nome | Descrizione |
| ---------------------------------------- | ---------------------------------------- | -------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [CallingScriptHash](ExecutionEngine/CallingScriptHash.md) | Restituisce lo scripthash del caller del contratto           |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [EntryScriptHash](ExecutionEngine/EntryScriptHash.md) | Restituisce lo scripthash dei punti di entrata del contratto (nella chain di invocazione del contratto) |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ExecutingScriptHash](ExecutionEngine/ExecutingScriptHash.md) | Restituisce lo scripthash del contratto in esecuzione            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptContainer](ExecutionEngine/ScriptContainer.md) | Restituisce lo script container del contratto corrente (L'avvio iniziale)      |
