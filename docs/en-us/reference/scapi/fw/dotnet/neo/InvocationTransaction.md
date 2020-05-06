# InvocationTransaction 类

用来表示 InvocationTransaction 的类。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class InvocationTransaction : Transaction
```

## 属性

|                                                        | 名称                                      | 说明                           |
| ------------------------------------------------------ | ----------------------------------------- | ------------------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Script](InvocationTransaction/Script.md) | 获得当前交易的智能合约调用脚本 |

## 构造方法

通过 [Blockchain.GetTransaction(byte[])](Blockchain/GetTransaction.md) 来构造 Transaction 对象。