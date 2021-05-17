# NEO.UnclaimedGas 方法

获取未领取的Gas数.

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern BigInteger UnclaimedGas(UInt160 account, uint end);
```

参数：

- account: 所查询账户的脚本哈希；
- end：截止到的区块高度

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();

    public static object Test()
    {
        BigInteger result = NEO.UnclaimedGas(account, 100);
        return result;
    }
}
```
部署后，调用该合约，响应正文为：

```json
{
	"Type":"Integer",
	"value":"100000"
}
```

响应说明：

- Integer类型：成功获取该账户未领取GAS。

- 其他：失败。

[返回上级](../Neo.md)