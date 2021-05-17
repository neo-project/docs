# Policy 类

提供了原生合约 Policy 的一系列方法，合约哈希为 `0xcc5e4edd9f5f8dba8bb65734541df7a1c081c67b`。

命名空间：[Neo.SmartContract.Framework.Native](../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Policy
```

## 属性

| 名称              | 说明                                                         |
| ----------------- | ------------------------------------------------------------ |
| Hash              | 获取合约哈希                                            |

## 方法

| 名称                       | 说明                                                         |
| -------------------------- | ------------------------------------------------------------ |
| [GetFeePerByte()](Policy/GetFeePerByte.md)            | 获取每字节手续费                                             |
| [GetExecFeeFactor()](Policy/GetExecFeeFactor.md)         | 获取执行费用系数。这是一个乘数，可以由委员会调整，以调整交易的系统费用 |
| [GetStoragePrice()](Policy/GetStoragePrice.md)          | 获取存储价格                                                 |
| [IsBlocked(UInt160 account)](Policy/IsBlocked.md) | 确定指定账户是否被封锁                                       |