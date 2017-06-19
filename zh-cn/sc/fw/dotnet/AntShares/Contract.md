# Contract 类

表示合约的类。

命名空间：[AntShares.SmartContract.Framework.Services.AntShares](../AntShares.md)

程序集：AntShares.SmartContract.Framework

## 语法

```c#
public class Contract
```

## 属性

|                                          | 名称                           | 说明         |
| ---------------------------------------- | ---------------------------- | ---------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Script](Contract/Script.md) | 获得该合约的脚本散列 |

## 方法

|                                          | 名称                               | 说明     |
| ---------------------------------------- | -------------------------------- | ------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Destroy()](Contract/Destroy.md) | 销毁智能合约 |

## 构造方法

通过 [Blockchain.GetContract(byte[])](Blockchain/GetContract.md) 方法来构造 Contract 对象。

通过 [Blockchain.CreateContract(byte[], byte[], byte, bool, string, string, string, string, string)](Blockchain/CreateContract.md) 方法来发布智能合约到区块链上，并返回 Contract 对象。