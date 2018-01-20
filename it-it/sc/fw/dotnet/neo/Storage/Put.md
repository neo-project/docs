#  Metodo (StorageContext, byte[], byte[]) Storage.Put

Inserisce un dato valore nella chiave specificata nell'archivio permanente.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key, byte[] value)
```

Parametri:

Context: Contesto di memoria come [StorageContext](../StorageContext.md).

Key: Chiave come array di byte.

Value: Valore come array di byte.

Valore restituito: vuoto.

## Esempio

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] key = new byte[] {0};
         byte[] value = new byte[] {1};
         Storage.Put(Storage.CurrentContext, key, value);
     }
}
```



[Indietro](../Storage.md)
