# Transaction クラス

トランザクションの基底クラスを表すのに使用します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public class Transaction: IScriptContainer
```

## 属性

| | 名前 | 説明 |
| ---------------------------------------- | --------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Hash](Transaction/Hash.md) | トランザクションのハッシュを返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Type](Transaction/Type.md) | トランザクションのタイプを返す |

## メソッド

| | 名前 | 説明 |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAttributes()](Transaction/GetAttributes.md) | トランザクションの、全ての属性を返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetInputs()](Transaction/GetInputs.md)  | トランザクションの、全ての[TransactionInput](TransactionInput.md)を返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetOutputs()](Transaction/GetOutputs.md) | トランザクションの、全ての[TransactionOutput](TransactionOutput.md)を返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetReferences()](Transaction/GetReferences.md) | トランザクションの入力によって参照される、全ての出力を返す |

## コンストラクタ
Transactionオブジェクトは、[Blockchain.GetTransaction(byte[])](Blockchain/GetTransaction.md)を通じてコンストラクトされます。
