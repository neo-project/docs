# Tokens 方法 ()

查询系统已注册的全部域名。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Iterator<string> Tokens();
```

## 示例

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static object Tokens()
    {
        Iterator<string> result = NameService.Tokens();
        List<string> nameList = new List<string>();
        while (result.Next())
        {
            nameList.Add(result.Value);
        }
        return nameList;
    }
}
```


部署后调用该合约`invoke 0xb51f703aae951c58ebd89d9448bf8cb4c7f2efcc tokens`，响应正文为：

```json
[{"type":"Array","value":
    [{"type":"ByteString","value":"dGVzdDMuY29t"},  //test3.com
    {"type":"ByteString","value":"dGVzdDQuY29t"},   //test4.com
    {"type":"ByteString","value":"dGVzdC5jb20="},   //test.com
    {"type":"ByteString","value":"dGVzdDIuY29t"}]   //test2.com
}]
```

响应说明：

- Array类型：返回系统已注册的所有域名Base64编码的字符串数组。

- 其他：失败。

[返回上级](../NameService.md)