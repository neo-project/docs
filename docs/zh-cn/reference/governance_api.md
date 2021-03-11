# Neo3 治理API

## 经济模型

Neo3继承Neo2继续使用NEO和GAS双通证机制，其中NEO用于治理，GAS用于流通。

### NEO

NEO总额1亿，最小单位为1，即不可分割。NEO持有者是Neo网络的所有者和管理者。通过在Neo网络上构造投票交易来行使管理权，如选举共识节点，共识策略调整，计价模型调整等，并根据NEO的持有量，可提取相应份额的GAS。

### GAS

GAS最小单位为10<sup>-8</sup>。GAS代表着Neo网络的使用权，可通过持有NEO提取或者购买获取。在使用Neo网络时，需要支付一定数量的GAS作为费用，如用户转账，注册资产，发布资产，DApp应用等。

| 原生合约   | 合约hash                                   |
| ---------- | ------------------------------------------ |
| `ContractManagement` | 0xfffdc93764dbaddd97c48f252a53ea4643faa3fd |
| `StdLib` | 0xacce6fd80d44e1796aa0c2c625e9e4e0ce39efc0 |
| `CryptoLib` | 0x726cb6e0cd8628a1350a611384688911ab75f51b |
| `LedgerContract` | 0xda65b600f7124ce6c79950c1772a36403104f2be |
| `NeoToken` | 0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5 |
| `GasToken` | 0xd2a4cff31913016155e38e474a2c06d08be276cf |
| `PolicyContract` | 0xcc5e4edd9f5f8dba8bb65734541df7a1c081c67b |
| `RoleManagement` | 0x49cf4e5378ffcd4dec034fd98a174c5491e395e2 |
| `OracleContract` | 0xfe924b7cfe89ddd271abaf7210a80a7e11178758 |
| `NameService` | 0x7a8fcf0392cd625647907afa8e45cc66872b596b |

原生合约调用方法，与普通合约调用方法一样：`Contract.Call(NEO.hash, method, callFlags, params)`

## 治理机制

### 候选人（Candidate）

#### 职能

候选人本身并无职能。根据候选人得票数量排序，排在最前面的一定数量的候选人将被选为委员会成员和共识节点。三者之间逻辑关系如下图所示。委员会和共识节点没有明确的大小关系，但默认的委员会数目（21）大于共识节点数（7）。

![avatar](./assets/candidateRelationship.png)

#### 产生方式

通过注册可以成为候选人，也可以通过注销解除候选人资格。相应的合约方法如下：

| 方法 | 参数 | 费用（GAS） |
| ---- | ------------------------------------ | ---- |
| [`RegisterCandidate`](scapi/fw/dotnet/neo/Neo/RegisterCandidate.md) | UInt160 publicKey | 可调，初始0.00001 |
| [`UnregisterCandidate`](scapi/fw/dotnet/neo/Neo/UnregisterCandidate.md) | UInt160 publicKey | 0.00065536 (CpuFee) |

> [!Note]
>
> 注册/注销候选人均需要验证候选人地址的签名，即只有候选人自己才能执行注册/注销操作。

#### 候选人投票

每个地址均有投票给一个地址的权利，候选人票数为所有向该账户投票的地址的NEO余额之和。初始块所有默认候选人均会向自己投票。

投票相关合约方法如下，这里注意，投票需要验证投票者的签名。

| 方法 | 参数 | 费用（GAS） |
| ---- | ------------------------------------ | ---- |
| [`Vote`](scapi/fw/dotnet/neo/Neo/Vote.md) | UInt160 account, byte[] voteTo | 0.00065536 (CpuFee) |

由于账户NEO余额会随交易而不断变化，而且投票和注册的候选人也在不断变化，因此在每个区块都会根据以上变化更新候选人及相应投票结果。

| 方法 | 参数 | 费用（GAS） |
| ---- | ------------------------------------ | ---- |
| [`GetCandidates`](scapi/fw/dotnet/neo/Neo/GetCandidates.md) | null | 0.04194304 (CpuFee) |

### 委员会（Committee）

#### 职能

委员会可以通过投票的方式对Neo网络的一些参数进行修改，目前包括以下内容：

* 分配职能
* 设置交易每字节网络费
* 设置计算费用 (CpuFee) 的倍率
* 设置存储费用的倍率
* 地址屏蔽/解除屏蔽
* 设置Oracle服务费用
* 设置每个区块释放的GAS数量
* 设置注册候选人的费用
* 增加NNS的Root
* 设置NNS的注册/修改费用
* 设置部署合约的最细费用

其对应的合约方法及相关费用如下所示：

| 方法 | 参数 | 费用（GAS） | 合约 |
| ---- | ------------------------------------ | ---- | ---- |
| DesignateAsRole | Role role, ECPoint[] nodes | 0.00032768 (CpuFee) | RoleManagement |
| SetFeePerByte | long value | 0.00032768 (CpuFee) | PolicyContract |
| SetExecFeeFactor | uint value | 0.00032768 (CpuFee) | PolicyContract |
| SetStoragePrice | uint value | 0.00032768 (CpuFee) | PolicyContract |
| [`BlockAccount`](scapi/fw/dotnet/neo/Policy/BlockAccount.md) | UInt160 account | 0.00032768 (CpuFee) | PolicyContract |
| [`UnblockAccount`](scapi/fw/dotnet/neo/Policy/UnblockAccount.md) | UInt160 account | 0.00032768 (CpuFee) | PolicyContract |
| SetPrice | long price | 0.00032768 (CpuFee) | OracleContract |
| SetGasPerBlock | BigInteger gasPerBlock | 0.00032768 (CpuFee) | NeoToken |
| SetRegisterPrice | long registerPrice | 0.00032768 (CpuFee) | NeoToken |
| AddRoot | string root | 0.00032768 (CpuFee) | NameService |
| SetPrice | long price | 0.00032768 (CpuFee) | NameService |
| SetMinimumDeploymentFee | BigInteger value | 0.00032768 (CpuFee) | ContractManagement |

