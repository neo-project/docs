# AntShares 命名空间

AntShares 命名空间下的 API 为小蚁智能合约提供了两种确定性的数据源。

1、区块链账本

合约程序可以通过交互服务来访问到整个区块链上的所有数据，包括完整的区块和交易，以及他们的每一个字段。区块上的数据都具有确定性和一致性，所以可以安全地被智能合约访问。

2、持久化存储区

部署在小蚁上的每一个应用合约都有一块仅可由该合约本身来存取的存储空间，小蚁的共识机制确保了每一个节点上的存储状态是一致的。

## 类

|                                          | 类                                        | 说明   |
| ---------------------------------------- | ---------------------------------------- | ---- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Account](AntShares/Accound.md)          |      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Asset](AntShares/Asset.md)              |      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Block](AntShares/Block.md)              |      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Blockchain](AntShares/Blockchain.md)    |      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Enrollment](AntShares/Enrollment.md)    |      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Header](AntShares/Header.md)            |      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Storage](AntShares/Storage.md)          |      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Transaction](AntShares/Transaction.md)  |      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionAttribute](AntShares/TransactionAttribute.md) |      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionInput](AntShares/TransactionInput.md) |      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionOutput](AntShares/TransactionOutput.md) |      |

## 枚举

|                                          | 枚举                                       | 说明   |
| ---------------------------------------- | ---------------------------------------- | ---- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [StorageContex](AntShares/StorageContex.md) |      |