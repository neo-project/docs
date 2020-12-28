# isBlocked 方法

获取区块最大大小。

## 所属合约

	PolicyContract

## 调用示例

请求正文：

```c#
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
var result = Contract.Call(policyHash, "isBlocked", new object[] {account });
```

响应正文：

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

响应说明：

- Integer类型：成功获取区块最大大小。

- 其他：失败。
