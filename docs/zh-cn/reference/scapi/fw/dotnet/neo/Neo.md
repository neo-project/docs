# Neo 类

提供了原生合约NeoToken的一系列属性与方法，合约哈希为`0xe22f9134cef8b03e53f71b3f960a20a65cddc972`。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class NEO
```

## 属性

| 名称              | 说明                                                         |
| ----------------- | ------------------------------------------------------------ |
| Name              | 获取名称, 即：NEO                                             |
| Symbol           | 获取符号, 即: neo                                           |
| Decimals          | 获取精度                                   |

## 方法

| 名称                                                         | 说明                                                         |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [TotalSupply()](Neo/TotalSupply.md)          | 获取NEO总发行量                                     |
| [BalanceOf(UInt160 account)](Neo/BalanceOf.md)             | 获取余额                                       |
| [Transfer(UInt160 from, UInt160 to, BigInteger amount)](Neo/Transfer.md) | 转账                                     |
| [SetGasPerBlock(BigInteger gasPerBlock)](Neo/SetGasPerBlock.md)            | 设置每出一个区块所产生的GAS数                                     |
| [GetGasPerBlock()](Neo/GetGasPerBlock.md)           | 获取当前每个区块可产生的GAS数                                   |
| [UnclaimedGas(UInt160 account, uint end)](Neo/UnclaimedGas.md)            | 获取未领取的Gas数                                   |
| [RegisterCandidate(ECPoint pubkey)](Neo/RegisterCandidate.md)            | 注册为候选人                                  |
| [UnRegisterCandidate(ECPoint pubkey)](Neo/UnRegisterCandidate.md)            | 取消注册为候选人                                     |
| [Vote(UInt160 account, ECPoint voteTo)](Neo/Vote.md)            | 投票                                 |
| [GetCandidates()](Neo/GetCandidates.md)         | 获取候选人列表                               |
| [GetCommittee()](Neo/GetCommittee.md)            | 获取委员会成员列表                                   |
| [GetNextBlockValidators()](Neo/GetNextBlockValidators.md)           | 获取下个区块的验证人列表                                   |
