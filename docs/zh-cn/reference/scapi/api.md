# 合约框架开发参考

NeoContract 的 API 扩展了智能合约的功能，使其可以访问区块链账本数据、操作持久化存储区、访问执行环境等。它是NEO虚拟机（NeoVM）互操作服务层的一部分。


| 命名空间                          | 说明                                       |
| ----------------------------- | ---------------------------------------- |
| [Neo](neo命名空间) | NEO 命名空间是NEO区块链所提供的 API，提供了访问区块链账本数据的和操作持久化存储区的方法。 |
| [System](system命名空间) | System 命名空间是智能合约执行引擎提供的 API，提供了访问该智能合约的执行环境的方法。 |

## Neo命名空间

### 区块链数据

| API                           | 说明                                |
| ----------------------------- | ----------------------------------- |
| Neo.Blockchain.GetHeight      | 获得当前区块高度                    |
| Neo.Blockchain.GetHeader      | 通过区块高度或区块 Hash，查找区块头 |
| Neo.Blockchain.GetBlock       | 通过区块高度或区块 Hash，查找区块   |
| Neo.Blockchain.GetTransaction | 通过交易 ID 查找交易                |
| Neo.Blockchain.GetAccount     | 根据合约脚本的散列来获得一个账户    |
| Neo.Blockchain.GetValidators  | 获得共识人的公钥                    |
| Neo.Blockchain.GetAsset       | 根据资产 ID 查找资产                |
| Neo.Blockchain.GetContract    | 根据合约散列获取合约内容            |

### 区块

| API                           | 说明                                           |
| ----------------------------- | ---------------------------------------------- |
| Neo.Header.GetHash            | 获得该区块的散列                               |
| Neo.Header.GetVersion         | 获得区块版本号                                 |
| Neo.Header.GetPrevHash        | 获得前一个区块的散列                           |
| Neo.Header.GetIndex           | 获得该区块的高度                               |
| Neo.Header.GetMerkleRoot      | 获得该区块中所有交易的 Merkle Tree 的根        |
| Neo.Header.GetTimestamp       | 获得区块的时间戳                               |
| Neo.Header.GetConsensusData   | 获得该区块的共识数据（共识节点生成的伪随机数） |
| Neo.Header.GetNextConsensus   | 获得下一个记账合约的散列值                     |
| Neo.Block.GetTransactionCount | 获得当前区块中交易的数量                       |
| Neo.Block.GetTransactions     | 获得当前区块中所有的交易                       |
| Neo.Block.GetTransaction      | 获得当前区块中指定的交易                       |

### 交易

| API                           | 说明                                              |
| ----------------------------- | ------------------------------------------------- |
| Neo.Transaction.GetHash       | 获得当前交易的 Hash                               |
| Neo.Transaction.GetType       | 获得当前交易的类型                                |
| Neo.Transaction.GetAttributes | 查询当前交易的所有属性                            |
| Neo.Transaction.GetInputs     | 查询当前交易的所有交易输入                        |
| Neo.Transaction.GetOutputs    | 查询当前交易的所有交易输出                        |
| Neo.Transaction.GetReferences | 查询当前交易的所有输入所引用的交易输出            |
| Neo.Attribute.GetUsage        | 获得该交易特性中的用途                            |
| Neo.Attribute.GetData         | 获得该交易特性中用途之外的额外数据                |
| Neo.Input.GetHash             | 所引用的交易的交易散列                            |
| Neo.Input.GetIndex            | 所引用的交易输出在其全部交易输出列表中的索引      |
| Neo.Output.GetAssetId         | 获得资产 ID                                       |
| Neo.Output.GetValue           | 获得交易金额                                      |
| Neo.Output.GetScriptHash      | 获得脚本散列                                      |
| Neo.Enrollment.GetPublicKey   | ` 已弃用 ` 已用 Neo.Blockchain.GetValidators 替代 |

### 账户

| API                       | 说明                                   |
| ------------------------- | -------------------------------------- |
| Neo.Account.GetScriptHash | 获得该合约账户的脚本散列               |
| Neo.Account.GetVotes      | 获得该合约账户投给其它人的的投票信息   |
| Neo.Account.GetBalance    | 通过资产 ID 获得该账户中这种资产的余额 |

