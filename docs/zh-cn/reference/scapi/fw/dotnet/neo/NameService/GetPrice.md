# GetPrice 方法 ()

查询注册域名或更新域名有效期所需费用 （精度8位）

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern long GetPrice();
```

## 示例

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static long GetPrice() { return NameService.GetPrice(); }
}
```

部署后调用该合约`invoke 0x0830764620067b85f374ef72b2e4f61b7020c620 getPrice`，响应正文为：

```json
[{
    "type":"Integer",
    "value":"1000000000"
}]
```

响应说明：

- Integer类型：10 Gas。

- 其他：失败。

[返回上级](../NameService.md)