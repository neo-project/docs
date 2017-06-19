# Blockchain 类

该类提供了访问区块链数据的一系列方法。

命名空间：[AntShares.SmartContract.Framework.Services.AntShares](../AntShares.md)

程序集：AntShares.SmartContract.Framework

## 语法

```c#
public static class Blockchain
```

## 方法

|                                          | 名称                                       | 说明                   |
| ---------------------------------------- | ---------------------------------------- | -------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [CreateAsset(byte, string, long, byte, byte[], byte[], byte[])](Blockchain/CreateAsset.md) | `new` 注册一种资产         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [CreateContract(byte[], byte[], byte, bool, string, string, string, string, string)](Blockchain/CreateContract.md) | `new` 发布智能合约         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAccount(byte[])](Blockchain/GetAccount.md) | 根据合约脚本的散列来获得一个账户（地址） |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAsset(byte[])](Blockchain/GetAsset.md) | 根据资产 ID 查找资产         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBlock(byte[])](Blockchain/GetBlock.md) | 通过区块 hash ，查找区块      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBlock(uint)](Blockchain/GetBlock2.md) | 通过区块高度，查找区块          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetContract(byte[])](Blockchain/GetContract.md) | `new` 通过合约散列获取合约内容   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeader(byte[])](Blockchain/GetHeader.md) | 通过区块 hash ，查找区块头     |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeader(uint)](Blockchain/GetHeader2.md) | 通过区块高度，查找区块头         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeight()](Blockchain/GetHeight.md)   | 获得当前区块高度             |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(byte[])](Blockchain/GetTransaction.md) | 通过交易 ID 查找交易         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetValidators()](Blockchain/GetValidators.md) | `new` 获得共识人的公钥       |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [RegisterValidator(byte[])](Blockchain/RegisterValidator.md) | `new` 报名成为共识人        |

# 构造方法

BlockChain 类是静态类，无需构造方法。