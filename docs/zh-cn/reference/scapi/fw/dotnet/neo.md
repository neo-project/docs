# NEO 命名空间

NEO 命名空间是 NEO 区块链所提供的 API，提供了访问区块链账本数据的和操作持久化存储区的方法。这些 API 分为两类：

- 区块链账本。合约程序可以通过交互服务来访问到整个区块链上的所有数据，包括完整的区块和交易，以及他们的每一个字段。

- 持久化存储区。部署在 NEO 上的每一个应用合约都有一块仅可由该合约本身来存取的存储空间，可以用来存取合约中的数据。


## 类

| 类                                        | 说明                       |
| ---------------------------------------- | ------------------------ |
| [Account](neo/Account.md)                | 表示账户的类，提供了判断是否是标准账户的方法        |
| [Block](neo/Block.md)                    | 表示区块的类，提供了一系列区块相关的属性     |
| [Blockchain](neo/Blockchain.md)          | 该类提供了访问区块链数据的一系列方法       |
| [Contract](neo/Contract.md)              | 表示合约的类                   |
| [Crypto](neo/Crypto.md)              | 提供了ECDsa 验证签名的方法。                   |
| [Enumerator](neo/Enumerator.md)              | 智能合约中的自定义枚举器                   |
| [Helper](neo/Helper.md)              | 合约存储区的辅助方法                   |
| [Iterator](neo/Iterator.md)              | 智能合约中的自定义迭代器                   |
| [Json](neo/Json.md)              | 一种数据表示结构                   |
| [Native](neo/Native.md)              | 表示Neo区块链中的原生合约类                   |
| [Notification](neo/Notification.md)              | 表示合约执行发送的通知                   |
| [Runtime](neo/Runtime.md)                | 提供智能合约运行时的一些方法     |
| [Storage](neo/Storage.md)                | 提供了持久化存储区的插入、查询、删除的方法    |
| [StorageContext](neo/StorageContext.md)  | 用来表示私有存储区存储上下文的类   |
| [StorageFlags](neo/StorageFlags.md)  | 表明了写入数据的属性   |
| [StorageMap](neo/StorageMap.md)  | 表示给定存储上下文中指定前缀的key-value存储区   |
| [Transaction](neo/Transaction.md)        | 用来表示交易的基类                |

## 枚举

| 枚举                                       | 说明                        |
| ---------------------------------------- | ------------------------- |
| [CallFlags](neo/CallFlags.md) | 定义调用合约方法时的模式|
| [TriggerType](neo/TriggerType.md) | 定义了触发器类型 |

