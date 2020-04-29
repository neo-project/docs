# Storage.Put 方法

插入操作，以 key-value 的形式向持久化存储区中插入数据。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern void Put(StorageContext context, byte[] key, byte[] value);
public static extern void Put(StorageContext context, byte[] key, BigInteger value);
public static extern void Put(StorageContext context, byte[] key, string value);
public static extern void Put(StorageContext context, string key, byte[] value);
public static extern void Put(StorageContext context, string key, BigInteger value);
public static extern void Put(StorageContext context, string key, string value);
```

参数：

- context：存储上下文，[StorageContext](../StorageContext.md) 类型；
- key：键，字节数组/字符串；
- value：值，字节数组/大整数/字符串。

返回值：void。

```c#
public static extern void Put(byte[] key, byte[] value);
public static extern void Put(byte[] key, BigInteger value);
public static extern void Put(byte[] key, string value);
public static extern void Put(string key, byte[] value);
public static extern void Put(string key, BigInteger value);
public static extern void Put(string key, string value);
```
参数：

- key：键，字节数组/字符串；
- value：值，字节数组/大整数/字符串。

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

[返回上级](../Storage.md)
