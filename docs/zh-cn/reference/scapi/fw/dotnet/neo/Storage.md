# Storage 类

提供了持久化存储区的插入、查询、删除的方法。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static class Storage
```

## 属性

| 名称                                       | 说明         |
| ---------------------------------------- | ---------- |
| [CurrentContext](Storage/CurrentContext.md) | 获取当前存储区上下文 |
| CurrentReadOnlyContext | 以只读方式获取当前合约存储区的上下文 |

## 方法

| 名称                                       | 说明                               |
| ---------------------------------------- | -------------------------------- |
| [Delete(StorageContext context, byte[] key)](Storage/Delete.md) | 删除操作，从给定的存储上下文中删除byte[]键对应的值  |
| [Delete(StorageContext context, string key)](Storage/Delete.md) | 删除操作，从给定的存储上下文中删除字符串类型的键对应的值 |
| [Delete(string key)](Storage/Delete.md) | 删除操作，从当前存储上下文中删除字符串类型的键对应的值 |
| [Delete(byte[] key)](Storage/Delete.md) | 删除操作，从当前存储上下文中删除byte[]的键对应的值 |
| [Get(StorageContext context, byte[] key)](Storage/Get.md) | 查询操作，返回与给定存储上下文的给定byte[]键对应的byte[]值  |
| [Get(StorageContext context, string key)](Storage/Get.md) | 查询操作，返回与给定存储上下文的给定字符串类型键对应的byte[]值  |
| [Get(byte[] key)](Storage/Get.md) | 查询操作，返回与当前存储上下文的给定byte[]键对应的byte[]值  |
| [Get(string key)](Storage/Get.md) | 查询操作，返回与当前存储上下文的给定字符串类型键对应的byte[]值 |
| [Put(StorageContext context, byte[] key, byte[] value)](Storage/Put.md) | 插入操作，向给定的存储上下文插入byte[]-byte[]形式的key-value对 |
| [Put(StorageContext, byte[] key, string value)](Storage/Put.md) | 插入操作，向给定的存储上下文插入byte[]-string形式的key-value对 |
| [Put(StorageContext, string key, byte[] value)](Storage/Put.md) | 插入操作，向给定的存储上下文插入string-byte[]形式的key-value对 |
| [Put(StorageContext, string key, string value)](Storage/Put.md) | 插入操作，向给定的存储上下文插入string-string形式的key-value对 |
| [Put(StorageContext context, byte[] key, BigInteger value)](Storage/Put.md) | 插入操作，向给定的存储上下文插入byte[]-BigInteger形式的key-value对 |
| [Put(StorageContext context, string key, BigInteger value)](Storage/Put.md) | 插入操作，向给定的存储上下文插入string-BigInteger形式的key-value对 |
| [Put(byte\[\] key, byte[] value)](Storage/Put.md) | 插入操作，向当前存储上下文插入byte[]-byte[]形式的key-value对 |
| [Put(byte[] key, BigInteger value)](Storage/Put.md) | 插入操作，向当前存储上下文插入byte[]-BigInteger形式的key-value对 |
| [Put(byte[] key, string value)](Storage/Put.md) | 插入操作，向当前存储上下文插入byte[]-string形式的key-value对 |
| [Put(string key, byte[] value)](Storage/Put.md) | 插入操作，向当前存储上下文插入string-byte[]形式的key-value对 |
| [Put(string key, BigInteger value)](Storage/Put.md) | 插入操作，向当前存储上下文插入string-BigInteger形式的key-value对 |
| [Put(string key, string value)](Storage/Put.md) | 插入操作，向当前存储上下文插入string-string形式的key-value对 |
| [PutEx(byte[\] key, byte[] value, StorageFlags flags)](Storage/PutEx.md) | 插入操作，向当前存储上下文插入byte[]-byte[]形式的key-value对，并将数据属性设定为flags |
| [PutEx(byte[] key, BigInteger value, StorageFlags flags)](Storage/PutEx.md) | 插入操作，向当前存储上下文插入byte[]-BigInteger形式的key-value对，并将数据属性设定为flags |
| [PutEx(byte[] key, string value, StorageFlags flags)](Storage/PutEx.md) | 插入操作，向当前存储上下文插入byte[]-string形式的key-value对，并将数据属性设定为flags |
| [PutEx(string key, byte[] value, StorageFlags flags)](Storage/PutEx.md) | 插入操作，向当前存储上下文插入string-byte[]形式的key-value对，并将数据属性设定为flags |
| [PutEx(string key, BigInteger value, StorageFlags flags)](Storage/PutEx.md) | 插入操作，向当前存储上下文插入string-BigInteger形式的key-value对，并将数据属性设定为flags |
| [PutEx(string key, string value, StorageFlags flags)](Storage/PutEx.md) | 插入操作，向当前存储上下文插入string-string形式的key-value对，并将数据属性设定为flags |
| [Find(StorageContext context, byte[] prefix)](Storage/Find.md) | 查询操作，查找指定存储上下文中byte[]前缀的内容  |
| [Find(StorageContext context, string prefix)](Storage/Find.md) | 查询操作，查找指定存储上下文中string前缀的内容  |
| [Find(byte[] prefix)](Storage/Find.md) | 查询操作，查找当前存储上下文中byte[]前缀的内容  |
| [Find(string prefix)](Storage/Find.md) | 查询操作，查找当前存储上下文中string前缀的内容  |

## 构造方法

Storage 类是静态类，无需构造方法。