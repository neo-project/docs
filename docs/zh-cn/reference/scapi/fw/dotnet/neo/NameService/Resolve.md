# Resolve 方法 (string, RecordType)

解析域名。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

> [!Note]
>
> 需要校验付款人的签名，方法调用者是否为付款人，收款人是否能够收款，以及付款人余额是否充足。

## 语法

```c#
public static extern string Resolve(string name, RecordType type);
```

参数：

- name: 域名名称；
- type: 域名类型

## 示例

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static string Resolve(string name, byte type) { return NameService.Resolve(name, (RecordType)type); }
}
```
部署后，调用该合约` invoke 0x64405d6cc3b144cd0c2470dac7410ac797b134dc resolve [{"type":"String","value":"test.com"},{"type":"Integer","value":"1"}]`，响应正文为：

```json
[{
    "type":"ByteString",
    "value":"MTI3LjAuMC4x" // 127.0.0.1
}]
```

响应说明：

- ByteString类型：域名解析结果的Base64编码的字符串。

- 其他：失败。

[返回上级](../Neo.md)