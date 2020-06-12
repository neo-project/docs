# getFeePerByte 方法

获取交易每字节网络费。

## 所属合约

	PolicyContract

## 调用示例

请求正文：

```
var result = Contract.Call(policyHash, "getFeePerByte", new object[] { });
```

响应正文：

```
{
	"Type":"Integer",
	"value":"300"
}
```

响应说明：

- Integer类型：成功获取交易每字节网络费。

- 其他：失败。
