# getMaxBlockSystemFee 方法

获取区块最大系统手续费。

## 所属合约

	PolicyContract

## 调用示例

请求正文：

```json
var result = Contract.Call(policyHash, "getMaxBlockSystemFee", new object[] { });
```

响应正文：

```json
{
	"Type":"Integer",
	"value":"900000000000"
}
```

响应说明：

- Integer类型：成功获取区块最大手续费。

- 其他：失败。
