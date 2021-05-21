# 治理 API

## 候选人

候选人本身并无职能。根据候选人得票数量排序，排在最前面的一定数量的候选人将被选为委员会成员和共识节点。

### 产生方式

通过注册可以成为候选人，也可以通过注销解除候选人资格。相应的合约方法如下：

| 方法 | 参数 | 费用（GAS） |
| ---- | ------------------------------------ | ---- |
| [`RegisterCandidate`](scapi/framework/native/Neo/RegisterCandidate.md) | ECPoint publicKey | 可调，初始0.00001 |
| [`UnregisterCandidate`](scapi/framework/native/Neo/UnregisterCandidate.md) | ECPoint publicKey | 0.00065536 (CpuFee) |

> [!Note]
>
> 注册/注销候选人均需要验证候选人地址的签名，即只有候选人自己才能执行注册/注销操作。

### 候选人投票

每个地址均有投票给一个地址的权利，候选人票数为所有向该账户投票的地址的NEO余额之和。初始块所有默认候选人均会向自己投票。

投票相关合约方法如下，这里注意，投票需要验证投票者的签名。

| 方法 | 参数 | 费用（GAS） |
| ---- | ------------------------------------ | ---- |
| [`Vote`](scapi/framework/native/Neo/Vote.md) | UInt160 account, byte[] voteTo | 0.00065536 (CpuFee) |

由于账户NEO余额会随交易而不断变化，而且投票和注册的候选人也在不断变化，因此在每个区块都会根据以上变化更新候选人及相应投票结果。

| 方法 | 参数 | 费用（GAS） |
| ---- | ------------------------------------ | ---- |
| [`GetCandidates`](scapi/framework/native/Neo/GetCandidates.md) | null | 0 |

## 委员会

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
* 设置NNS的注册/续费费用
* NNS合约更新
* 设置部署合约的最小费用

其对应的合约方法及相关费用如下所示：

| 方法 | 参数 | 费用（GAS） | 合约 |
| ---- | ------------------------------------ | ---- | ---- |
| DesignateAsRole | Role role, ECPoint[] nodes | 0.00032768 (CpuFee) | RoleManagement |
| SetFeePerByte | long value | 0.00032768 (CpuFee) | PolicyContract |
| SetExecFeeFactor | uint value | 0.00032768 (CpuFee) | PolicyContract |
| SetStoragePrice | uint value | 0.00032768 (CpuFee) | PolicyContract |
| SetPrice | long price | 0.00032768 (CpuFee) | OracleContract |
| SetGasPerBlock | BigInteger gasPerBlock | 0.00032768 (CpuFee) | NeoToken |
| SetRegisterPrice | long registerPrice | 0.00032768 (CpuFee) | NeoToken |
| AddRoot | string root | 0.00032768 (CpuFee) | NameService |
| SetPrice | long price | 0.00032768 (CpuFee) | NameService |
| Update | ByteString nef, string manifest | StoragePrice * (nefFile.Length + manifest.Length) | NameService |
| SetMinimumDeploymentFee | BigInteger value | 0.00032768 (CpuFee) | ContractManagement |

委员会可以通过发送包含多签的，调用相应合约方法的交易上链使投票生效。投票数超过委员会数量的一半的向上取整即为有效投票，相应操作将被执行生效。

另外也支持以下数据的读方法：

| 方法 | 参数 | 费用（GAS） | 合约 |
| ---- | ------------------------------------ | ---- | ---- |
| [`GetDesignatedByRole`](scapi/framework/native/RoleManagement/GetDesignatedByRole.md) | Role role, uint index | 0.00032768 (CpuFee) | RoleManagement |
| [`GetFeePerByte`](scapi/framework/native/Policy/GetFeePerByte.md) | null | 0.00032768 (CpuFee) | PolicyContract |
| GetExecFeeFactor | null | 0.00032768 (CpuFee) | PolicyContract |
| GetStoragePrice | null | 0.00032768 (CpuFee) | PolicyContract |
| [`IsBlocked`](scapi/framework/native/Policy/IsBlocked.md) | UInt160 account | 0.00032768 (CpuFee) | PolicyContract |
| GetPrice | null | 0.00032768 (CpuFee) | OracleContract |
| [`GetGasPerBlock`](scapi/framework/native/Neo/GetGasPerBlock.md) | null | 0.00032768 (CpuFee) | NeoToken |
| GetRegisterPrice | null | 0.00032768 (CpuFee) | NeoToken |
| GetMinimumDeploymentFee | null | 0.00032768 (CpuFee) | ContractManagement |

### 产生方式

将候选人根据票数多少排序，取最前面的一定数量候选人（默认21个）作为委员会。委员会名单每 21 个区块更新一次。

#### 相关合约方法

| 方法 | 参数 | 费用（GAS） | 返回结果 |
| ---- | ------------------------------------ | ---- | ---- |
| [`GetCommittee`](scapi/framework/native/Neo/GetCommittee.md) | null | 0.04194304 (CpuFee) | 返回当前委员会（Array<ECPoint>） |

## 共识节点

共识节点即具有发起新块提案和提案投票权限的节点。

### 产生方式

将候选人根据票数多少排序，取最前面的一定数量候选人（默认7个）作为共识节点。同样的，共识节点名单也会每隔 21 个区块根据最新投票结果更新。

#### 相关合约方法

| 方法 | 参数 | 费用（GAS） | 返回结果 |
| ---- | ------------------------------------ | ---- | ---- |
| [`GetNextBlockValidators`](scapi/framework/native/Neo/GetNextBlockValidators.md) | null | 0.04194304 (CpuFee) | 返回下个块（正在持久化的块）的共识节点（Array<ECPoint>） |

## Token分配

初始高度下，NEO全部额度分配给初始共识节点的多签地址。

所有在Neo网络中的互动均通过交易（Transaction）进行，而交易需要GAS作为费用支付方式。交易包含系统费和网络费两种费用。其中，系统费作为交易执行的资源被消耗掉，而网络费将作为上链奖励，发放给交易所在区块的议长。

## Nep17合约方法

NEO及GAS均为[Nep17](https://github.com/neo-project/proposals/blob/master/nep-17.mediawiki)合约。Nep17的合约方法如下：

| 方法 | 参数 | 费用（GAS） | 作用 |
| ---- | ------------------------------------ | ---- | ---- |
| [`symbol`](govapi/symbol.md) | null | 0 | 返回Token标志（String） |
| [`decimals`](govapi/decimals.md) | null | 0 | 返回Token精度（UInt） |
| [`TotalSupply`](scapi/framework/native/Neo/TotalSupply.md) | null | 0.00032768 (CpuFee) | 返回Token当前流通量（BigInteger） |
| [`BalanceOf`](scapi/framework/native/Neo/BalanceOf.md) | UInt160 account | 0.00032768 (CpuFee) | 返回该账户的余额（BigInteger） |
| [`Transfer`](scapi/framework/native/Neo/Transfer.md) | UInt160 from, UInt160 to, BigInteger amount | 0.00131072 (CpuFee) + 0.0000005 (StorageFee)  | 将指定数额的Token从from转往to，注意这里需要校验from的签名，方法调用者是否为from，to是否能够收款，以及from余额是否充足 |

NEO扩展的合约方法如下：

| 方法 | 参数 | 费用（GAS） | 返回结果 |
| ---- | ------------------------------------ | ---- | ---- |
| [`UnclaimedGas`](scapi/framework/native/Neo/UnclaimedGas.md) | UInt160 account, uint end | 0.00131072 (CpuFee) | 返回该账户到指定高度未提取的GAS（uint） |