# TokensOf 方法 (UInt160)

查询指定账户拥有的全部域名。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Iterator<string> TokensOf(UInt160 owner);
```

参数：

- owner: 要查询的账户地址哈希

## 示例

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static object TokensOf(UInt160 owner)
    {
        Iterator<string> result = NameService.TokensOf(owner);
        List<string> nameList = new List<string>();
        while (result.Next())
        {
            nameList.Add(result.Value);
        }
        return nameList;
    }
}
```


部署后调用该合约`invoke 0x5da989558a73c4418d2c05e86cbdd9d07f9edd8b tokensOf [{"type":"Hash160","value":"0x75b75932a1451cc0c56a95eff7fcc01de45aa5a3"}]`，响应正文为：

```json
[{
    "type":"Array","value":
    [{"type":"ByteString","value":"dGVzdDMuY29t"},  //test3.com
    {"type":"ByteString","value":"dGVzdDQuY29t"}]   //test4.com
}]
```

响应说明：

- Array类型：返回账户所拥有的域名Base64编码的字符串数组。

- 其他：失败。

[返回上级](../NameService.md)