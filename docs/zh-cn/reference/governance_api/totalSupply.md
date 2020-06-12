# totalSupply 方法

返回Token当前流通量。

## 所属合约

	Nep5Token

## 调用示例

请求正文：

```
var result = Contract.Call(nep5Hash, "totalSupply", new object[] { });
```

响应正文：

```
{
	"Type":"Integer",
	"value":"100000000"
}
```

响应说明：

- Integer类型：成功获取Token当前流通量。

- 其他：失败。
