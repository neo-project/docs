# Storage.Get 方法 (StorageContext, string)

查询操作，在持久化存储区中通过 key 查询对应的 value。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public extern void Delete(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key)
```

参数：
​	context：存储上下文，[StorageContext](../StorageContext.md) 类型。

​	key：键，string 类型。

返回值：key 对应的 value，字节数组。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[] value = Storage.Get(Storage.CurrentContext, "key");
    }
}
```



[返回上级](../Storage.md)
