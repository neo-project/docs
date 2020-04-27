# Storage.Delete 方法

删除操作，在持久化存储区中通过 key 删除对应的 value。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

该方法有多个重载：

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

参数：
	context：存储上下文，[StorageContext](../StorageContext.md) 类型。如果不带 StorageContext，则默认为 CurrentContext。

​	key：键，字节数组或字符串。

返回值：void。

## 示例

```c#
public class Contract1 : SmartContract
{
    public static void Main()
    {
        Storage.Delete("contract");
    }
}
```



[返回上级](../Storage.md)
