# Storage.Delete Method

Deletes the value corresponding to the given key from the specific storage context.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void Delete(StorageContext context, byte[] key);
public static extern void Delete(StorageContext context, string key);
```

Parameters:

- Context: Storage context as a [StorageContext](../StorageContext.md).

- Key: Key as a byte array or string.


Return value: void.

```c#
public static extern void Delete(byte[] key);
public static extern void Delete(string key);
```

Parameters:

Key: Key as a byte array or string.

Return value: void.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        Storage.Delete(Storage.CurrentContext, "aa");
        Storage.Delete(Storage.CurrentContext, new byte[] { 0 });
        Storage.Delete("aa");
        Storage.Delete(new byte[] { 0 });
    }
}
```



[Back](../Storage.md)
