# Transaction.Type 属性

获得当前交易的类型。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public extern byte Type { get; }
```

属性值：交易的类型，字节。

属性值说明：

```c#
//共识交易，用于分配字节费的特殊交易
MinerTransaction = 0x00,
//用于分发资产的特殊交易
IssueTransaction = 0x01,
//用于分配NeoGas的特殊交易
ClaimTransaction = 0x02,
//用于报名成为记账候选人的特殊交易
EnrollmentTransaction = 0x20,
//用于资产登记的特殊交易
RegisterTransaction = 0x40,
//合约交易，这是最常用的一种交易
ContractTransaction = 0x80,
//委托交易
AgencyTransaction = 0xb0,
//发布智能合约的交易
PublishTransaction = 0xd0,
//调用智能合约的交易
InvocationTransaction = 0xd1
```



[返回上级](../Transaction.md)