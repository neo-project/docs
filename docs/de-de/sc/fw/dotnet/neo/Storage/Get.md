# Storage.Get Methode (StorageContext, byte[])

Gibt einen Wert von dem Peristent Store anhand eines vorgegebenen Keys zurück.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern byte[] Get(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

Parameter:

Context: Storage Kontext als [StorageContext](../StorageContext.md).

Key: Schlüssel als Byte Array.

Rückgabewert: Der Wert zum dazugehörigen Schlüssel als Byte Array.

## Beispiel

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] value = Storage.Get(Storage.CurrentContext, new byte[] {0});
     }
}
```



[Back](../Storage.md)
