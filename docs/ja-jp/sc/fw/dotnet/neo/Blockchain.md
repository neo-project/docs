# Blockchain クラス

このクラスは、ブロックチェーンデータにアクセスするための一連のメソッドを提供します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static class Blockchain
```

## メソッド

| | 名前 | 説明 |
| ---------------------------------------- | ---------------------------------------- | -------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAccount(byte[])](Blockchain/GetAccount.md) | 指定されたスクリプトハッシュから、アカウント（アドレス）を返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAsset(byte[])](Blockchain/GetAsset.md) | 指定されたアセットIDから、アセットを返す         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBlock(byte[])](Blockchain/GetBlock.md) | 指定されたブロックハッシュから、ブロックを返す      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBlock(uint)](Blockchain/GetBlock2.md) | 指定されたブロックの高さから、ブロックを返す          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetContract(byte[])](Blockchain/GetContract.md) | `新規` 指定されたコントラクトハッシュから、コントラクトの内容を返す   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeader(byte[])](Blockchain/GetHeader.md) | 指定されたブロックハッシュから、ブロックヘッダを返す     |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeader(uint)](Blockchain/GetHeader2.md) | 指定されたブロックの高さから、ブロックヘッダを返す         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeight()](Blockchain/GetHeight.md)   | 現在のブロックの高さを返す             |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(byte[])](Blockchain/GetTransaction.md) | 指定されたトランザクションIDから、トランザクションを返す         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetValidators()](Blockchain/GetValidators.md) | `新規` バリデータのパブリックキーを返す       |

## コンストラクタ

BlockChainクラスは静的クラスであり、コンストラクタは必要ありません。

