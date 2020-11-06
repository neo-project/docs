# GetCandidates 方法 ()

获取候选人列表。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern (string, BigInteger)[] GetCandidates();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        (string, BigInteger)[] result = NEO.GetCandidates();
        return result;
    }
}
```

[返回上级](../Neo.md)