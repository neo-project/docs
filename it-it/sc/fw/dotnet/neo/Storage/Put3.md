# Metodo (StorageContext, string, byte[]) Storage.Put 

Inserisce un dato valore in una chiave specificata nell'archivio permanente.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sinstassi

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key, byte[] value)
```

Parametri:

Context: Contesto di memoria come [StorageContext](../StorageContext.md).

Key: Chiave come una stringa.

Value: Valore come array di byte.

Valore restituito: Vuoto.

## Esempio

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         String key = "key";
         byte[] value = new byte[] {1};
         Storage.Put(Storage.CurrentContext, key, value);
     }
}
```



[Indietro](../Storage.md)
