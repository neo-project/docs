# NEO.TotalSupply 方法

获取NEO总发行量。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern BigInteger TotalSupply();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        BigInteger result = NEO.TotalSupply();
        return result;
    }
}
```

部署后，调用该合约，响应正文为：

```json
{
	"Type":"Integer",
	"value":"100000000"
}
```

响应说明：

- Integer类型：成功获取Token当前流通量。

- 其他：失败。

[返回上级](../Neo.md)