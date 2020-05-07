# Storage.Put Method (StorageContext, byte[], byte[])

Inserts a given value in the key-value format into the persistent storage.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

This method has multiple overloads:

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key, byte[] value)
```

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key, string value)
```

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key, BigInteger value)
```

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key, byte[] value)
```

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key, string value)
```

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key, BigInteger value)
```

```c#
public extern void Put(byte[] key, byte[] value)
```

```c#
public extern void Put(byte[] key, string value)
```

```c#
public extern void Put(byte[] key, BigInteger value)
```

```c#
public extern void Put(string key, byte[] value)
```

```c#
public extern void Put(string key, string value)
```

```c#
public extern void Put(string key, BigInteger value)
```

Parameters:

- Context: Storage context as a [StorageContext](../StorageContext.md). If StorageContext is not passed in, CurrentContext is used by default.

- Key: Key as a byte array.

- Value: Value as a byte array.


Return value: void.

## Example

```c#
public class Contract1 : SmartContract
{
    public static void Main()
    {
        Storage.Put("hello", "world");
    }
}
```



[Back](../Storage.md)
