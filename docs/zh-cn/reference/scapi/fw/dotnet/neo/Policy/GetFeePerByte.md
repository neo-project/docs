# GetFeePerByte 方法 ()

获取交易每字节网络费。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern BigInteger GetFeePerByte();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        BigInteger result = Policy.GetFeePerByte();
        return result;
    }
}
```

响应正文：

```json
{
	"type":"Integer",
	"value":"300"
}
```

响应说明：

- Integer类型：成功获取交易每字节网络费。

- 其他：失败。

[返回上级](../Policy.md)