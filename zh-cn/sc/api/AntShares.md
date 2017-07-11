# AntShares 命名空间

AntShares 命名空间是小蚁区块链所提供的 API，提供了访问区块链账本数据的和操作持久化存储区的方法。

注：本文中标记 `new` 和 `已弃用` 的地方是 2.0 版本相对 1.6 版本的更改之处。

从区块链查询数据的 API：

| API                                 | 说明                   |
| ----------------------------------- | -------------------- |
| AntShares.Blockchain.GetHeight      | 获得当前区块高度             |
| AntShares.Blockchain.GetHeader      | 通过区块高度或区块 Hash，查找区块头 |
| AntShares.Blockchain.GetBlock       | 通过区块高度或区块 Hash，查找区块  |
| AntShares.Blockchain.GetTransaction | 通过交易 ID 查找交易         |
| AntShares.Blockchain.GetAccount     | 根据合约脚本的散列来获得一个账户     |
| AntShares.Blockchain.GetValidators  | `new` 获得共识人的公钥       |
| AntShares.Blockchain.GetAsset       | 根据资产 ID 查找资产         |
| AntShares.Blockchain.GetContract    | `new` 根据合约散列获取合约内容   |

区块类 API：

| API                                 | 说明                         |
| ----------------------------------- | -------------------------- |
| AntShares.Header.GetHash            | 获得该区块的散列                   |
| AntShares.Header.GetVersion         | 获得区块版本号                    |
| AntShares.Header.GetPrevHash        | 获得前一个区块的散列                 |
| AntShares.Header.GetMerkleRoot      | 获得该区块中所有交易的 Merkle Tree 的根 |
| AntShares.Header.GetTimestamp       | 获得区块的时间戳                   |
| AntShares.Header.GetConsensusData   | 获得该区块的共识数据（共识节点生成的伪随机数）    |
| AntShares.Header.GetNextConsensus   | 获得下一个记账合约的散列值              |
| AntShares.Block.GetTransactionCount | 获得当前区块中交易的数量               |
| AntShares.Block.GetTransactions     | 获得当前区块中所有的交易               |
| AntShares.Block.GetTransaction      | 获得当前区块中指定的交易               |

交易类 API：

| API                                 | 说明                                       |
| ----------------------------------- | ---------------------------------------- |
| AntShares.Transaction.GetHash       | 获得当前交易的 Hash                             |
| AntShares.Transaction.GetType       | 获得当前交易的类型                                |
| AntShares.Enrollment.GetPublicKey   | `已弃用` 已用 AntShares.Blockchain.GetValidators 替代 |
| AntShares.Transaction.GetAttributes | 查询当前交易的所有属性                              |
| AntShares.Transaction.GetInputs     | 查询当前交易的所有交易输入                            |
| AntShares.Transaction.GetOutputs    | 查询当前交易的所有交易输出                            |
| AntShares.Transaction.GetReferences | 查询当前交易的所有输入所引用的交易输出                      |
| AntShares.Attribute.GetUsage        | 获得该交易特性中的用途                              |
| AntShares.Attribute.GetData         | 获得该交易特性中用途之外的额外数据                        |
| AntShares.Input.GetHash             | 所引用的交易的交易散列                              |
| AntShares.Input.GetIndex            | 所引用的交易输出在其全部交易输出列表中的索引                   |
| AntShares.Output.GetAssetId         | 获得资产 ID                                  |
| AntShares.Output.GetValue           | 获得脚本散列                                   |
| AntShares.Output.GetScriptHash      | 获得交易金额                                   |

账户类 API：

| API                             | 说明                  |
| ------------------------------- | ------------------- |
| AntShares.Account.GetScriptHash | 获得该合约账户的脚本散列        |
| AntShares.Account.GetVotes      | 获得该合约账户投给其它人的的投票信息  |
| AntShares.Account.GetBalance    | 通过资产ID获得该账户中这种资产的余额 |

资产类 API：

| API                          | 说明                                    |
| ---------------------------- | ------------------------------------- |
| AntShares.Asset.GetAssetId   | 获得该资产的ID                              |
| AntShares.Asset.GetAssetType | 获得该资产的类别                              |
| AntShares.Asset.GetAmount    | 获得该资产的总量                              |
| AntShares.Asset.GetAvailable | 获得该资产的已经发行出去的数量                       |
| AntShares.Asset.GetPrecision | 获得该资产的精度（最小分割数量），单位为小数点之后的位数          |
| AntShares.Asset.GetOwner     | 获得该资产的所有人（公钥）                         |
| AntShares.Asset.GetAdmin     | 获得该资产的管理员（合约地址），有权对资产的属性（如总量，名称等）进行修改 |
| AntShares.Asset.GetIssuer    | 获得该资产的发行人（合约地址），有权进行资产的发行             |

合约类 API：

| API                          | 说明       |
| ---------------------------- | -------- |
| AntShares.Contract.GetScript | 获得该合约的脚本 |

存储类 API：

| API                          | 说明                              |
| ---------------------------- | ------------------------------- |
| AntShares.Storage.GetContext | `new` 获取当前存储区上下文                |
| AntShares.Storage.Get        | 查询操作，在持久化存储区中通过 key 查询对应的 value |

运行时相关的 API：


| API                            | 说明                                |
| ------------------------------ | --------------------------------- |
| AntShares.Runtime.CheckWitness | `new` 验证调用该智能合约的交易/区块是否验证过所需的脚本散列 |
| AntShares.Runtime.Notify       | `new` 在智能合约中向执行该智能合约的客户端发送通知      |
| AntShares.Runtime.Log          | `new` 在智能合约中向执行该智能合约的客户端发送日志      |


参考：源码位于 AntShares 项目中的 src/AntShares/SmartContract/StateReader.cs 文件。

此类 API 会对智能合约的状态进行修改

| API                                  | 说明                               |
| ------------------------------------ | -------------------------------- |
| AntShares.Account.SetVotes           | 设置该合约账户投给其它人的的投票信息               |
| AntShares.Validator.Register         | `new` 报名成为共识人                    |
| AntShares.Asset.Create               | `new` 注册一种资产                     |
| AntShares.Asset.Renew                | `new` 为资产续费                      |
| AntShares.Contract.Create            | `new` 发布智能合约                     |
| AntShares.Contract.Migrate           | `new` 迁移/更新智能合约                  |
| AntShares.Contract.Destroy           | `new` 销毁合约                       |
| AntShares.Contract.GetStorageContext | `new` 获得合约的存储上下文                 |
| AntShares.Storage.Put                | 插入操作，以 key-value 的形式向持久化存储区中插入数据 |
| AntShares.Storage.Delete             | 删除操作，在持久化存储区中通过 key 删除对应的 value  |

参考：源码位于 AntShares 项目中的 src/AntShares/SmartContract/StateMachine.cs 文件。
