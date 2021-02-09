# Binary.Base58Decode 方法

将Base58编码的字符串解码成等价的字节数组。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern byte[] Base58Decode(string input);
```

参数：input, Base58编码的字符串。

返回值：字节数组。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Decode()
    {
        string str = "2opji9aKc4uyAZLmpYMkNV2jPWt3";
        Binary.Base58Decode(str);  // "81b9b84424acda5ebabd9ade4f7ac5b8d2a0b4d4"
    }
}
```

[返回上级](../Binary.md)