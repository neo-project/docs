# GAS 类

提供了原生合约GasToken的一系列属性与方法，合约哈希为`0xd2a4cff31913016155e38e474a2c06d08be276cf`。

GasToken 同时也是NEP-17合约，继承了NEP-17合约所有的属性和方法。

命名空间：[Neo.SmartContract.Framework.Native](../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class GAS
```

## 属性

| 名称              | 说明                                                         |
| ----------------- | ------------------------------------------------------------ |
| Hash              | 获取合约哈希                                            |
| Symbol           | 获取符号, 即: gas                                           |
| Decimals          | 获取精度                                   |

## 方法

| 名称                                                         | 说明                             |
| ------------------------------------------------------------ | -------------------------------- |
| [TotalSupply()](Gas/TotalSupply.md)                          | 获取GAS总发行量                  |
| [BalanceOf(UInt160 account)](Gas/BalanceOf.md)               | 获取余额                         |
| [Transfer(UInt160 from, UInt160 to, BigInteger amount, object data = null)](Gas/Transfer.md) | 转账                             |
| Refuel                                                       | 为智能合约执行补充燃料（手续费） |