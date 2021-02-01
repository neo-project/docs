# Transfer 方法 (UInt160, UInt160, BigInteger)

更新域名的过期时间戳（单位：秒），每调用一次，域名的有效期延长一年时间。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

> [!Note]
> 只能延长已注册的二级域名有效期
> 

## 语法

```c#
public static extern uint Renew(string name);
```

参数：

- name: 待更新有效期的域名名称

## 示例

```c#
pusing Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static uint Renew(string name) { return NameService.Renew(name); }
}
```

部署后，调用该合约`invoke 0xa09b9567b74fc195dd1aded35ec72a6246776b8c renew [{"type":"String","value":"test.com"}]`，响应正文为：

```json
[{
    "type":"Integer",
    "value":"1737883400"
}]
```

响应说明：

- Integer类型：域名的过期时间戳。

- 其他：失败。

[返回上级](../NameService.md)