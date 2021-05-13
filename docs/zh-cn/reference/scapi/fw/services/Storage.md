# Storage 类

提供了持久化存储区的插入、查询、删除的方法。

命名空间：[Neo.SmartContract.Framework.Services](../services.md)

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
| [Delete](Storage/Delete.md) | 删除操作，从当前存储上下文中删除键对应的值，该方法有多个重载 |
| [Get](Storage/Get.md) | 查询操作，返回与给定存储上下文的给定键对应的byte[]值，该方法有多个重载 |
| [Put](Storage/Put.md) | 插入操作，向给定的存储上下文插入key-value对，该方法有多个重载 |
| [Find](Storage/Find.md) | 查询操作，查找指定存储上下文中的内容，该方法有多个重载 |


## 构造方法

Storage 类是静态类，无需构造方法。