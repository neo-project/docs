# Helper 类

合约存储区的辅助方法，包括创建StorageMap对象、获取元素、删除元素、更新元素操作。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static class Helper
```

## 方法

| 名称                                                   | 说明                                                         |
| ------------------------------------------------------ | ------------------------------------------------------------ |
| CreateMap(this StorageContext context, string prefix)  | 创建StorageMap对象                                           |
| CreateMap(this StorageContext context, byte[] prefix)  | 创建StorageMap对象                                           |
| CreateMap(this StorageContext context, byte prefix)    | 创建StorageMap对象                                           |
| Delete(this StorageMap map, byte[] key)                | 删除存储上下文中给定的字节数组类型的键                       |
| Delete(this StorageMap map, string key)                | 删除存储上下文中给定的字符串类型的键                         |
| Get(this StorageMap map, byte[] key)                   | 返回与存储上下文的给定字节数组类型的键对应的字节数组类型的值 |
| Get(this StorageMap map, string key)                   | 返回与存储上下文的给定字符串类型的键对应的字节数组类型的值   |
| Put(this StorageMap map, byte[] key, byte[] value      | 在给定存储上下文的字节数组类型的键上写入字节数组类型的值     |
| Put(this StorageMap map, byte[] key, BigInteger value) | 在给定存储上下文的字节数组类型的键上写入BigInteger类型的值   |
| Put(this StorageMap map, byte[] key, string value)     | 在给定的存储上下文的字节数组类型的键上写入字符串类型的值     |
| Put(this StorageMap map, string key, byte[] value)     | 在给定存储上下文的字符串类型的键上写入字节数组类型的值       |
| Put(this StorageMap map, string key, BigInteger key)   | 在给定存储上下文的字符串类型的键上写入BigInteger类型的值     |
| Put(this StorageMap map, string key, string value)     | 在给定存储上下文的字符串类型的键上写入字符串类型的值         |

## 构造方法

Helper 类是静态类，无需构造方法。