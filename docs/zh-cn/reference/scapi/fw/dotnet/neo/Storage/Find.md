# Storage.Find 方法 

查询操作，查找存储上下文中满足指定前缀的内容

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Iterator<byte[], byte[]> Find(StorageContext context, byte[] prefix);
public static extern Iterator<string, byte[]> Find(StorageContext context, string prefix);
```

参数：

- context：存储上下文，[StorageContext](../StorageContext.md) 类型；
- prefix：前缀，字节数组/字符串；

返回值：context中符合条件的元素构成的Iterator。

```c#
public static extern Iterator<byte[], byte[]> Find(byte[] prefix);
public static extern Iterator<string, byte[]> Find(string prefix);
```

参数：
prefix：前缀，字节数组/字符串；

返回值：当前存储上下文中符合条件的元素构成的Iterator。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        byte[] prefix1 = new byte[] { 0 };
        string prefix2 = "aa";
        Storage.Find(Storage.CurrentContext, prefix1);
        Storage.Find(Storage.CurrentContext, prefix2);
        Storage.Find(prefix1);
        Storage.Find(prefix2);
    }
}
```

[返回上级](../Storage.md)
