# NEO.GetCommittee 方法

获取委员会成员列表。候选人将根据得票数排序，最前面一定数量的候选人（默认21个）成为委员会成员。委员会名单将在每个区块根据最新投票更新。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern ECPoint[] GetCommittee();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        ECPoint[] result = NEO.GetCommittee();
        return result;
    }
}
```

部署后，调用该合约，响应正文为：

```json
[{
	"type": "Array",
	"value": [{
		"type": "ByteString",
		"value": "Auj/F8Vn1i8nT\u002BJHzIhKKmzTuP0Nd5qMWFYomlYKzKy0"
	}]
}]
```

响应说明：

- Array类型：成功获取委员会成员。

- 其他：失败。

[返回上级](../Neo.md)