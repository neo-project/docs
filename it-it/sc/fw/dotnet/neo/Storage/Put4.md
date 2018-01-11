# Metodo (StorageContext, string, string) Storage.Put 

Inserisce un dato valore nella chiave specificata nella memoria permanente.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key, string value)
```

Parametri:

Context: Contesto di memoria come [StorageContext](../StorageContext.md).

Key: Chiave come una stringa.

Value: Valore come una stringa.

Valore restituito: Vuoto.

## Esempio:

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         String key = "key";
         String value = "value";
         Storage.Put(Storage.CurrentContext, key, value);
     }
}
```



[Indietro](../Storage.md)
