# name 方法

返回合约名称。

## 所属合约

	NativeContract

## 调用示例

请求正文：

```json
var result = Contract.Call(nativeHash, "name", new object[] { });
```

响应正文：

```json
{
	"Type":"ByteString",
	"value":"NEO"
}
```

响应说明：

- ByteString类型：成功获取合约名称。

- 其他：失败。
