# StorageContext クラス

永続化ストアのストレージコンテキストを表すクラスです。

スマートコントラクトは、Storage.CurrentContextをを介して自身のストレージコンテキストを取得し、引数としてコンテキストを(許可の方法として)他のコントラクトに渡すことで、他のコントラクトが永続化ストアのリード/ライトメソッドを呼ぶことができます。

注意: これはバージョン1.6とは異なります。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public class StorageContext
```

## コンストラクタ

StorageContextオブジェクトは、[Storage.CurrentContext](Storage/CurrentContext.md)を通じてコンストラクトされます。
