# Base64Decode 方法 (string)

将Base64编码的字符串解码成等价的字节数组。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern byte[] Base64Decode(string input);
```

参数：input, Base64编码的字符串。

返回值：字节数组。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Decode()
    {
        string str = "HN37B9huZAKgFSjkHDNXEAvbX08="; // "1cddfb07d86e6402a01528e41c3357100bdb5f4f" 
        Binary.Base64Decode(str);
    }
}
```

[返回上级](../Binary.md)