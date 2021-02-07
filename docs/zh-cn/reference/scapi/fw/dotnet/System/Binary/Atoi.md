# Binary.Atoi 方法

将字符串转换为特定进制的数值表示。可以是10进制或者16进制数，默认是10进制。

命名空间：[Neo.SmartContract.Framework.Services.System](../../system.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern BigInteger Atoi(string value, int @base = 10);
```

参数：
- value：待转换的字符串
- base：数值的进位制

返回值：等价的数值。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Convert()
    {
        return Binary.Atoi("ff", 16); 
    }
}
```

部署后，调用该合约，响应正文为：

```json
[{
    "type":"Integer",
    "value":"-1"
}]
```

响应说明：

- Integer类型：等价的数值。

- 其他：失败。

[返回上级](../Binary.md)