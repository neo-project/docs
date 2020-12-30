# transfer 方法

将指定数额的Token从一个地址转往另一地址。

> [!Note]
>
> 需要校验付款人的签名，方法调用者是否为付款人，收款人是否能够收款，以及付款人余额是否充足。

## 所属合约

	Nep17Token

## 参数说明

- `byte[] from`: 付款账户

- `byte[] to`: 收款账户

- `BigInteger amount`: Token数额

## 调用示例

请求正文：

```json
static byte[] from = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
static byte[] to = "NWfRjyLqixtrB8JCW5tuH8MMzgZ7QN3GHj".ToScriptHash();
...
var result = Contract.Call(nep17Hash, "transfer", new object[] { from, to, 10000 });
```

响应正文：

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

响应说明：

- true：成功转账。

- 其他：失败。
