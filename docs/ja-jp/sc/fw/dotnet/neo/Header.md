# Header クラス

ブロックヘッダのデータ構造を表します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public class Header: IScriptContainer
```

## 属性

| | 名前 | 説明 |
| ---------------------------------------- | ---------------------------------------- | -------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ConsensusData](Header/ConsensusData.md) | （コンセンサスノードによって生成される）ブロックのコンセンサスデータを返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Hash](Header/ConsensusData.md)          | ブロックハッシュを返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [MerkleRoot](Header/MerkleRoot.md)       | ブロック内の全てのトランザクションのマークル木のルートを返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [NextConsensus](Header/NextConsensus.md) | 次のブックキーパーのハッシュを返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash](Header/PrevHash.md)           | 前のブロックのハッシュを返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Timestamp](Header/Timestamp.md)         | ブロックのタイムスタンプを返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Version](Header/Version.md)             | ブロックのバージョンを返す  |

## コンストラクタ

Headerオブジェクトは、[Blockchain.GetHeader(byte[])](Blockchain/GetHeader.md)を通じてコンストラクトされます。

Headerオブジェクトは、[Blockchain.GetHeader(uint)](Blockchain/GetHeader2.md)を通じてコンストラクトされます。
