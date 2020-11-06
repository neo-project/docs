# GetCommittee 方法 ()

获取委员会成员列表。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern string[] GetCommittee();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        string[] result = NEO.GetCommittee();
        return result;
    }
}
```

[返回上级](../Neo.md)