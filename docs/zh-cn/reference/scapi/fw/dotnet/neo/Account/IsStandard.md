# Account.IsStandard 方法 ()

该账户是否是标准账户。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern bool IsStandard(byte[] scripthash)
```

参数：账户的脚本哈希。

返回值：该账户是否是标准账户。

## 示例

```c#
public class Contract1 : SmartContract
{
    public static void Main()
    {
        byte[] scriptHash = { 36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73 };
        var isStandard = Account.IsStandard(scriptHash);
    }
}
```



[返回上级](../Account.md)