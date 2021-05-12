# GetFeePerByte 方法

获取交易每字节网络费。

命名空间：[Neo.SmartContract.Framework.Native](../../Neo.SmartContract.Framework.Native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern BigInteger GetFeePerByte();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        BigInteger result = Policy.GetFeePerByte();
        return result;
    }
}
```

部署后，调用该合约，响应正文为：

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