# Block クラス

ブロックを表すクラスで、ブロック内のトランザクションを問い合わせる手段を提供します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public class Block: Header
```

## メソッド

| | 名前 | 説明 |
| ---------------------------------------- | ---------------------------------------- | ------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(int)](Block/GetTransaction.md) | ブロック内の指定されたトランザクションを返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactionCount()](Block/GetTransactionCount.md) | ブロック内のトランザクション数を返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransactions()](Block/GetTransactions.md) | ブロック内の全てのトランザクションを返す |

## コンストラクタ

Blockオブジェクトは、[Blockchain.GetBlock(byte[])](Blockchain/GetBlock.md)を通じてコンストラクトされます。

Blockオブジェクトは、[Blockchain.GetBlock(uint)](Blockchain/GetBlock2.md)を通じてコンストラクトされます。
