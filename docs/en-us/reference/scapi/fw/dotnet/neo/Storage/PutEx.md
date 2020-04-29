# Storage.PutEx Method

Inserts data into the current persistent storage as key-value and sets the data property to flags.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void PutEx(byte[] key, byte[] value, StorageFlags flags);
public static extern void PutEx(byte[] key, BigInteger value, StorageFlags flags);
public static extern void PutEx(byte[] key, string value, StorageFlags flags);
public static extern void PutEx(string key, byte[] value, StorageFlags flags);
public static extern void PutEx(string key, BigInteger value, StorageFlags flags);
public static extern void PutEx(string key, string value, StorageFlags flags);
```

Parameters:

- key: Key as a byte array or string
- value: Value as a byte array, BigInteger or string.
- flags: Written data property as a [StorageFlags](../StorageFlags.md)

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
        Storage.Put(key1, value1, StorageFlags.Constant);
        Storage.Put(key1, value2, StorageFlags.Constant);
        Storage.Put(key1, value3, StorageFlags.Constant);
        Storage.Put(key2, value1, StorageFlags.None);
        Storage.Put(key2, value2, StorageFlags.None);
        Storage.Put(key2, value3, StorageFlags.None);
    }
}
```

[Back](../Storage.md)