# Storage.Get method (StorageContext, string)

Query operation, in the persistent storage area through the key query the corresponding value.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public extern void Delete (AntShares.SmartContract.Framework.Services.AntShares.StorageContext context, string key)
```

parameter:
Context: storage context, [StorageContext](../StorageContex.md) type.

Key: key, string type.

Return Value: key The corresponding value, byte array.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[] value = Storage.Get (Storage.CurrentContext, "key");
     }
}
```



[Return to superior](../Storage.md)
