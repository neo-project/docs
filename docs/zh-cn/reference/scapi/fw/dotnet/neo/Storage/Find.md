# Storage.Find 方法

遍历操作，在持久化存储区中通过 key 的前缀查询对应的 value 集合。

注：Find 方法不能和 StorageMap 一同使用，这点略微遗憾。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Iterator<byte[], byte[]> Find(StorageContext context, byte[] prefix)
```

```c#
public static extern Iterator<string, byte[]> Find(StorageContext context, string prefix)
```

```c#
public static extern Iterator<byte[], byte[]> Find(byte[] prefix)
```

```c#
public static extern Iterator<string, byte[]> Find(string prefix)
```

参数：
	context：存储上下文，[StorageContext](../StorageContext.md) 类型。如果不带 StorageContext，则默认为 CurrentContext。

​	prefix：前缀，字节数组或字符串。

返回值：[Iterator\<string, byte[]>](../Iterator.md) 或 [Iterator\<byte[], byte[]>]((../Iterator.md))。

## 示例

```c#
public class Contract1 : SmartContract
{
    public static void Main()
    {
        var iterator = Storage.Find(new byte[] { 0x01 });
		while (iterator.Next())
		{
    		var k = iterator.Key;
    		var v = iterator.Value;
    		……
		}
    }
}
```



[返回上级](../Storage.md)
