# getMaxTransactionsPerBlock 方法

获取区块包含最大交易量。

## 所属合约

	PolicyContract

## 调用示例

请求正文：

```
var result = Contract.Call(policyHash, "getMaxTransactionsPerBlock", new object[] { });
```

响应正文：

```
{
	"Type":"Integer",
	"value":"500"
}
```

响应说明：

- Integer类型：成功获取区块包含最大交易量。

- 其他：失败。
