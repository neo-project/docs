# Base64Encode 方法 (byte[])

将字节数组转换成Base64编码的字符串。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern string Base64Encode(byte[] input);
```

参数：input, 待转换的字节数组。

返回值：Base64编码的字符串。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static byte[] ScriptHash = "0x4f5fdb0b1057331ce42815a002646ed807fbdd1c".HexToBytes(reverse: true);

    public static object Encode()
    {
        return Binary.Base64Encode(ScriptHash);
    }
}
```

响应正文：

```json
[{
    "type":"ByteString", 
    "value":"SE4zN0I5aHVaQUtnRlNqa0hETlhFQXZiWDA4PQ=="
}]
```

响应说明：

- ByteString类型：Base64编码的字符串。

- 其他：失败。

[返回上级](../Binary.md)