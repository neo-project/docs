# Storage.Delete Method (StorageContext, byte[])

Deletes a value from the peristent store based on the given key.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

This method has multiple overloads:

```c#
public extern void Delete(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key)
```

```c#
public extern void Delete(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

```c#
public extern void Delete(string key)
```

```c#
public extern void Delete(byte[] key)
```

Parameters:

- Context: Storage context as a [StorageContext](../StorageContext.md). If StorageContext is not passed in, CurrentContext is used by default.

- Key: Key as a byte array or string.


Return value: void.

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
