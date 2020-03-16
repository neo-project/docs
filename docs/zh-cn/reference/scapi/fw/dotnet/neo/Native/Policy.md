# Native.Policy 方法 (string, object[])

根据方法名与方法参数调用Policy合约中的方法。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern object Policy(string method, object[] arguments);
```

参数：

- method: 方法名称；
- arguments: 方法参数。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        BigInteger feeByte = (BigInteger)Native.Policy("getFeePerByte", new object[]{});
    }
}
```

[返回上级](../Native.md)
