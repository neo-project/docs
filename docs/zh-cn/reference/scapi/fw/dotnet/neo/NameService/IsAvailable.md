# IsAvailable 方法 (string)

验证指定的二级域名是否可注册。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

> [!Note]
>
> 域名中的一级域名需要先注册，否则会抛出异常.

## 语法

```c#
public static extern bool IsAvailable(string name);
```

参数：

- name: 待验证的二级域名

## 示例

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static bool IsAvailable(string name) { return NameService.IsAvailable(name); }
}
```

部署后，调用该合约 `invoke 0x614a8f0015607d72cba71659ff83dea33cadb0c1 isAvailable [{"type":"String","value":"test.com"}]`，响应正文为：

```json
{
	"type":"Boolean",
	"value":"true"
}
```

响应说明：

- Boolean类型：true表示可注册，false表示已注册。

- 其他：失败。

[返回上级](../NameService.md)