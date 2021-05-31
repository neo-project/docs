# StdLib 类

提供了原生合约StdLib的一系列属性与方法，合约哈希为`0xacce6fd80d44e1796aa0c2c625e9e4e0ce39efc0`。

命名空间：[Neo.SmartContract.Framework.Native](../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static class StdLib
```

## 属性

| 名称 | 说明         |
| ---- | ------------ |
| Hash | 获取合约哈希 |

## 方法

| 名称                                       | 说明              |
| ---------------------------------------- | --------------- |
| Serialize(object source) | 将对象序列化为字节数组 |
| Deserialize(ByteString source) | 将字节数组反序列化为对象 |
| JsonSerialize(object obj) | 将对象序列化为Json |
| JsonDeserialize(string json) | 将Json反序列化为对象 |
| Base64Decode(string input) | 将Base64编码的字符串解码为字节数组 |
| Base64Encode(ByteString input) | 将字节数组编码为Base64字符串 |
| Base58Decode(string input) | 将Base58编码的字符串解码为字节数组 |
| Base58Encode(ByteString input) | 将字节数组编码为Base58字符串 |
| Base58CheckDecode(string input) | 将Base58Check编码的字符串解码为字节数组 |
| Base58CheckEncode(ByteString input) | 将字节数组编码为Base58Check字符串 |
| Itoa | 把整数转换为字符串 |
| Atoi(string value, int @base = 10) | 把字符串转换成整型数 |
| MemoryCompare(ByteString, ByteString) | 如果两个数组相同，返回0；如果数组1小于数组2，返回小于0的值；如果数组1大于数组2，返回大于0的值 |
| MemorySearch | 返回数组2在数组1中第一次匹配的索引，如果匹配不到则返回 -1 |
| StringSplit | 通过基于一个或多个分隔符拆分输入字符串来创建子字符串数组 |