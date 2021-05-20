# Neo.SmartContract.Framework.Native

在智能合约中可以调用原生合约中的一系列方法。

## 原生合约类

| 合约名称                                                     | 合约哈希                                   | 说明                                         |
| ------------------------------------------------------------ | ------------------------------------------ | -------------------------------------------- |
| [ContractManagement](native/ContractManagement.md) | 0xfffdc93764dbaddd97c48f252a53ea4643faa3fd | 管理合约的合约                               |
| [CryptoLib](native/CryptoLib.md) | 0x726cb6e0cd8628a1350a611384688911ab75f51b | 集成了散列运算、验签等密码学方法的合约       |
| [GAS](native/GAS.md)             | 0xd2a4cff31913016155e38e474a2c06d08be276cf | GAS相关合约                                  |
| [Ledger](native/Ledger.md)       | 0xda65b600f7124ce6c79950c1772a36403104f2be | 区块链协议层合约                             |
| [NEO](native/NEO.md)             | 0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5 | NEO相关合约                                  |
| [Oracle](native/Oracle.md)       | 0xfe924b7cfe89ddd271abaf7210a80a7e11178758 | 预言机合约                                   |
| [Policy](native/Policy.md)       | 0xcc5e4edd9f5f8dba8bb65734541df7a1c081c67b | 共识策略合约                                 |
| [RoleManagement](native/RoleManagement.md) | 0x49cf4e5378ffcd4dec034fd98a174c5491e395e2 | 权限查询合约                                 |
| [StdLib](native/StdLib.md)       | 0xacce6fd80d44e1796aa0c2c625e9e4e0ce39efc0 | 集成了序列化、反序列化和格式转换等方法的合约 |

## 枚举

| 枚举                                                         | 说明                                                 |
| ------------------------------------------------------------ | ---------------------------------------------------- |
| [NamedCurve](native/NamedCurve.md) | 支持的椭圆曲线扩展                                   |
| [OracleResponseCode](native/OracleResponseCode.md) | 定义了 Oracle 响应代码的类型                         |
| [Role](native/Role.md)           | 定义了 RoleManagement 原生合约中的权限类型           |
