# Storage.Find Method

Finds the content in the storage context that matches the specified prefix.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Iterator<byte[], byte[]> Find(StorageContext context, byte[] prefix);
public static extern Iterator<string, byte[]> Find(StorageContext context, string prefix);
```

Parameters:

- context: Storage context as a [StorageContext](../StorageContext.md)
- prefix: Prefix as a byte array or string.

Return value: The iterator composed of the elements  that meet conditions in the context

```c#
public static extern Iterator<byte[], byte[]> Find(byte[] prefix);
public static extern Iterator<string, byte[]> Find(string prefix);
```

Parameters:

prefix: Prefix as a byte array or string.

Return value: The iterator composed of the elements  that meet conditions in the context

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
