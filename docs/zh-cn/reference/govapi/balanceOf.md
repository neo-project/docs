# balanceOf 方法

返回该账户的余额。

## 所属合约

	Nep17Token

## 参数说明

`byte[] account`: 查询账户

## 调用示例

请求正文：

```json
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
...
var result = Contract.Call(nep17Hash, "balanceOf", new object[] { account });
```

响应正文：

```json
{
	"Type":"Integer",
	"value":"100000000"
}
```

响应说明：

- Integer类型：成功获取该账户的余额。

- 其他：失败。
