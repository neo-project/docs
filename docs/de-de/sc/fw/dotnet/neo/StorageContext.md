# StorageContext Klasse

Die Klasse repräsentiert den Storage Context des Persistent Store. 

Der Smart Contract kann sich seinen eigenen Storage Context durch den Storage.CurrentContext beziehen. Nachdem man den Storekontext erhalten hat kann man das Objekt als ein Argument an einen anderen Contract übergeben (Als Autorisation). Das erlaubt anderen Contracts Read/Write Operationen auf dem Persistent Store des aktuellen Contracts auszuführen.

Anmerkung: Dies ist anders als in der Version 1.6

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class StorageContext
```

## Ersteller

Das Storagecontextobjekt wird durch [Storage.CurrentContext](Storage/CurrentContext.md) erstellt.
