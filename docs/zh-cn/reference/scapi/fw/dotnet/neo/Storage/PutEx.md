# Storage.PutEx 方法 

插入操作，以 key-value 的形式向当前持久化存储区中插入数据，并将数据属性设定为flags。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern void PutEx(byte[] key, byte[] value, StorageFlags flags);
public static extern void PutEx(byte[] key, BigInteger value, StorageFlags flags);
public static extern void PutEx(byte[] key, string value, StorageFlags flags);
public static extern void PutEx(string key, byte[] value, StorageFlags flags);
public static extern void PutEx(string key, BigInteger value, StorageFlags flags);
public static extern void PutEx(string key, string value, StorageFlags flags);
```

参数：

- key：键，字节数组/字符串；
- value：值，字节数组/大整数/字符串；
- flags: 写入数据的属性，[StorageFlags](../StorageFlags.md)类型。

返回值：void。

## 示例

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

[返回上级](../Storage.md)
