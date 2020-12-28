# SetMaxBlockSystemFee 方法

设置区块最大系统手续费。

> [!Note]
> 设置的值需大于0.04007600 GAS
> 需要验证委员会的多签。签名超过委员会数量的一半的向上取整即为有效，相应操作将被执行。

## 所属合约

	PolicyContract

## 参数说明

`long maxSystemFee`: 区块最大系统手续费

## 调用示例

请求正文：

```json
var result = Contract.Call(policyHash, "setMaxBlockSystemFee", new object[] { 1000 });
```

响应正文：

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

响应说明：

- true：设置区块包含最大交易量成功。

- 其他：失败。
