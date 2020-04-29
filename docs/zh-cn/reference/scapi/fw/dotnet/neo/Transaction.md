# Transaction 类

用来表示交易的基类。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Transaction
```

## 属性

| 名称                          | 说明           |
| --------------------------- | ------------ |
| Hash | 当前交易的散列值 |
| Version | 交易版本号，目前为0    |
| Nonce | 随机数 |
| Sender | 发送方的地址脚本哈希    |
| SystemFee| 系统费，支付给网络的资源费用 |
| NetworkFee | 网络费，支付给验证人打包交易的费用    |
| ValidUntilBlock | 交易的有效期 |
| Script | 交易的合约脚本    |

## 构造方法

通过 [Blockchain.GetTransaction(byte\[\])](Blockchain/GetTransaction.md) 或 [Blockchain.GetTransactionFromBlock](Blockchain/GetTransactionFromBlock.md)来构造 Transaction 对象。