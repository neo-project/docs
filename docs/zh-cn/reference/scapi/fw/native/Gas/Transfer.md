# GAS.Transfer 方法

GAS转账。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern bool Transfer(UInt160 from, UInt160 to, BigInteger amount, object data = null);
```

参数：

- from: 转出账户的脚本哈希；
- to: 转入账户的脚本哈希；
- amount: 要转账的金额。
- data：额外参数，在 NEP-17 的转账方法中会调用接收方的 onNEP17Payment 方法，并将 data 作为参数传入。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 from = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();
    private static readonly UInt160 to = "NXjtqYERuvSWGawjVux8UerNejvwdYg7eE".ToScriptHash();

    public static object Test()
    {
        bool result = GAS.Transfer(from, to, 1000);
        return result;
    }
}
```

部署后，调用该合约，响应正文为：

```json
{
	"type":"Boolean",
	"value":"true"
}
```

响应说明：

- Boolean类型：true表示成功转账。

- 其他：失败。

[返回上级](../Gas.md)