# Storage.Put 方法

插入操作，以 key-value 的形式向持久化存储区中插入数据。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

该方法有多个重载：

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


参数：
	context：存储上下文，[StorageContext](../StorageContext.md) 类型。如果不带 StorageContext，则默认为 CurrentContext。

​	key：键，字节数组或字符串。

​	value：值，字节数、字符串或 BigInteger。

返回值：void。

## 示例

```c#
public class Contract1 : SmartContract
{
    public static void Main()
    {
        Storage.Put("hello", "world");
    }
}
```



[返回上级](../Storage.md)
