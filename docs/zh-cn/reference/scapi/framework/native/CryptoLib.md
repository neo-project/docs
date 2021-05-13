# CryptoLib 类

提供了原生合约CryptoLib的一系列属性与方法，合约哈希为`0x726cb6e0cd8628a1350a611384688911ab75f51b`。

命名空间：[Neo.SmartContract.Framework.Native](../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static class CryptoLib
```

## 属性

| 名称 | 说明         |
| ---- | ------------ |
| Hash | 获取合约哈希 |

## 方法

| 名称                                       | 说明              |
| ---------------------------------------- | --------------- |
| Sha256(ByteString value) | 对字节数组进行SHA256哈希计算 |
| ripemd160(ByteString value) | 对字节数组进行RIPEMD160哈希计算 |
| VerifyWithECDsa(ByteString message, Cryptography.ECC.ECPoint pubkey, ByteString signature, NamedCurve curve) | 使用椭圆曲线验证签名 |