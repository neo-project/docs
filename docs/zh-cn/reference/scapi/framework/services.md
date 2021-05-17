# Neo.SmartContract.Framework.Services

## 类

| 类                                                           | 说明                                          |
| ------------------------------------------------------------ | --------------------------------------------- |
| [Block](services/Block.md)       | 表示区块的类，提供了一系列区块相关的属性      |
| [Contract](services/Contract.md) | 表示合约的类                                  |
| [Crypto](services/Crypto.md)     | 提供了ECDsa 验证签名的方法。                  |
| [Iterator](services/Iterator.md) | 智能合约中的自定义迭代器                      |
| [Notification](services/Notification.md) | 表示合约执行发送的通知                        |
| [Runtime](services/Runtime.md)   | 提供智能合约运行时的一些方法                  |
| [Storage](services/Storage.md)   | 提供了持久化存储区的插入、查询、删除的方法    |
| [StorageContext](services/StorageContext.md) | 用来表示私有存储区存储上下文的类              |
| [StorageMap](services/StorageMap.md) | 表示给定存储上下文中指定前缀的key-value存储区 |
| [Transaction](services/Transaction.md) | 用来表示交易的基类                            |

## 枚举

| 枚举                                   | 说明                                                 |
| -------------------------------------- | ---------------------------------------------------- |
| [CallFlags](services/CallFlags.md)     | 定义调用合约方法时的模式                             |
| [FindOptions](services/FindOptions.md) | 定义搜索存储区时的搜索选项，用在 Storage.Find 方法中 |
| [TriggerType](services/TriggerType.md) | 定义了智能合约触发器类型                             |

