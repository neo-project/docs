# Neo 命名空间

Neo 命名空间是 Neo 区块链所提供的 API，提供了访问区块链账本数据的和操作持久化存储区的方法。这些 API 分为：

- 区块链账本。合约程序可以通过交互服务来访问到整个区块链上的所有数据，包括完整的区块和交易，以及他们的每一个字段。
- 原生合约。在智能合约中可以调用原生合约中的一系列方法。
- 持久化存储区。部署在 NEO 上的每一个应用合约都有一块仅可由该合约本身来存取的存储空间，可以用来存取合约中的数据。


## 类

| 类                                        | 说明                       |
| ---------------------------------------- | ------------------------ |
| [Account](neo/Account.md)                | 表示账户的类，提供了判断是否是标准账户的方法        |
| [Block](neo/Block.md)                    | 表示区块的类，提供了一系列区块相关的属性     |
| [Contract](neo/Contract.md)              | 表示合约的类                   |
| [Crypto](neo/Crypto.md)              | 提供了ECDsa 验证签名的方法。                   |
| [Helper](neo/Helper.md)              | 合约存储区的辅助方法                   |
| [Iterator](neo/Iterator.md)              | 智能合约中的自定义迭代器                   |
| [Json](neo/Json.md)              | 一种数据表示结构                   |
| [Notification](neo/Notification.md)              | 表示合约执行发送的通知                   |
| [Runtime](neo/Runtime.md)                | 提供智能合约运行时的一些方法     |
| [Storage](neo/Storage.md)                | 提供了持久化存储区的插入、查询、删除的方法    |
| [StorageContext](neo/StorageContext.md)  | 用来表示私有存储区存储上下文的类   |
| [StorageMap](neo/StorageMap.md)  | 表示给定存储上下文中指定前缀的key-value存储区   |
| [Transaction](neo/Transaction.md)        | 用来表示交易的基类                |

## 原生合约类

| 合约名称                                        | 合约哈希                                   | 说明                                         |
| ----------------------------------------------- | ------------------------------------------ | -------------------------------------------- |
| [ContractManagement](neo/ContractManagement.md) | 0xfffdc93764dbaddd97c48f252a53ea4643faa3fd | 管理合约的合约                               |
| [CryptoLib](neo/CryptoLib.md)                   | 0x726cb6e0cd8628a1350a611384688911ab75f51b | 集成了散列运算、验签等密码学方法的合约       |
| [GasToken](neo/GAS.md)                          | 0xd2a4cff31913016155e38e474a2c06d08be276cf | GAS相关合约                                  |
| [LedgerContract](neo/Ledger.md)                 | 0xda65b600f7124ce6c79950c1772a36403104f2be | 区块链协议层合约                             |
| [NameService](neo/NameService.md)               | 0x7a8fcf0392cd625647907afa8e45cc66872b596b | Neo域名服务合约                              |
| [NeoToken](neo/NEO.md)                          | 0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5 | NEO相关合约                                  |
| [OracleContract](neo/Oracle.md)                 | 0xfe924b7cfe89ddd271abaf7210a80a7e11178758 | 预言机合约                                   |
| [PolicyContract](neo/Policy.md)                 | 0xcc5e4edd9f5f8dba8bb65734541df7a1c081c67b | 共识策略合约                                 |
| [RoleManagement](neo/RoleManagement.md)         | 0x49cf4e5378ffcd4dec034fd98a174c5491e395e2 | 权限查询合约                                 |
| [StdLib](neo/StdLib.md)                         | 0xacce6fd80d44e1796aa0c2c625e9e4e0ce39efc0 | 集成了序列化、反序列化和格式转换等方法的合约 |

## 枚举

| 枚举                                       | 说明                        |
| ---------------------------------------- | ------------------------- |
| [CallFlags](neo/CallFlags.md) | 定义调用合约方法时的模式|
| [FindOptions](neo/FindOptions.md) | 定义搜索存储区时的搜索选项，用在 Storage.Find 方法中 |
| [OracleResponseCode](neo/OracleResponseCode.md) | 定义了 Oracle 响应代码的类型 |
| [RecordType](neo/RecordType.md) | 定义了 NameServices 的 DNS 记录的类型 |
| [Role](neo/Role.md) | 定义了 RoleManagement 原生合约中的权限类型 |
| [StorageFlags](neo/StorageFlags.md)  | 表明了写入存储区数据的属性 |
| [TriggerType](neo/TriggerType.md) | 定义了智能合约触发器类型 |

