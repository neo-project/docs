# Binary 类

编码以及数值转换操作。

命名空间：[Neo.SmartContract.Framework.Services.System](../System.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static class Binary
```

## 方法

| 名称                                                         | 说明                                                 |
| ------------------------------------------------------------ | ---------------------------------------------------- |
| [Base64Decode(string)](Binary/Base64Decode.md)    | 将Base64编码的字符串解码成字节数组                     |
| [Base64Encode(byte\[\])](Binary/Base64Encode.md)        | 将字节数组编码成Base64编码的字符串 |
| [Base58Decode(string)](Binary/Base58Decode.md) | 将Base58编码的字符串解码成字节数组                         |
| [Base58Encode(byte\[\])](Binary/Base58Encode.md)        | 将字节数组编码成Base58编码的字符串           |
| [Itoa(BigInteger, int )](Binary/Itoa.md)    | 将BigInteger类型的数值转换为字符串表示                     |
| [Itoa(int, int @base = 10)](Binary/Itoa.md)    | 将有符号的32位整数转换为字符串表示                     |
| [Itoa(uint, int @base = 10)](Binary/Itoa.md)    | 将无符号的32位整数转换为字符串表示                     |
| [Itoa(long, int @base = 10)](Binary/Itoa.md)    | 将有符号的64位整数转换为字符串表示                     |
| [Itoa(ulong, int @base = 10)](Binary/Itoa.md)    | 将无符号的64位整数转换为字符串表示                     |
| [Itoa(short, int @base = 10)](Binary/Itoa.md)    | 将有符号的16位整数转换为字符串表示                     |
| [Itoa(ushort, int @base = 10)](Binary/Itoa.md)    | 将无符号的16位整数转换为字符串表示                     |
| [Itoa(byte, int @base = 10)](Binary/Itoa.md)    | 将无符号的8位整数转换为字符串表示              |
| [Itoa(sbyte, int @base = 10)](Binary/Itoa.md)    | 将有符号的8位整数转换为字符串表示           |
| [Atoi(string, int @base = 10)](Binary/Atoi.md)    | 将字符串表示的数值转换为BigInteger类型                  |
