# Storage.Put 方法

插入操作，以 key-value 的形式向持久化存储区中插入数据。

命名空间：[Neo.SmartContract.Framework.Services](../../services.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
Put(StorageContext context, byte[] key, ByteString value);
Put(StorageContext context, byte[] key, byte[] value);
Put(StorageContext context, byte[] key, BigInteger value);
Put(StorageContext context, ByteString key, ByteString value);
Put(StorageContext context, ByteString key, BigInteger value);
Put(StorageContext context, byte[] key, byte[] value, StorageFlags flags);
Put(StorageContext context, byte[] key, BigInteger value, StorageFlags flags);
Put(StorageContext context, ByteString key, BigInteger value, StorageFlags flags);
Put(StorageContext context, ByteString key, ByteString value, StorageFlags flags);
```

参数：

- context：存储上下文，[StorageContext](../StorageContext.md) 类型；
- key：键，字节数组/字符串；最大长度64字节。
- value：值，字节数组/大整数/字符串。
- flags：StorageFlags 类型，标识存储的是变量还是常量

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
    }
}
```

[返回上级](../Storage.md)
