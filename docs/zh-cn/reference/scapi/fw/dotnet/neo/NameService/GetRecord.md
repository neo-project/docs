# GetRecord 方法 (string, RecordType)

查询指定域名对应类型的数据内容

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern string GetRecord(string name, RecordType type);
```

参数：

- name: 域名名称
- RecordType: 域名类型

## 示例

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static string GetRecord(string name, byte type) { return NameService.GetRecord(name, (RecordType)type); }
}
```

部署后，调用该合约`invoke 0x2d3b9ae14534f5b324dcd36f141272eac403e955 getRecord [{"type":"String","value":"test.com"},{"type":"Integer","value":"1"}]`，响应正文为：

```json
[{
    "type":"ByteString",
    "value":"MTI3LjAuMC4x"  // 127.0.0.1
}]
```

响应说明：

- ByteString类型：域名对应类型数据的Base64编码的字符串。

- 其他：失败。

[返回上级](../NameService.md)