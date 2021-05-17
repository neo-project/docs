# NamedCurve 枚举

支持的椭圆曲线扩展。

命名空间：[Neo.SmartContract.Framework.Native](../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public enum NamedCurve : byte
{
    secp256k1 = 22,
    secp256r1 = 23
}
```

## 说明

用在 [CryptoLib.VerifyWithECDsa](../native/CryptoLib.md) 方法中。

参考 [RFC 4492](https://tools.ietf.org/html/rfc4492#section-5.1.1)。

