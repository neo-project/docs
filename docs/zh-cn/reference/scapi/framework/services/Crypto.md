# Crypto 类

静态类，提供了ECDsa 验证签名的方法。

命名空间：[Neo.SmartContract.Framework.Services](../services.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static class Crypto
```

## 方法

| 名称                                                    | 说明                       |
| ------------------------------------------------------- | -------------------------- |
| CheckSig(Cryptography.ECC.ECPoint, ByteString)          | 检查当前脚本容器的签名     |
| CheckMultisig(Cryptography.ECC.ECPoint[], ByteString[]) | 检查当前脚本容器的多方签名 |


## 构造方法

Crypto 类是静态类，无需构造方法。