# Policy 类

提供了原生合约Policy的一系列方法，合约哈希为`0x1ca594b36b6b6b3f05efce8b106c824053d18713`。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Policy
```

## 方法

| 名称                                                         | 说明                                                         |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| Name()          | 合约名称                                     |
| [GetMaxTransactionsPerBlock()](Policy/GetMaxTransactionsPerBlock.md)             | 获取每区块最大交易数                                       |
| [GetMaxBlockSize()](Policy/GetMaxBlockSize.md) | 获取区块最大大小                                     |
| [GetMaxBlockSystemFee()](Policy/GetMaxBlockSystemFee.md)            | 获取区块最大的系统费                                     |
| [GetFeePerByte()](Policy/GetFeePerByte.md)           | 获取每字节手续费                                   |
| [IsBlocked(UInt160 account)](Policy/IsBlocked.md)            | 验证是否为黑名单账户                                   |
| [SetMaxBlockSize(uint value)](Policy/SetMaxBlockSize.md)            | 设置最大区块大小                                  |
| [SetMaxTransactionsPerBlock(uint value)](Policy/SetMaxTransactionsPerBlock.md)            | 设置每区块最大交易数                                     |
| [SetMaxBlockSystemFee(long value)](Policy/SetMaxBlockSystemFee.md)            | 设置区块最大系统手续费                                 |
| [SetFeePerByte(long value)](Policy/SetFeePerByte.md)         | 设置每字节手续费                               |
| [BlockAccount(UInt160 account)](Policy/BlockAccount.md)            | 将指定账户加入黑名单                                   |
| [UnblockAccount(UInt160 account)](Policy/UnblockAccount.md)           | 将指定账户解除黑名单                                   |
