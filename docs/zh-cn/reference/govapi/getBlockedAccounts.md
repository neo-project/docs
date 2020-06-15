# getBlockedAccounts 方法

获取被屏蔽地址。

## 所属合约

	PolicyContract

## 调用示例

请求正文：

```json
var result = Contract.Call(policyHash, "getBlockedAccounts", new object[] { });
```

响应正文：

```json
{
	"type": "Array",
	"value": [{
		"type": "Struct",
		"value": [{
			"type": "ByteString",
			"value": "AkuBfvN/L8PUoz/jZoflktnzD\u002BJLPigYfcjxKzs7K4Oe"
		}, {
			"type": "Integer",
			"value": "0"
		}]
	}]
}
```

响应说明：

- Array类型：成功获取被屏蔽地址。

- 其他：失败。
