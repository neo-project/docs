# TransactionInput 类

用来表示交易输入的数据结构。

在 UTXO（未花费的币）系统中，某笔交易的输入必是来自于之前存在的另一笔交易的输出。确认之前的交易的输出需要两个字段，即之前的这笔交易的散列（[PrevHash](TransactionInput/PrevHash.md)），和之前这笔交易的输出所在全部输出的索引（[PrevIndex](TransactionInput/PrevIndex.md)）。 

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class TransactionInput : IApiInterface
```

## 属性

|                                          | 名称                                       | 说明                     |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash](TransactionInput/PrevHash.md) | 所引用的交易的交易散列            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevIndex](TransactionInput/PrevIndex.md) | 所引用的交易输出在其全部交易输出列表中的索引 |

## 构造方法

通过 Transaction 对象的 [GetInputs()](Transaction/GetInputs.md) 方法来构造 TransactionInput 对象。