# Storage.CurrentContext プロパティ

現在のストアのコンテキストを返します。ストアのコンテキストを取得した後、（許可の方法として）そのオブジェクトを他のコントラクトへ引数として渡すことで、他のコントラクトが、現在のコントラクトの永続化ストアで読み/書き操作を実行できるようになります。

注意: これはバージョン1.6とは異なります。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.StorageContext CurrentContext {get;}
```

属性値: [StorageContext](../StorageContext.md)型の現在のストレージコンテキスト。



[戻る](../Storage.md)
