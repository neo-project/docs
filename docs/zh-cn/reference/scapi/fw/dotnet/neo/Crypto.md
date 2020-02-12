# Crypto 类

静态类，提供了一些 ECDsa 验证签名的方法。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static class Crypto
```

## 方法

|                                          | 名称                                       | 说明              |
| ---------------------------------------- | ---------------------------------------- | --------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | ECDsaVerify(byte[], byte[], byte[]) | 根据文本、公钥、签名来验证是否是正确的签名 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | ECDsaCheckMultiSig(byte[], byte[][], byte[][]) | 根据文本、公钥数组、签名数组还验证是否是正确的多方签名 |
