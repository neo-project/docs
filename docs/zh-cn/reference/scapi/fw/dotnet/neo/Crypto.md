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
| SHA256(byte[] value) | 对字节数组进行SHA256哈希计算 |
| RIPEMD160(byte[] value) | 对字节数组进行RIPEMD160哈希计算 |
| Hash160(byte[] value) | 对字节数组进行一次SHA256,一次RIPEMD160哈希计算 |
| Hash256(byte[] value) | 对字节数组进行二次SHA256哈希计算 |
| Secp256r1.Verify(byte[] message, byte[] pubkey, byte[] signature) | 根据公钥数组、签名来验证是否是正确的签名(r1曲线) |
| Secp256r1.CheckMultiSig(byte[] message, byte[][] pubkey, byte[][] signature) | 根据公钥数组、签名来验证是否是正确的签名(r1曲线) |
| Secp256k1.Verify(byte[] message, byte[] pubkey, byte[] signature) | 根据公钥数组、签名来验证是否是正确的签名(k1曲线) |
| Secp256k1.CheckMultiSig(byte[] message, byte[][] pubkey, byte[][] signature) | 根据公钥数组、签名来验证是否是正确的签名(k1曲线) |

## 构造方法

Crypto 类是静态类，无需构造方法。