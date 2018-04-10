# Storage 类

提供了持久化存储区的插入、查询、删除的方法。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static class Storage
```

## 属性

|                                          | 名称                                       | 说明         |
| ---------------------------------------- | ---------------------------------------- | ---------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [CurrentContext](Storage/CurrentContext.md) | 获取当前存储区上下文 |

## 方法

|                                          | 名称                                       | 说明                               |
| ---------------------------------------- | ---------------------------------------- | -------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Delete(StorageContext, byte[])](Storage/Delete.md) | 删除操作，在持久化存储区中通过 key 删除对应的 value  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Delete(StorageContext, string)](Storage/Delete2.md) | 删除操作，在持久化存储区中通过 key 删除对应的 value  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Get(StorageContext, byte[])](Storage/Get.md) | 查询操作，在持久化存储区中通过 key 查询对应的 value  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Get(StorageContext, string)](Storage/Get2.md) | 查询操作，在持久化存储区中通过 key 查询对应的 value  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, byte[], byte[])](Storage/Put.md) | 插入操作，以 key-value 的形式向持久化存储区中插入数据 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, byte[], string)](Storage/Put2.md) | 插入操作，以 key-value 的形式向持久化存储区中插入数据 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, string, byte[])](Storage/Put3.md) | 插入操作，以 key-value 的形式向持久化存储区中插入数据 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, string, string)](Storage/Put4.md) | 插入操作，以 key-value 的形式向持久化存储区中插入数据 |

# 构造方法

Storage 类是静态类，无需构造方法。