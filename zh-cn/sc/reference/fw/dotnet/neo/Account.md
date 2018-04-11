# Account 类

表示账户的类，提供了查询余额的方法。这里的账户是指一个合约脚本的散列，也就是对应区块链中的一个地址。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Account
```

## 属性

|                                          | 名称                                  | 说明                 |
| ---------------------------------------- | ----------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptHash](Account/ScriptHash.md) | 获得该合约账户的脚本散列       |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Votes](Account/Votes.md)           | 获得该合约账户投给其它人的的投票信息 |

## 方法

|                                          | 名称                                       | 说明                  |
| ---------------------------------------- | ---------------------------------------- | ------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBalance(byte[])](Account/GetBalance.md) | 通过资产 ID 获得该账户中这种资产的余额 |

## 构造方法

通过 [Blockchain.GetAccount(byte[])](Blockchain/GetAccount.md) 来构造 Account 对象。