委员会可以通过发送包含多签的，调用相应合约方法的交易上链使投票生效。投票数超过委员会数量的一半的向上取整即为有效投票，相应操作将被执行生效。

另外也支持以下数据的读方法：

| 方法 | 参数 | 费用（GAS） | 合约 |
| ---- | ------------------------------------ | ---- | ---- |
| [`GetDesignatedByRole`](scapi/fw/dotnet/neo/RoleManagement/GetDesignatedByRole.md) | Role role, uint index | 0.00032768 (CpuFee) | RoleManagement |
| [`GetFeePerByte`](scapi/fw/dotnet/neo/Policy/GetFeePerByte.md) | null | 0.00032768 (CpuFee) | PolicyContract |
| GetExecFeeFactor | null | 0.00032768 (CpuFee) | PolicyContract |
| GetStoragePrice | null | 0.00032768 (CpuFee) | PolicyContract |
| [`IsBlocked`](scapi/fw/dotnet/neo/Policy/IsBlocked.md) | UInt160 account | 0.00032768 (CpuFee) | PolicyContract |
| GetPrice | null | 0.00032768 (CpuFee) | OracleContract |
| [`GetGasPerBlock`](scapi/fw/dotnet/neo/Neo/GetGasPerBlock.md) | null | 0.00032768 (CpuFee) | NeoToken |
| GetRegisterPrice | null | 0.00032768 (CpuFee) | NeoToken |
| [`GetPrice`](scapi/fw/dotnet/neo/NameService/GetPrice.md) | null | 0.00032768 (CpuFee) | NameService |
| GetMinimumDeploymentFee | null | 0.00032768 (CpuFee) | ContractManagement |

#### 产生方式

将候选人根据票数多少排序，取最前面的一定数量候选人（默认21个）作为委员会。委员会名单将在每个区块根据最新投票更新。

#### 相关合约方法

| 方法 | 参数 | 费用（GAS） | 返回结果 |
| ---- | ------------------------------------ | ---- | ---- |
| [`GetCommittee`](scapi/fw/dotnet/neo/Neo/GetCommittee.md) | null | 0.04194304 (CpuFee) | 返回当前委员会（Array<ECPoint>） |

### 共识节点（Validator）

#### 职能

共识节点即具有发起新块提案和提案投票权限的节点。

#### 产生方式

将候选人根据票数多少排序，取最前面的一定数量候选人（默认7个）作为共识节点。与委员会类似，共识节点名单将在每个区块根据最新投票更新。

#### 相关合约方法

| 方法 | 参数 | 费用（GAS） | 返回结果 |
| ---- | ------------------------------------ | ---- | ---- |
| [`GetNextBlockValidators`](scapi/fw/dotnet/neo/Neo/GetNextBlockValidators.md) | null | 0.04194304 (CpuFee) | 返回下个块（正在持久化的块）的共识节点（Array<ECPoint>） |

## Token分配

初始高度下，NEO全部额度分配给初始共识节点的多签地址。
  
所有在Neo网络中的互动均通过交易（Transaction）进行，而交易需要GAS作为费用支付方式。交易包含系统费和网络费两种费用。其中，系统费作为交易执行的资源被消耗掉，而网络费将作为上链奖励，发放给交易所在区块的议长。

## Nep17合约方法

NEO及GAS均为[Nep17](https://github.com/neo-project/proposals/blob/master/nep-17.mediawiki)合约。Nep17的合约方法如下：

| 方法 | 参数 | 费用（GAS） | 作用 |
| ---- | ------------------------------------ | ---- | ---- |
| [`symbol`](govapi/symbol.md) | null | 0 | 返回Token标志（String） |
| [`decimals`](govapi/decimals.md) | null | 0 | 返回Token精度（UInt） |
| [`TotalSupply`](scapi/fw/dotnet/neo/Neo/TotalSupply.md) | null | 0.00032768 (CpuFee) | 返回Token当前流通量（BigInteger） |
| [`BalanceOf`](scapi/fw/dotnet/neo/Neo/BalanceOf.md) | UInt160 account | 0.00032768 (CpuFee) | 返回该账户的余额（BigInteger） |
| [`Transfer`](scapi/fw/dotnet/neo/Neo/Transfer.md) | UInt160 from, UInt160 to, BigInteger amount | 0.00131072 (CpuFee) + 0.0000005 (StorageFee)  | 将指定数额的Token从from转往to，注意这里需要校验from的签名，方法调用者是否为from，to是否能够收款，以及from余额是否充足 |

NEO扩展的合约方法如下：

| 方法 | 参数 | 费用（GAS） | 返回结果 |
| ---- | ------------------------------------ | ---- | ---- |
| [`UnclaimedGas`](scapi/fw/dotnet/neo/Neo/UnclaimedGas.md) | UInt160 account, uint end | 0.00131072 | 返回该账户到指定高度未提取的GAS（uint） |
