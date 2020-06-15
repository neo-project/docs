# getMaxBlockSize 方法

获取区块最大大小。

## 所属合约

	PolicyContract

## 调用示例

请求正文：

```json
var result = Contract.Call(policyHash, "getMaxBlockSize", new object[] { });
```

响应正文：

```json
{
	"Type":"Integer",
	"value":"500"
}
```

响应说明：

- Integer类型：成功获取区块最大大小。

- 其他：失败。
