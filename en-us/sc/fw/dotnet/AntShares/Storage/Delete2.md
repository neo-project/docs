# Storage.Delete method (StorageContext, string)

Delete the operation, in the persistent storage area through the key to delete the corresponding value.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public extern void Delete (AntShares.SmartContract.Framework.Services.AntShares.StorageContext context, byte[] key)
```

parameter:
Context: storage context, [StorageContext](../StorageContex.md) type.

Key: key, string type.

Return value: void.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Storage.Delete (Storage.CurrentContext, "Key");
     }
}
```



[Return to superior](../Storage.md)
