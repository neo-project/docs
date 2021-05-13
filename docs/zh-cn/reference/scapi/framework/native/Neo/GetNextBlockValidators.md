# NEO.GetNextBlockValidators 方法

获取下个区块的验证人列表。候选人将根据得票数排序，取最前面一定数量的候选人（默认7个）作为共识节点。与委员会类似，共识节点名单将在每个区块根据最新投票更新。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern ECPoint[] GetNextBlockValidators();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        ECPoint[] result = NEO.GetNextBlockValidators();
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

- Array类型：成功获取下轮共识节点成员。

- 其他：失败。

[返回上级](../Neo.md)