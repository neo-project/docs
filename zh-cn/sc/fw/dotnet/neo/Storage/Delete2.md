# Storage.Delete 方法 (StorageContext, string)

删除操作，在持久化存储区中通过 key 删除对应的 value。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public extern void Delete(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

参数：
​	context：存储上下文，[StorageContext](../StorageContext.md) 类型。

​	key：键，string 类型。

返回值：void。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        Storage.Delete(Storage.CurrentContext, "Key");
    }
}
```



[返回上级](../Storage.md)
