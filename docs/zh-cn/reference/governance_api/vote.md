# vote 方法

给候选人投票。

> [!Note]
>
> - 投给非候选人的地址的票数会被统计但不会被计入票数，只有当该地址注册为候选人投票才会生效。
> - 投票需要验证投票者的签名。

## 所属合约

	NeoToken

## 参数说明

- byte[] account: 投票者账户

- byte[] voteTo: 被投票的候选人公钥

## 调用示例

请求正文：

```
static byte[] account = "NYXBPFgUM2Wa9wUdtEZV3zk1pLWamNEJB1".ToScriptHash();
static byte[] pubkey = "024b817ef37f2fc3d4a33fe36687e592d9f30fe24b3e28187dc8f12b3b3b2b839e".HexToBytes();
...
var result = Contract.Call(neoHash, "vote", new object[] { account, pubkey });
```

响应正文：

```
{
	"Type":"Boolean",
	"value":"true"
}
```

响应说明：

- true：给候选人投票成功。

- 其他：失败。
