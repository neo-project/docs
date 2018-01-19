# Classe StorageContext

La classe che rappresenta il contesto di memoria dell'archivio persistente.

Lo smart contract puó ottenere il suo contesto di memoria tramite Storage.CurrentContext e passare il contesto come un argomento agli altri contratti (come modo di autorizzazione), permettendo agli altri contratti di chiamare i metodi di lettura/scrittura per i loro archivi persistenti.

Nota: Differisce dalla versione 1.6.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public class StorageContext
```

## Costruttore

L'oggetto StorageContext é costruito tramite [Storage.CurrentContext](Storage/CurrentContext.md).
