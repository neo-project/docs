# TransactionAttribute クラス

トランザクションの属性を表すデータ構造です。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public class TransactionAttribute: IApiInterface
```

## 属性

| | 名前 | 説明 |
| ---------------------------------------- | -------------------------------------- | ----------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Data](TransactionAttribute/Data.md)   | トランザクションの目的以外のデータを返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Usage](TransactionAttribute/Usage.md) | トランザクションの目的に関連したデータを返す       |

## コンストラクタ

TransactionAttributeオブジェクトはTransactionオブジェクトの[GetAttributes ()](Transaction/GetAttributes.md)を通じてコンストラクトされます。
