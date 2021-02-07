# BalanceOf 方法 (UInt160)

查询指定地址中已注册的二级域名个数。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework


## 语法

```c#
public static extern BigInteger BalanceOf(UInt160 owner);
```

参数：

- owner: 要查询的地址哈希

## 示例

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

public class Demo : SmartContract
{
    public static object BalanceOf(UInt160 Owner) => NameService.BalanceOf(Owner);
}
```

部署后调用该合约 `invoke 0x1b75e6ea52b9a825ec8d55038296970bf4641696 balanceOf [{"type":"Hash160","value":"0x75b75932a1451cc0c56a95eff7fcc01de45aa5a3"}]`，响应正文为：

```json
[{
    "type":"Integer",
    "value":"1"
}]
```

响应说明：

- Integer类型：指定账户注册的域名数。

- 其他：失败。

[返回上级](../NameService.md)