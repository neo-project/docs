# blockAccount 方法

新增屏蔽地址。

> [!Note]
>
> 需要验证委员会的多签。签名超过委员会数量的一半的向上取整即为有效，相应操作将被执行。

## 所属合约

	PolicyContract

## 参数说明

`byte[] account`: 被屏蔽的地址

## 调用示例

请求正文：

```json
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
...
var result = Contract.Call(policyHash, "blockAccount", new object[] { account });
```

响应正文：

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

响应说明：

- true：新增屏蔽地址成功。

- 其他：失败。
