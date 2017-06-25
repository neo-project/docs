# Storage.Put 方法 (StorageContext, byte[], byte[])

插入操作，以 key-value 的形式向持久化存储区中插入数据。

命名空间：[AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

程序集：AntShares.SmartContract.Framework

## 语法

```c#
public extern void Put(AntShares.SmartContract.Framework.Services.AntShares.StorageContext context, byte[] key, byte[] value)
```

参数：
​	context：存储上下文，[StorageContext](../StorageContex.md) 类型。

​	key：键，字节数组。

​	value：值，字节数组。

返回值：void。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[] key = new byte[] { 0 };
        byte[] value = new byte[] { 1 };
        Storage.Put(Storage.CurrentContext, key, value);
    }
}
```



[返回上级](../Storage.md)