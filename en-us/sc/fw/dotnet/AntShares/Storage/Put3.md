# Storage.Put method (StorageContext, string, byte[])

Insert the operation, in the form of key-value to the persistent storage area to insert data.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public extern void Put (AntShares.SmartContract.Framework.Services.AntShares.StorageContext context, string key, byte[] value)
```

parameter:
Context: storage context, [StorageContext](../StorageContex.md) type.

Key: key, string.

Value: value, byte array.

Return value: void.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         String key = "key";
         byte[] value = new byte[] {1};
         Storage.Put (Storage.CurrentContext, key, value);
     }
}
```



[Return to superior](../Storage.md)
