# StorageFlags 类

表明了写入数据的属性，默认None，数据可以被读写。如果是Constant，数据被写入存储区后不能被修改也不能被删除。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
   public enum StorageFlags : byte
    {
        None = 0x00,
        Constant = 0x01
    }
```
