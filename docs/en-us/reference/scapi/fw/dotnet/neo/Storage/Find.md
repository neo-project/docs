# Storage.Find Method

Finds the value collection from the persistent storage based on the given key prefix. This method cannot be used together with StorageMap.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Iterator<byte[], byte[]> Find(StorageContext context, byte[] prefix)
```

```c#
public static extern Iterator<string, byte[]> Find(StorageContext context, string prefix)
```

```c#
public static extern Iterator<byte[], byte[]> Find(byte[] prefix)
```

```c#
public static extern Iterator<string, byte[]> Find(string prefix)
```

Parameters:

- Context: Storage context as a [StorageContext](../StorageContext.md). If StorageContext is not passed in, CurrentContext is used by default.
- prefix: prefix as a byte array or string.


Return value: [Iterator\<string, byte[]>](../Iterator.md) or [Iterator\<byte[], byte[]>]((../Iterator.md)).

## Example

```c#
public class Contract1 : SmartContract
{
    public static void Main()
    {
        Storage.Delete("contract");
    }
}
```



[Back](../Storage.md)
