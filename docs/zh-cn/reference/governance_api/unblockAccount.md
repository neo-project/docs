# unblockAccount 方法

解除屏蔽地址。

> [!Note]
>
> - 需要验证委员会的多签。签名超过委员会数量的一半的向上取整即为有效，相应操作将被执行。

## 所属合约

	PolicyContract

## 参数说明

- byte[] account: 被解除屏蔽的地址

## 调用示例

请求正文：

```
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
...
var result = Contract.Call(policyHash, "unblockAccount", new object[] { account });
```

响应正文：

```
{
	"Type":"Boolean",
	"value":"true"
}
```

响应说明：

- true：解除屏蔽地址成功。

- 其他：失败。
