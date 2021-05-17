# Storage.Find Method

Finds the content in the storage context that matches the specified prefix.

Namespace: [Neo.SmartContract.Framework.Services](../../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Iterator Find(StorageContext context, byte[] prefix, FindOptions options = FindOptions.None);
public static extern Iterator Find(StorageContext context, ByteString prefix, FindOptions options = FindOptions.None);
```

Parameters:

- context: Storage context as a [StorageContext](../StorageContext.md)
- prefix: Prefix as a byte array or string.

Return value: The iterator composed of the elements  that meet conditions in the context.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        byte[] prefix1 = new byte[] { 0 };
        string prefix2 = "aa";
        Storage.Find(Storage.CurrentContext, prefix1);
        Storage.Find(Storage.CurrentContext, prefix2);
        Storage.Find(prefix1);
        Storage.Find(prefix2);
    }
}
```

[Back](../Storage.md)
