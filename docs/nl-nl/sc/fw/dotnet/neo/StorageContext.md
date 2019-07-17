# StorageContext Class

De class die staat voor de opslaglocatie in de persistente opslag.

Een smart contract kan de opslaglocatie van zichzelf krijgen door `Storage.CurrentContext` en kan deze als argument naar andere contracten doorgeven (bij wijze van authorisatie), waardoor andere contracten de read/write methodes voor de opslag van het smart contract kunnen aanvragen.

> [!Note]
> Dit is anders dan in versie 1.6.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class StorageContext
```

## Constructor

Het StorageContext object wordt gemaakt door [Storage.CurrentContext](Storage/CurrentContext.md).
