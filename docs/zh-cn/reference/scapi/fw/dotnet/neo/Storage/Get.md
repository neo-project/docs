# Storage.Get 方法

查询操作，在持久化存储区中通过 key 查询对应的 value。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

该方法有多个重载：

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

参数：

- context：存储上下文，[StorageContext](../StorageContext.md) 类型。如果不带 StorageContext，则默认为 CurrentContext。
- key：键，字节数组或字符串。


返回值：key 对应的 value，字节数组。

## 示例

```c#
public class Contract1 : SmartContract
{
    public static void Main()
    {
        byte[] value = Storage.Get("contract");
    }
}
```



[返回上级](../Storage.md)
