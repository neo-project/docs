# StorageContext 列挙型

プライベートストアのストレージコンテキストの列挙型（enum）を表すのに使用します。

> [!警告]
> 注意: バージョン2.0で廃止予定です。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public enum StorageContext: byte
```

## 列挙値

| | 名前 | 説明 |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [CallingContract](StorageContext/CallingContract.md) | 呼び出し元のストレージコンテキスト |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [Current](StorageContext/Current.md) | 現在のコントラクトのストレージコンテキスト |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [EntryContract](StorageContext/EntryContract.md) | コントラクトのエントリーポイント（コントラクトコールチェーンの開始ポイント） |
