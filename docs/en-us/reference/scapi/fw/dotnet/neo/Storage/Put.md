# Storage.Put Method

Inserts a given value to the given key in the persistent storage.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void Put(StorageContext context, byte[] key, byte[] value);
public static extern void Put(StorageContext context, byte[] key, BigInteger value);
public static extern void Put(StorageContext context, byte[] key, string value);
public static extern void Put(StorageContext context, string key, byte[] value);
public static extern void Put(StorageContext context, string key, BigInteger value);
public static extern void Put(StorageContext context, string key, string value);
```

Parameters:

- Context: Storage context as a [StorageContext](../StorageContext.md).

- Key: Key as a byte array.

- Value: Value as a byte array.


Return value: void.

```c#
public static extern void Put(byte[] key, byte[] value);
public static extern void Put(byte[] key, BigInteger value);
public static extern void Put(byte[] key, string value);
public static extern void Put(string key, byte[] value);
public static extern void Put(string key, BigInteger value);
public static extern void Put(string key, string value);
```

Parameters:

- Key: Key as a byte array.

- Value: Value as a byte array, BigInteger or string.


Return value: void.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        byte[] key1 = new byte[] { 0 };
        string key2 = "aa";
        byte[] value1 = new byte[] { 1 };
        BigInteger value2 = new BigInteger("1");
        string value3 = "bb";
        Storage.Put(Storage.CurrentContext, key1, value1);
        Storage.Put(Storage.CurrentContext, key1, value2);
        Storage.Put(Storage.CurrentContext, key1, value3);
        Storage.Put(Storage.CurrentContext, key2, value1);
        Storage.Put(Storage.CurrentContext, key2, value2);
        Storage.Put(Storage.CurrentContext, key2, value3);
        Storage.Put(key1, value1);
        Storage.Put(key1, value2);
        Storage.Put(key1, value3);
        Storage.Put(key2, value1);
        Storage.Put(key2, value2);
        Storage.Put(key2, value3);
    }
}
```

[Back](../Storage.md)
