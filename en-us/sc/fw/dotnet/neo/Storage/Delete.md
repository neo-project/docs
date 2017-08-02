# Storage.Delete method (StorageContext, byte[])

Delete the operation, in the persistent storage area through the key to delete the corresponding value.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## syntax

```c#
public extern void Delete (Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

parameter:
Context: storage context, [StorageContext](../StorageContex.md) type.

Key: key, byte array.

Return value: void.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Storage.Delete (Storage.CurrentContext, new byte[] {0});
     }
}
```



[Return to superior](../Storage.md)
