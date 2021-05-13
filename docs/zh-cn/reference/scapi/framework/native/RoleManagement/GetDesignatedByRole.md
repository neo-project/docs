# RoleManagement.GetDesignatedByRole方法

通过交易哈希 ，查找交易所在的区块。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Cryptography.ECC.ECPoint[] GetDesignatedByRole(Role role, uint index);
```

参数：

- hash: 所查询交易的哈希

## 示例

```c#
public static void Test()
{
    var nodes = RoleManagement.GetDesignatedByRole(Role.Oracle, 0);
}
```
[返回上级](../RoleManagement.md)

