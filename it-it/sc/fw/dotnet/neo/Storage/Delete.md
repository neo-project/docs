# Metodo (StorageContext, byte[]) Storage.Delete 

Elimina un valore dalla memoria persistente in base alla chiave specificata.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public extern void Delete(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

Parametri:

Context: Contesto di archiviazione come [StorageContext](../StorageContext.md).

Key: Chiave come array di byte.

Valore Restituito: Vuoto.

## Esempio

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Storage.Delete(Storage.CurrentContext, new byte[] {0});
     }
}
```



[Indietro](../Storage.md)
