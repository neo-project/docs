# Native.GAS 方法 (string, object[])

根据方法名与方法参数调用GAS合约中的方法。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern object GAS(string method, object[] arguments);
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
        byte[] from = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW".ToScriptHash();
        byte[] to = "NUo4WsPRJCrSLriRhKwduWvoG2CxHwsdfi".ToScriptHash();
        BigInterger value = new BigInteger(1000);
        bool result = Native.GAS("transfer", new Object[]{from, to, value.AsByteArray()});
        return result;
    }
}
```

[返回上级](../Native.md)
