# BalanceOf 方法 (byte[])

获取账户的NEO余额。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern BigInteger BalanceOf(byte[] account);
```

参数：

- account: 所查询账户的脚本哈希

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();

    public static object Main()
    {
        BigInteger result = NEO.BalanceOf(account);
        return result;
    }
}
```

[返回上级](../Neo.md)