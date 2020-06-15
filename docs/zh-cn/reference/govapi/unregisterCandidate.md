# unregisterCandidate 方法

注销候选人。

> [!Note]
>
> 注销候选人需要验证候选人地址的签名，即只有候选人自己才能执行注册/注销操作。

## 所属合约

	NeoToken

## 参数说明

`byte[] publicKey`：被注销的候选人公钥

## 调用示例

请求正文：

```json
static byte[] pubkey = "024b817ef37f2fc3d4a33fe36687e592d9f30fe24b3e28187dc8f12b3b3b2b839e".HexToBytes();
...
var result = Contract.Call(neoHash, "unregisterCandidate", new object[] { pubkey });
```

响应正文：

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

响应说明：

- true：注销候选人成功。

- 其他：失败。
