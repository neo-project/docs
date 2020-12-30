# decimals 方法

返回Token精度。

## 所属合约

	Nep17Token

## 调用示例

请求正文：

```json
var result = Contract.Call(nep17Hash, "decimals", new object[] { });
```

响应正文：

```json
{
	"Type":"Integer",
	"value":"0"
}
```

响应说明：

- Integer类型：成功获取Token精度。

- 其他：失败。
