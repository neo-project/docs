# Account 类

表示账户的类，提供了判断是否是标准账户的方法。这里的账户是指一个合约脚本的散列，也就是对应区块链中的一个地址。

常见的账户类型有：

- 标准账户：单方签名账户，也就是创建钱包时或在钱包中新建地址时生成的账户。

- 多方签名账户：在 Neo-gui 或 Neo-cli 中创建的多方签名地址，由一组公钥和最少签名数组成。如 2 of 3 多方签名账户表示该账户由 3 个人管理，有 2 人同时签名时即可授权转账。


命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Account
```

## 方法

| 名称                                       | 说明                  |
| ---------------------------------------- | ------------------- |
| [IsStandard(byte[] scripthash)](Account/IsStandard.md) | 根据 scripthash 判断该合约是否是标准账户（单方签名账户） |

