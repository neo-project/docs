# GetNextBlockValidators 方法 ()

获取下个区块的验证人列表。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern ECPoint[] GetNextBlockValidators();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        ECPoint[] result = NEO.GetNextBlockValidators();
        return result;
    }
}
```
响应正文：

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