# Storage.Delete 方法 

删除操作，从给定的存储上下文中删除给定键对应的值。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern void Delete(StorageContext context, byte[] key);
public static extern void Delete(StorageContext context, string key);
```
参数：

- context：存储上下文，[StorageContext](../StorageContext.md) 类型;
- key：键，字节数组或者字符串。

返回值：void。

```c#
public static extern void Delete(byte[] key);
public static extern void Delete(string key);
```
参数：

- key：键，字节数组/字符串。

返回值：void。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        Storage.Delete(Storage.CurrentContext, "aa");
        Storage.Delete(Storage.CurrentContext, new byte[] { 0 });
        Storage.Delete("aa");
        Storage.Delete(new byte[] { 0 });
    }
}
```



[返回上级](../Storage.md)
