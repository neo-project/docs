# StorageMap 类

表示给定存储上下文中指定前缀的key-value存储区。

命名空间：[Neo.SmartContract.Framework.Services](../services.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class StorageMap
```

## 属性

| 名称                                       | 说明         |
| ---------------------------------------- | ---------- |
| Context | 存储上下文 |
| Prefix | 前缀 |

## 方法

| 名称   | 说明                                                         |
| ------ | ------------------------------------------------------------ |
| Delete | 删除操作，从当前存储上下文中删除键对应的值，该方法有多个重载 |
| Get    | 查询操作，返回与给定存储上下文的给定键对应的byte[]值，该方法有多个重载 |
| Put    | 插入操作，向给定的存储上下文插入key-value对，该方法有多个重载 |
| Find   | 查询操作，查找指定存储上下文中的内容，该方法有多个重载       |

