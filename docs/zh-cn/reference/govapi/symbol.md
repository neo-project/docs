# symbol 方法

返回Token标志。

## 所属合约

	Nep17Token

## 调用示例

请求正文：

```json
var result = Contract.Call(nep17Hash, "symbol", new object[] { });
```

响应正文：

```json
{
	"Type":"ByteString",
	"value":"neo"
}
```

响应说明：

- ByteString类型：成功获取Token标志。

- 其他：失败。
