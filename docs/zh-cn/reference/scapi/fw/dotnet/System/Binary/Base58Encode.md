# Binary.Base58Encode 方法

将字节数组转换成Base58编码的字符串。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern string Base58Encode(byte[] input);
```

参数：input, 待转换的字节数组。

返回值：Base58编码的字符串。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 Owner = "NXjtqYERuvSWGawjVux8UerNejvwdYg7eE".ToScriptHash();

    public static object Encode()
    {
        return Binary.Base58Encode((byte[])Owner);
    }
}
```

响应正文：

```json
[{
    "type":"ByteString", 
    "value":"2opji9aKc4uyAZLmpYMkNV2jPWt3"
}]
```

响应说明：

- ByteString类型：Base58编码的字符串。

- 其他：失败。

[返回上级](../Binary.md)