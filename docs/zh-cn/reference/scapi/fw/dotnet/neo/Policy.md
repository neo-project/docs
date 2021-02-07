# Policy 类

提供了原生合约 Policy 的一系列方法，合约哈希为 `0x79bcd398505eb779df6e67e4be6c14cded08e2f2`。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

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

| 名称                                                         | 说明                 |
| ------------------------------------------------------------ | -------------------- |
| [GetMaxTransactionsPerBlock()](Policy/GetMaxTransactionsPerBlock.md) | 获取每区块最大交易数 |
| [GetMaxBlockSize()](Policy/GetMaxBlockSize.md)               | 获取区块最大大小     |
| [GetMaxBlockSystemFee()](Policy/GetMaxBlockSystemFee.md)     | 获取区块最大的系统费 |
| [GetFeePerByte()](Policy/GetFeePerByte.md)                   | 获取每字节手续费     |
| [IsBlocked(UInt160 account)](Policy/IsBlocked.md)            | 验证是否为黑名单账户 |
| [BlockAccount(UInt160 account)](Policy/BlockAccount.md)      | 将指定账户加入黑名单 |
| [UnblockAccount(UInt160 account)](Policy/UnblockAccount.md)  | 将指定账户解除黑名单 |
