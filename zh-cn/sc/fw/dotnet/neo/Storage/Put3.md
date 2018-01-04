# Storage.Put 方法 (StorageContext, string, byte[])

插入操作，以 key-value 的形式向持久化存储区中插入数据。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key, byte[] value)
```

参数：
​	context：存储上下文，[StorageContext](../StorageContext.md) 类型。

​	key：键，字符串。

​	value：值，字节数组。

返回值：void。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        string key = "key";
        byte[] value = new byte[] { 1 };
        Storage.Put(Storage.CurrentContext, key, value);
    }
}
```



[返回上级](../Storage.md)
