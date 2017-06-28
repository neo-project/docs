# Storage.Get method (StorageContext, byte[])

Query operation, in the persistent storage area through the key query the corresponding value.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public extern byte[] Get (AntShares.SmartContract.Framework.Services.AntShares.StorageContext context, byte[] key)
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
