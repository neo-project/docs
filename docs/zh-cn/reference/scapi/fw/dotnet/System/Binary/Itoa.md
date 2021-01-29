# Binary.Itoa 方法

将特定类型的数值转换为字符串表示。可以是10进制或者16进制数，默认是10进制。

命名空间：[Neo.SmartContract.Framework.Services.System](../../system.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern string Itoa(BigInteger value, int @base = 10);
public static extern string Itoa(int value, int @base = 10);
public static extern string Itoa(uint value, int @base = 10);
public static extern string Itoa(long value, int @base = 10);
public static extern string Itoa(ulong value, int @base = 10);
public static extern string Itoa(short value, int @base = 10);
public static extern string Itoa(ushort value, int @base = 10);
public static extern string Itoa(byte value, int @base = 10);
public static extern string Itoa(sbyte value, int @base = 10);
```

参数：
- value： 指定类型的数值
- base：数值的进位制

返回值：Base64编码的字符串。

注：`value`可为`BigInteger, int, uint, long, ulong, short, ushort, byte, sbyte9`种类型。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Convert()
    {
        return Binary.Itoa(-1, 16); // Convert.ToBase64String(((ByteString)"f").GetSpan())
    }
}
```

部署后，调用该合约，响应正文为：

```json
[{
    "type":"ByteString",
    "value":"Zg=="
}]
```

响应说明：

- ByteString类型：Base64编码的字符串。

- 其他：失败。

[返回上级](../Binary.md)