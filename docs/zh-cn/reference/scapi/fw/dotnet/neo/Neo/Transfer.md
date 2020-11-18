# Transfer 方法 (byte[], byte[], BigInteger)

NEO转账。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern bool Transfer(byte[] from, byte[] to, BigInteger amount);
```

参数：

- from: 转出账户的脚本哈希；
- to: 转入账户的脚本哈希；
- amount: 要转账的金额。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] from = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();
    private static readonly byte[] to = "NXjtqYERuvSWGawjVux8UerNejvwdYg7eE".ToScriptHash();

    public static object Main()
    {
        BigInterger value = 1000;
        bool result = NEO.Transfer(from, to, value);
        return result;
    }
}
```

[返回上级](../Neo.md)