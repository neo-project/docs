# getNextBlockValidators 方法

获取下个块（正在持久化的块）的共识节点成员。

## 所属合约

	NeoToken

## 调用示例

请求正文：

```json
var result = Contract.Call(neoHash, "getNextBlockValidators", new object[] { });
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

- Array类型：成功获取下轮共识节点成员。

- 其他：失败。
