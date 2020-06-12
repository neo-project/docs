# onPersist 方法

手动执行Nep5在持久化区块时进行的操作。

## 所属合约

	NativeContract

## 调用示例

请求正文：

```
var result = Contract.Call(nativeHash, "onPersist", new object[] { });
```

响应正文：

```
{
	"Type":"Void",
	"value":"NULL"
}
```

响应说明：

- Void类型：成功调用。

- 其他：失败。
