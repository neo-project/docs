# TransactionAttribute 类

用来表示交易特性的数据结构。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class TransactionAttribute : IApiInterface
```

## 属性

|                                          | 名称                                     | 说明                |
| ---------------------------------------- | -------------------------------------- | ----------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Data](TransactionAttribute/Data.md)   | 获得该交易特性中用途之外的额外数据 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Usage](TransactionAttribute/Usage.md) | 获得该交易特性中的用途       |

## 构造方法

通过 Transaction 对象的 [GetAttributes()](Transaction/GetAttributes.md) 方法来构造 TransactionAttribute 对象。