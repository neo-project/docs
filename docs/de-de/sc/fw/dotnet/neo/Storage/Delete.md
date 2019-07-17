# Storage.Delete Methode (StorageContext, byte[])

Löscht einen Wert von dem Peristent Store anhand eines vorgegebenen Keys.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern void Delete(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

Parameter:

Kontext: Storage Context als ein [StorageContext](../StorageContext.md).

Key: Schlüssel als Byte Array.

Rückgabewert: Void.

## Beispiel

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Storage.Delete(Storage.CurrentContext, new byte[] {0});
     }
}
```



[Back](../Storage.md)
