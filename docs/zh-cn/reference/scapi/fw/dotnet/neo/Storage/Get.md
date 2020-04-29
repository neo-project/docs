# Storage.Get 方法 

查询操作，在持久化存储区中通过 key 查询对应的 value。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern byte[] Get(StorageContext context, byte[] key);
public static extern byte[] Get(StorageContext context, string key);
```

参数：

- context：存储上下文，[StorageContext](../StorageContext.md) 类型;
- key：键，字节数组或者字符串。

返回值：key 对应的 value，字节数组。

```c#
public static extern byte[] Get(byte[] key);
public static extern byte[] Get(string key);
```

参数：

- key：键，字节数组或者字符串。

返回值：key 对应的 value，字节数组。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        byte[] value = Storage.Get(Storage.CurrentContext, new byte[] { 0 });
        byte[] value = Storage.Get(Storage.CurrentContext, "aa");
        byte[] value = Storage.Get(new byte[] { 0 });
        byte[] value = Storage.Get("aa");
    }
}
```

[返回上级](../Storage.md)
