# Storage 类

提供了持久化存储区的插入、查询、删除的方法。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集: Neo.SmartContract.Framework

## 语法

```c#
public static class Storage
```

## 属性

| 名称                                        | 说明                 |
| ------------------------------------------- | -------------------- |
| [CurrentContext](Storage/CurrentContext.md) | 获取当前存储区上下文 |

## 方法

- 删除操作，在持久化存储区中通过 key 删除对应的 value
  - [Delete(StorageContext, string)](Storage/Delete.md) 
  - [Delete(StorageContext, byte[])](Storage/Delete.md)
  - [Delete(byte[])](Storage/Delete.md) 
  - [Delete(string)](Storage/Delete.md)

- 遍历操作，在持久化存储区中通过 key 的前缀查询对应的 value 集合
  - [Find(StorageContext, byte[])](Storage/Find.md)
  - [Find(StorageContext, string)](Storage/Find.md) 
  - [Find(byte[])](Storage/Find.md)
  - [Find(string)](Storage/Find.md)

- 查询操作，在持久化存储区中通过 key 查询对应的 value
  - [Get(StorageContext, byte[])](Storage/Get.md)
  - [Get(StorageContext, string)](Storage/Get.md) 
  - [Get(byte[])](Storage/Get.md) 
  - [Get(string)](Storage/Get.md)

- 插入操作，以 key-value 的形式向持久化存储区中插入数据
  - [Put(StorageContext, byte[], byte[])](Storage/Put.md)
  - [Put(StorageContext, byte[], string)](Storage/Put.md)
  - [Put(StorageContext, byte[], BigInteger)](Storage/Put.md) 
  - [Put(StorageContext, string, byte[])](Storage/Put.md)
  - [Put(StorageContext, string, string)](Storage/Put.md)
  - [Put(StorageContext, string, BigInteger)](Storage/Put.md)
  - [Put(byte[], byte[])](Storage/Put.md) 
  - [Put(byte[], string)](Storage/Put.md)
  - [Put(byte[], BigInteger)](Storage/Put.md)
  - [Put(string, byte[])](Storage/Put.md)
  - [Put(string, string)](Storage/Put.md) 
  - [Put(string, BigInteger)](Storage/Put.md)

> [!Note]
>
> 以上方法如果不带 StorageContext，则默认为 CurrentContext。

# 构造方法

Storage 类是静态类，无需构造方法。