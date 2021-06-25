# Storage.Get Method

Returns a value from the persistent store based on the given key.

Namespace: [Neo.SmartContract.Framework.Services](../../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern byte[] Get(StorageContext context, byte[] key);
public static extern byte[] Get(StorageContext context, ByteString key);
```

Parameters:

Context: Storage context as a [StorageContext](../StorageContext.md).

Key: Key as a byte array or string. Max length 64 bytes.

Return Value: The value corresponding to the key as a byte array.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        byte[] value = Storage.Get(Storage.CurrentContext, new byte[] { 0 });
        byte[] value = Storage.Get(Storage.CurrentContext, "aa");
    }
}
```



[Back](../Storage.md)
