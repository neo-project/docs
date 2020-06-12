# unclaimedGas 方法

返回该账户未领取GAS。

## 所属合约

	NeoToken

## 参数说明

- byte[] account: 查询账户

## 调用示例

请求正文：

```
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
...
var result = Contract.Call(neoHash, "unclaimedGas", new object[] { account });
```

响应正文：

```
{
	"Type":"Integer",
	"value":"100000"
}
```

响应说明：

- Integer类型：成功获取该账户未领取GAS。

- 其他：失败。
