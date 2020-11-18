# UnclaimedGas 方法 (byte[], uint)

获取未领取的Gas数.

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern BigInteger UnclaimedGas(byte[] account, uint end);
```

参数：

- account: 所查询账户的脚本哈希；
- end：截止到的区块高度

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();

    public static object Main()
    {
        BigInteger result = NEO.UnclaimedGas(account, 100);
        return result;
    }
}
```

[返回上级](../Neo.md)