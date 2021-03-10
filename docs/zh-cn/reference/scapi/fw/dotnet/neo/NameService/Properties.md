# Properties 方法 (string)

域名的属性信息。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Map<string, object> Properties(string name);
```

参数：

- name：域名名称。

## 示例

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static object Properties(string name) { return NameService.Properties(name); }
}
```

部署后，调用该合约 `invoke 0x2ba77f19d8294e9d32c59a18b005cc82353d6ccc properties [{"type":"String","value":"test.com"}]`，响应正文为：

```json
[{
    "type":"Map","value":[
    {"key":{"type":"ByteString","value":"bmFtZQ=="},"value":{"type":"ByteString","value":"dGVzdC5jb20="}}, // admin信息
    {"key":{"type":"ByteString","value":"ZGVzY3JpcHRpb24="},"value":{"type":"ByteString","value":""}},  // 域名描述信息
    {"key":{"type":"ByteString","value":"ZXhwaXJhdGlvbg=="},"value":{"type":"Integer","value":"1643630146"}}  // 域名过期时间
    ]
}]
```

响应说明：

- Map类型：域名的属性信息，包括：管理员admin、域名描述信息以及过期时间；

- 其他：失败。

[返回上级](../NameService.md)