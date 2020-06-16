# setFeePerByte 方法

设置交易每字节网络费。

> [!Note]
>
> 需要验证委员会的多签。签名超过委员会数量的一半的向上取整即为有效，相应操作将被执行。

## 所属合约

	PolicyContract

## 参数说明

`long feePerByte`: 每字节网络费

## 调用示例

请求正文：

```json
var result = Contract.Call(policyHash, "setFeePerByte", new object[] { 30 });
```

响应正文：

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

响应说明：

- true：设置交易每字节网络费成功。

- 其他：失败。
