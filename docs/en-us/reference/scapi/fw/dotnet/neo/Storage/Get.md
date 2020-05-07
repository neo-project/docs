# Storage.Get Method

Returns a value from the persistent store based on the given key.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

This method has multiple overloads:

```c#
public extern byte[] Get(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

```c#
public extern byte[] Get(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key)
```

```c#
public extern byte[] Get(byte[] key)
```

```c#
public extern byte[] Get(string key)
```

Parameters:

- Context: Storage context as a [StorageContext](../StorageContext.md). If StorageContext is not passed in, CurrentContext is used by default.

- Key: Key as a byte array or string.


Return Value: The value corresponding to the key as a byte array.

## Example

```c#
public class Contract1 : SmartContract
{
    public static void Main()
    {
        byte[] value = Storage.Get("contract");
    }
}
```



[Back](../Storage.md)
