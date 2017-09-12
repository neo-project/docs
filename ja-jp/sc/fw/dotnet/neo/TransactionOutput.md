# TransactionOutput クラス

トランザクションの出力を表すデータ構造です。トランザクションの出力には、3つのフィールドがあります。

1. アセットのタイプ
2. 宛先のアドレス
3. 転送量

名前空間: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public class TransactionOutput: IApiInterface
```

## 属性

| | 名前 | 説明 |
| ---------------------------------------- | ---------------------------------------- | ------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](TransactionOutput/AssetId.md)  | アセットIDを返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptHash](TransactionOutput/ScriptHash.md) | スクリプトハッシュを返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Value](TransactionOutput/Value.md)      | トランザクション数を返す |


## コンストラクタ

TransactionOutputオブジェクトは、Transactionオブジェクトの[GetOutputs()](Transaction/GetOutputs.md)を通じてコンストラクトされます。
