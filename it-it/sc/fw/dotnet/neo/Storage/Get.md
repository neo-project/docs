# Metodo (StorageContext, byte[]) Storage.Get 

Restituisce un valore dall'archivio permanente in base alla chiave specificata.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public extern byte[] Get(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

Parametri:

Context: Contesto di memoria come [StorageContext](../StorageContext.md).

Key: Chiave come array di byte.

Valore Restituito: il valore corrispondente alla chiave come array di byte.

## Esempio

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] value = Storage.Get(Storage.CurrentContext, new byte[] {0});
     }
}
```



[Indietro](../Storage.md)
