# TotalSupply 方法 ()

获取当前已注册的二级域名总数。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

> [!Note]
>
> 不计入一级域名数

## 语法

```c#
public static extern BigInteger TotalSupply();
```

## 示例

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

public class Demo : SmartContract
{
    public static object TotalSupply() => NameService.TotalSupply();
}
```

部署后，调用该合约 `invoke 0xe1b3691318ebc7450e58866c520a1f893b305307 totalSupply`，响应正文为：

```json
[{
    "type":"Integer",
    "value":"1"
}]
```

响应说明：

- Integer类型：已注册域名的总数。

- 其他：失败。

[返回上级](../NameService.md)