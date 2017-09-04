# TransactionOutput 类

用来表示交易输出的数据结构。一个交易输出有三个字段，转账的是哪种资产，转账到哪个地址，转了多少金额。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class TransactionOutput : IApiInterface
```

## 属性

|                                          | 名称                                       | 说明     |
| ---------------------------------------- | ---------------------------------------- | ------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](TransactionOutput/AssetId.md)  | 获得资产 ID |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptHash](TransactionOutput/ScriptHash.md) | 获得脚本散列 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Value](TransactionOutput/Value.md)      | 获得交易金额 |

## 构造方法

通过 Transaction 对象的 [GetOutputs()](Transaction/GetOutputs.md) 方法来构造 TransactionOutput 对象。