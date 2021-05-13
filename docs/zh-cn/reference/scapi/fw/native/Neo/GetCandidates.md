# NEO.GetCandidates 方法

获取候选人列表。由于账户NEO余额会随交易而不断变化，而且投票和注册的候选人也在不断变化，因此在每个区块都会根据以上变化更新候选人及相应投票结果。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern (ECPoint, BigInteger)[] GetCandidates();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        (ECPoint, BigInteger)[] result = NEO.GetCandidates();
        return result;
    }
}
```
部署后，调用该合约，响应正文为：

```json
[{
	"type": "Array",
	"value": [{
		"type": "Struct",
		"value": [{
			"type": "ByteString",
			"value": "Apls6R4n/uoL7MTn/cB3Llj8G\u002BuLJ7LUyL/JWBQg4I0y"
		}, {
			"type": "Integer",
			"value": "10000"
		}]
	}]
}]
```

响应说明：

- Array 类型：成功获取候选人列表。

- 其他：失败。


[返回上级](../Neo.md)