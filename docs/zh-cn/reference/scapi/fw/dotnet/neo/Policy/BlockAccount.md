# BlockAccount 方法 (byte[])

将指定账户加入黑名单。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern bool BlockAccount(byte[] account);
```

参数：

- account: 待加入黑名单的账户脚本哈希

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] account = "NirHUAteaMr6CqWuAAMaEUScPcS3FDKebM".ToScriptHash();

    public static object Main()
    {
        bool result = Policy.BlockAccount(account);
        return result;
    }
}
```

[返回上级](../Policy.md)
