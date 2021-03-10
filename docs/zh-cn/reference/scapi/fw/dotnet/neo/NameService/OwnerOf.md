# OwnerOf 方法 (string)

查询指定二级域名的所属账户地址

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

> [!Note]
>
> 只支持二级域名的查询。

## 语法

```c#
public static extern UInt160 OwnerOf(string name);
```

参数：

- name: 要查询的二级域名名称

## 示例

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

public class Demo : SmartContract
{
    public static UInt160 OwnerOf(string name) => NameService.OwnerOf(name);
}

```

部署后，调用该合约 `invoke 0xb35825371fd5ba98a58b4b043aa62e7b0082fd88 ownerOf [{"type":"String","value":"test.com"}]`，响应正文为：

```json
[{
    "type":"ByteString",
    "value":"o6Va5B3A/PfvlWrFwBxFoTJZt3U="
}]
```

响应说明：

- ByteString类型：域名所属账户地址的Base64编码格式字符串。

- 其他：失败。

[返回上级](../NameService.md)