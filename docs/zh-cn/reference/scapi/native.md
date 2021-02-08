# 原生合约

Neo3 提供了大量的原生合约，原生合约是 Neo3 中NeoContract组件的一部分。

在 Neo3 中，一切皆合约。对于NEO和GAS这类系统对象，它们也运行在智能合约之中。虽然使用普通的智能合约来构建NEO和GAS也是一个可行的方案，但是采用原生合约来构建的NEO和GAS的运行速度更快。

| 合约名称                                                  | 合约哈希                                   | 说明                                                         |
| --------------------------------------------------------- | ------------------------------------------ | ------------------------------------------------------------ |
| [ContractManagement](fw/dotnet/neo/ContractManagement.md) | 0xfffdc93764dbaddd97c48f252a53ea4643faa3fd | 管理合约的合约                                               |
| [GasToken](fw/dotnet/neo/GAS.md)                          | 0xd2a4cff31913016155e38e474a2c06d08be276cf | GAS相关合约                                                  |
| [LedgerContract](fw/dotnet/neo/Ledger.md)                 | 0xda65b600f7124ce6c79950c1772a36403104f2be | 包括所有与账本相关的功能（如区块，交易等）的合约             |
| [NameService](fw/dotnet/neo/NameService.md)               | 0x7a8fcf0392cd625647907afa8e45cc66872b596b | Neo域名服务合约，通过该合约，用户将可以直接向某个域名发起交易，而不需要记住繁杂的对方地址。 |
| [NeoToken](fw/dotnet/neo/NEO.md)                          | 0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5 | NEO相关合约                                                  |
| [OracleContract](fw/dotnet/neo/Oracle.md)                 | 0xfe924b7cfe89ddd271abaf7210a80a7e11178758 | 预言机合约，通过去中心化的方式获取相应信息供调用者合约使用   |
| [PolicyContract](fw/dotnet/neo/Policy.md)                 | 0xcc5e4edd9f5f8dba8bb65734541df7a1c081c67b | 共识策略合约                                                 |
| [RoleManagement](fw/dotnet/neo/RoleManagement.md)         | 0x49cf4e5378ffcd4dec034fd98a174c5491e395e2 | 权限查询合约                                                 |

