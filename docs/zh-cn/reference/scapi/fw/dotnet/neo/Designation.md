# Designation 类

提供了原生合约Designation的一系列方法，合约哈希为`0xc0073f4c7069bf38995780c9da065f9b3949ea7a`。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Designation
```

## 属性

| 名称              | 说明                                                         |
| ----------------- | ------------------------------------------------------------ |
| Hash              | 合约哈希                                             |

## 方法

| 名称                                                         | 说明                                                         |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [GetDesignatedByRole(DesignationRole role, uint index)](Designation/GetDesignatedByRole.md)          | 获取指定区块高度下，特定角色的节点公钥数组                                     |

其中，`DesignationRole`代表的节点类型有以下两种值：

```c#
public enum DesignationRole : byte
{
    StateValidator = 4,
    Oracle = 8
}
```