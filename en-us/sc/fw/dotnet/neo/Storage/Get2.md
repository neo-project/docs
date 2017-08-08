# Storage.Get method (StorageContext, string)

Query operation, in the persistent storage area through the key query the corresponding value.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## syntax

```c#
public extern void Delete (Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key)
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
