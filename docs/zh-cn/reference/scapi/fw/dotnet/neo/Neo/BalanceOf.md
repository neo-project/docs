# BalanceOf 方法 (UInt160)

获取账户的NEO余额。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern BigInteger BalanceOf(UInt160 account);
```

参数：

- account: 所查询账户的脚本哈希

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();

    public static object Main()
    {
        BigInteger result = NEO.BalanceOf(account);
        return result;
    }
}
```

响应正文：

```json
{
	"Type":"Integer",
	"value":"100000000"
}
```

响应说明：

- Integer类型：成功获取该账户的余额。

- 其他：失败。

[返回上级](../Neo.md)