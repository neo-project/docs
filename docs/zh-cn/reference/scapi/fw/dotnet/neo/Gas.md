# GAS 类

提供了原生合约GasToken的一系列属性与方法。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class GAS
```

## 属性

| 名称              | 说明                                                         |
| ----------------- | ------------------------------------------------------------ |
| Name              | 获取名称, GAS                                             |
| Symbol           | 获取符号, 即: gas                                           |
| Decimals          | 获取精度                                   |

## 方法

| 名称                                                         | 说明                                                         |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [TotalSupply()](Gas/TotalSupply.md)          | 获取GAS总发行量                                     |
| [BalanceOf(byte\[\] account)](Gas/BalanceOf.md)             | 获取余额                                       |
| [Transfer(byte\[\] from, byte\[\] to, BigInteger amount)](Gas/Transfer.md) | 转账                                     |