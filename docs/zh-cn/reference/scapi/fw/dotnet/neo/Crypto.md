# Crypto 类

静态类，提供了ECDsa 验证签名的方法。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static class Crypto
```

## 方法

| 名称                                       | 说明              |
| ---------------------------------------- | --------------- |
| ECDsaVerify(byte[] message, byte[] pubkey, byte[] signature) | 根据文本、公钥数组、签名来验证是否是正确的签名 |
| ECDsaCheckMultiSig(byte[] message, byte[][] pubkey, byte[][] signature) | 根据文本、公钥数组、签名数组来验证是否是正确的多方签名 |

## 构造方法

Crypto 类是静态类，无需构造方法。