# Role 类

定义了 RoleManagement 原生合约中的权限类型。

命名空间：[Neo.SmartContract.Framework.Native](../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public enum Role : byte
{
    StateValidator = 4,
    Oracle = 8
}
```

具体使用参考 [RoleManagement](RoleManagement.md) 类的中的 GetDesignatedByRole 方法。