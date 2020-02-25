# Transaction 类

用来表示交易的基类。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Transaction
```

## 属性

|                                          | 名称                          | 说明           |
| ---------------------------------------- | --------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | Hash | 当前交易的散列值 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | Version | 交易版本号，目前为0    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | Nonce | 随机数 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | Sender | 发送方的地址脚本哈希    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | SystemFee| 系统费，支付给网络的资源费用 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | NetworkFee | 网络费，支付给验证人打包交易的费用    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | ValidUntilBlock | 交易的有效期 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | Script | 交易的合约脚本    |

## 构造方法

通过 [Blockchain.GetTransaction(byte\[\])](Blockchain/GetTransaction.md) 或 [Blockchain.GetTransactionFromBlock](Blockchain/GetTransactionFromBlock.md)来构造 Transaction 对象。