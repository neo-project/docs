# NEO 命名空间

NEO 命名空间是 NEO 区块链所提供的 API，提供了访问区块链账本数据的和操作持久化存储区的方法。这些 API 分为两类。

1、区块链账本。合约程序可以通过交互服务来访问到整个区块链上的所有数据，包括完整的区块和交易，以及他们的每一个字段。

2、持久化存储区。部署在 NEO 上的每一个应用合约都有一块仅可由该合约本身来存取的存储空间，可以用来存取合约中的数据。

注：本文中标记 `new` 和 ` 已弃用 ` 的地方是 2.0 版本相对 1.6 版本的更改之处。

## 类

|                                          | 类                                        | 说明                       |
| ---------------------------------------- | ---------------------------------------- | ------------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Account](neo/Account.md)                | 表示账户的类，提供了查询余额的方法        |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Asset](neo/Asset.md)                    | 用来表示资产的数据结构              |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Block](neo/Block.md)                    | 表示区块的类，提供了查询区块中交易的方法     |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Blockchain](neo/Blockchain.md)          | 该类提供了访问区块链数据的一系列方法       |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Contract](neo/Contract.md)              | 表示合约的类                   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Enrollment](neo/Enrollment.md)          | ` 已弃用 ` 用来表示记账人报名交易的数据结构 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Header](neo/Header.md)                  | 用来表示区块头的数据结构             |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Runtime](neo/Runtime.md)                | `new` 提供智能合约运行时的一些方法     |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Storage](neo/Storage.md)                | 提供了持久化存储区的插入、查询、删除的方法    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [StorageContext](neo/StorageContext.md)    | `new` 用来表示私有存储区存储上下文的类   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Transaction](neo/Transaction.md)        | 用来表示交易的基类                |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionAttribute](neo/TransactionAttribute.md) | 用来表示交易特性的数据结构            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionInput](neo/TransactionInput.md) | 用来表示交易输入的数据结构            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionOutput](neo/TransactionOutput.md) | 用来表示交易输出的数据结构            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Validator](neo/Validator.md)            | `new` 提供共识节点的一些方法        |

## 枚举

|                                          | 枚举                                     | 说明                        |
| ---------------------------------------- | -------------------------------------- | ------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [TriggerType](TriggerType.md)          | `new` 用来表示智能合约触发条件的枚举     |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [StorageContext](neo/StorageContext2.md) | ` 已弃用 ` 用来表示私有存储区存储上下文的枚举 |

