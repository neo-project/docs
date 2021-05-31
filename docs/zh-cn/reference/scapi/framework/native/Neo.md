# Neo 类

提供了原生合约NeoToken的一系列属性与方法，合约哈希为`0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5`。

NeoToken 同时也是NEP-17合约，继承了NEP-17合约所有的属性和方法。

命名空间：[Neo.SmartContract.Framework.Native](../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class NEO
```

## 属性

| 名称              | 说明                                                         |
| ----------------- | ------------------------------------------------------------ |
| Hash     | 获取合约哈希      |
| Symbol           | 获取符号, 即: NEO                                          |
| Decimals          | 获取精度                                   |

## 方法

| 名称                                                         | 说明                          |
| ------------------------------------------------------------ | ----------------------------- |
| [TotalSupply()](Neo/TotalSupply.md)                          | 获取NEO总发行量               |
| [BalanceOf(UInt160 account)](Neo/BalanceOf.md)               | 获取余额                      |
| [Transfer(UInt160 from, UInt160 to, BigInteger amount, object data = null)](Neo/Transfer.md) | 转账                          |
| [GetGasPerBlock()](Neo/GetGasPerBlock.md)                    | 获取当前每个区块可产生的GAS数 |
| [UnclaimedGas(UInt160 account, uint end)](Neo/UnclaimedGas.md) | 获取未领取的GAS数             |
| [RegisterCandidate(ECPoint pubkey)](Neo/RegisterCandidate.md) | 注册为候选人                  |
| [UnRegisterCandidate(ECPoint pubkey)](Neo/UnRegisterCandidate.md) | 取消注册为候选人              |
| [Vote(UInt160 account, ECPoint voteTo)](Neo/Vote.md)         | 投票                          |
| [GetCandidates()](Neo/GetCandidates.md)                      | 获取候选人列表                |
| [GetCommittee()](Neo/GetCommittee.md)                        | 获取委员会成员列表            |
| [GetNextBlockValidators()](Neo/GetNextBlockValidators.md)    | 获取下个区块的验证人列表      |
| [GetAccountState(DataCache snapshot, UInt160 account)](Neo/GetAccountState.md) | 获取指定账户最新的投票情况    |

