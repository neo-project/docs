# Blockchain.RegisterValidator 方法 (byte[])

报名成为共识人，仅是报名操作，能否当选需要其它人的投票。

该方法是 RegisterTransaction 在 2.0 版本的替代者。

命名空间：[AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

程序集：AntShares.SmartContract.Framework

## 语法

```c#
public static extern byte[] RegisterValidator(byte[] pubkey)
```

参数：

pubkey：公钥，长度为33的字节数组。

返回值：传入的公钥。

## 示例

```

```



[返回上级](../Blockchain.md)