### 资产

| API                    | 说明                                                         |
| ---------------------- | ------------------------------------------------------------ |
| Neo.Asset.GetAssetId   | 获得该资产的 ID                                              |
| Neo.Asset.GetAssetType | 获得该资产的类别                                             |
| Neo.Asset.GetAmount    | 获得该资产的总量                                             |
| Neo.Asset.GetAvailable | 获得该资产的已经发行出去的数量                               |
| Neo.Asset.GetPrecision | 获得该资产的精度（最小分割数量），单位为小数点之后的位数     |
| Neo.Asset.GetOwner     | 获得该资产的所有人（公钥）                                   |
| Neo.Asset.GetAdmin     | 获得该资产的管理员（合约地址），有权对资产的属性（如总量，名称等）进行修改 |
| Neo.Asset.GetIssuer    | 获得该资产的发行人（合约地址），有权进行资产的发行           |

### 合约

| API                    | 说明             |
| ---------------------- | ---------------- |
| Neo.Contract.GetScript | 获得该合约的脚本 |

### 存储

| API                    | 说明                                                |
| ---------------------- | --------------------------------------------------- |
| Neo.Storage.GetContext | 获取当前存储区上下文                                |
| Neo.Storage.Get        | 查询操作，在持久化存储区中通过 key 查询对应的 value |

### 运行


| API                      | 说明                                                    |
| ------------------------ | ------------------------------------------------------- |
| Neo.Runtime.GetTrigger   | 获得该智能合约的触发条件（应用合约 or 鉴权合约）        |
| Neo.Runtime.CheckWitness | 验证调用该智能合约的交易 / 区块是否验证过所需的脚本散列 |
| Neo.Runtime.Notify       | 在智能合约中向执行该智能合约的客户端发送通知            |
| Neo.Runtime.Log          | 在智能合约中向执行该智能合约的客户端发送日志            |

参考：以上 API 的源码位于 NEO 项目中的 [src/neo/SmartContract/StateReader.cs](https://github.com/neo-project/neo/blob/master/neo/SmartContract/StateReader.cs) 文件。

### 状态修改

此类 API 会对智能合约的状态进行修改

| API                            | 说明                                                  |
| ------------------------------ | ----------------------------------------------------- |
| Neo.Account.SetVotes           | 设置该合约账户投给其它人的的投票信息                  |
| Neo.Validator.Register         | `new` 报名成为共识人                                  |
| Neo.Asset.Create               | `new` 注册一种资产                                    |
| Neo.Asset.Renew                | `new` 为资产续费                                      |
| Neo.Contract.Create            | `new` 发布智能合约                                    |
| Neo.Contract.Migrate           | `new` 迁移 / 更新智能合约                             |
| Neo.Contract.Destroy           | `new` 销毁合约                                        |
| Neo.Contract.GetStorageContext | `new` 获得合约的存储上下文                            |
| Neo.Storage.Put                | 插入操作，以 key-value 的形式向持久化存储区中插入数据 |
| Neo.Storage.Delete             | 删除操作，在持久化存储区中通过 key 删除对应的 value   |

参考：以上 API 的源码位于 NEO 项目中的 [src/neo/SmartContract/StateMachine.cs](https://github.com/neo-project/neo/blob/master/neo/SmartContract/StateMachine.cs) 文件。

## System 命名空间

| API                                           | 说明                                                 |
| --------------------------------------------- | ---------------------------------------------------- |
| System.ExecutionEngine.GetScriptContainer     | 获得该智能合约的脚本容器（最开始的触发者）           |
| System.ExecutionEngine.GetExecutingScriptHash | 获得该智能合约执行的脚本散列                         |
| System.ExecutionEngine.GetCallingScriptHash   | 获得该智能合约的调用者的脚本散列                     |
| System.ExecutionEngine.GetEntryScriptHash     | 获得该智能合约的入口点（合约调用链的起点）的脚本散列 |

参考：以上 API 的源码位于 Neo.VM 项目中的 src\Neo.VM\InteropService.cs 文件。