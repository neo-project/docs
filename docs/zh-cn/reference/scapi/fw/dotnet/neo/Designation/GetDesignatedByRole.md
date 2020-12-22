# GetDesignatedByRole 方法 (DesignationRole, uint )

发起Oracle请求。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern ECPoint[] GetDesignatedByRole(DesignationRole role, uint index);
```

参数：

- role: 系统角色；
- index: 区块高度；

其中，DesignationRole为枚举类型，有以下两种类型：
1. StateValidator：代表验证人节点
2. Oracle：代表Oracle节点

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        ECPoint[] oracles = Designation.GetDesignatedByRole(DesignationRole.Oracle, 1000);
        return oracles;
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

- Array类型：Oracle节点列表。

- 其他：失败。

[返回上级](../Designation.md)
