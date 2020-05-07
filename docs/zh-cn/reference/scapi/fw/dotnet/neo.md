# Neo 命名空间

Neo 命名空间是 Neo 区块链所提供的 API，提供了访问区块链账本数据的和操作持久化存储区的方法。这些 API 分为两类。

- 区块链账本。合约程序可以通过交互服务来访问整个区块链上的所有数据，包括完整的区块和交易，以及他们的每一个字段。

- 持久化存储区。部署在 Neo 上的每一个应用合约都有一块仅可由该合约本身来存取的存储空间，可以用来存取合约中的数据。

## 类

| 类                                                    | 说明                                       |
| ----------------------------------------------------- | ------------------------------------------ |
| [Account](neo/Account.md)                             | 表示账户的类，提供了查询余额的方法         |
| [Asset](neo/Asset.md)                                 | 用来表示资产的数据结构                     |
| [Block](neo/Block.md)                                 | 表示区块的类，提供了查询区块中交易的方法   |
| [Blockchain](neo/Blockchain.md)                       | 该类提供了访问区块链数据的一系列方法       |
| [Contract](neo/Contract.md)                           | 表示合约的类                               |
| [Header](neo/Header.md)                               | 用来表示区块头的数据结构                   |
| [InvocationTransaction](neo/InvocationTransaction.md) | 用来表示调用合约交易的类                   |
| [Iterator](neo/Iterator.md)                           | 用来表示枚举器的类                         |
| [Runtime](neo/Runtime.md)                             | 提供智能合约运行时的一些方法               |
| [Storage](neo/Storage.md)                             | 提供了持久化存储区的插入、查询、删除的方法 |
| [StorageContext](neo/StorageContext.md)               | 用来表示私有存储区存储上下文的类           |
| [StorageMap](neo/StorageMap.md)                       | 用来表示 Map 数据结构的类                  |
| [Transaction](neo/Transaction.md)                     | 用来表示交易的基类                         |
| [TransactionAttribute](neo/TransactionAttribute.md)   | 用来表示交易特性的数据结构                 |
| [TransactionInput](neo/TransactionInput.md)           | 用来表示交易输入的数据结构                 |
| [TransactionOutput](neo/TransactionOutput.md)         | 用来表示交易输出的数据结构                 |

## 枚举

| 枚举                                                  | 说明                           |
| ----------------------------------------------------- | ------------------------------ |
| [ContractPropertyState](neo/ContractPropertyState.md) | 用来表示智能合约属性状态的枚举 |
| [TriggerType](neo/TriggerType.md)                     | 用来表示智能合约触发条件的枚举 |

