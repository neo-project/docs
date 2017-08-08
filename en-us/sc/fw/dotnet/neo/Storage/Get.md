# Storage.Get method (StorageContext, byte[])

Query operation, in the persistent storage area through the key query the corresponding value.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## syntax

```c#
public extern byte[] Get (Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

parameter:
Context: storage context, [StorageContext](../StorageContex.md) type.

Key: key, byte array.

Return Value: key The corresponding value, byte array.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[] value = Storage.Get (Storage.CurrentContext, new byte[] {0});
     }
}
```



[Return to superior](../Storage.md)
