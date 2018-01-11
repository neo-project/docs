# Proprietà Storage.CurrentContext 

Restituisce il contesto corrente della memoria. Dopo aver ottenuro il contesto della memoria, l'oggetto può essere passato come argomento agli altri contratti (come un mezzo di autorizzazione), permettendo agli altri contratti di performare operazioni di lettura/scrittura sulla memoria persistente del contratto corrente. 

Note: This is different from the 1.6 version.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.StorageContext CurrentContext {get;}
```

Valore dell'attributo: contesto di archiviazione corrente come [StorageContext](../StorageContext.md).



[Indietro](../Storage.md)
