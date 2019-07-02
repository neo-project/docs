# Storage.Get 方法 (StorageContext, byte[])

查询操作，在持久化存储区中通过 key 查询对应的 value。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public extern byte[] Get(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

参数：
​	context：存储上下文，[StorageContext](../StorageContext.md) 类型。

​	key：键，字节数组。

返回值：key 对应的 value，字节数组。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[] value = Storage.Get(Storage.CurrentContext, new byte[] { 0 });
    }
}
```



[返回上级](../Storage.md)
