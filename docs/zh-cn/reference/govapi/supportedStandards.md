# supportedStandards 方法

返回支持的NEP标准。

## 所属合约

	NativeContract

## 调用示例

请求正文：

```json
var result = Contract.Call(nativeHash, "supportedStandards", new object[] { });
```

响应正文：

```json
{
	"type": "Array",
	"value": [{
		"type": "ByteString",
		"value": "NEP-17"
	}, {
		"type": "ByteString",
		"value": "NEP-10"
	}]
}
```

响应说明：

- Array类型：返回支持的NEP标准。

- 其他：失败。
