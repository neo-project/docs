# GetCandidates 方法 ()

获取候选人列表。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern (ECPoint, BigInteger)[] GetCandidates();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        (ECPoint, BigInteger)[] result = NEO.GetCandidates();
        return result;
    }
}
```
响应正文：

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

- Array类型：成功获取候选人列表。

- 其他：失败。


[返回上级](../Neo.md)