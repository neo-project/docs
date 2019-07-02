# Storage.Put Methode (StorageContext, string, string)

Fügt einen definierten Wert zu dem gegebenen Key in dem Persistent Store hinzu

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key, string value)
```

Parameter:

Context: Storage Kontext als [StorageContext](../StorageContext.md).

Key: Schlüssel als String.

Value: Wert als String.

Rückgabewert: Void.

## Beispiel

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



[Back](../Storage.md)
