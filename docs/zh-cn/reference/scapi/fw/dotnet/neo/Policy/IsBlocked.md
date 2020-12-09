# IsBlocked 方法 (byte[])

验证是否为黑名单账户。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern string[] IsBlocked(UInt160 account);
```

参数：

- account: 待验证账户的脚本哈希

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();

    public static object Main()
    {
        bool result = Policy.IsBlocked(account);
        return result;
    }
}
```

响应正文：

```json
{
	"type":"Boolean",
	"value":"false"
}
```

响应说明：

- Boolean类型：true表示账户已被屏蔽。

- 其他：失败。

[返回上级](../Policy.md)