# Storage.CurrentContext Eigenschaften

Gibt den aktuellen Storekontext zurück. Nachdem man den Storekontext erhalten hat, kann man das Objekt als ein Argument an einen anderen Contract übergeben (Als Autorisation). Das erlaubt anderen Contracts Read/Write Operationen auf dem Persistent Store des aktuellen Contracts auszuführen.

Anmerkung: Dies ist anders als in der Version 1.6.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.StorageContext CurrentContext {get;}
```

Attributwert: Aktueller Storagekontext als  [StorageContext](../StorageContext.md).



[Back](../Storage.md)
