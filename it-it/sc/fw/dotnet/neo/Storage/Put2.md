# Metodo (StorageContext, byte[], string) Storage.Put 

Inserisce un dato valore nella chiave specificata nell'archivio permanente.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key, string value)
```

Parametri:

Context: Contesto di archiviazione come [StorageContext](../StorageContext.md).

Key: Chiave come array di byte.

Value: Valore come stringa.

Valore restituito: Vuoto.

## Esempio

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] key = new byte[] {0};
         String value = "value";
         Storage.Put(Storage.CurrentContext, key, value);
     }
}
```



[Indietro](../Storage.md)
