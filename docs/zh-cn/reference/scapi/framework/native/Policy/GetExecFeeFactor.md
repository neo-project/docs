# Policy.GetExecFeeFactor方法

获取vm执行费率。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern uint GetExecFeeFactor();
```

返回值：

- vm执行费率

## 示例

```c#
public static void Test()
{
    var factor = Policy.GetExecFeeFactor();
}
```
[返回上级](../Policy.md)

