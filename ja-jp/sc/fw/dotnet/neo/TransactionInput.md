# TransactionInput クラス

トランザクションの入力のデータ構造を表すのに使用します。

UTXOシステムにおいて、トランザクションの入力は、以前に存在していた別のトランザクションの出力から来なければなりません。

1つ前のトランザクションの出力を確認するには、次の2つのものが必要です。

1.  参照される1つ前のトランザクションのハッシュ（[PrevHash](TransactionInput/PrevHash.md)）
2.  1つ前のトランザクションの出力リストにある、この入力のインデックス（[PrevIndex](TransactionInput/PrevIndex.md)）

名前空間: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public class TransactionInput: IApiInterface
```

## 属性

| | 名前 | 説明 |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash](TransactionInput/PrevHash.md) | 1つ前のトランザクションのハッシュを返す            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevIndex](TransactionInput/PrevIndex.md) | 1つ前のトランザクションの出力リストにある、この入力のインデックスを返す |

## コンストラクタ

TransactionInputオブジェクトはTransactionオブジェクトの[GetInputs()](Transaction/GetInputs.md)を通じてコンストラクトされます。
