# Storage クラス

永続化ストアのデータの追加、問い合わせ、削除をするための、一連のメソッドを提供します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static class Storage
```

## 属性

| | 名前 | 説明 |
| ---------------------------------------- | ---------------------------------------- | ---------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [CurrentContext](Storage/CurrentContext.md) | 現在のストアのコンテキストを返す |

## メソッド

| | 名前 | 説明 |
| ---------------------------------------- | ---------------------------------------- | -------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Delete(StorageContext, byte[])](Storage/Delete.md) | 与えられたキーに基づいて、永続化ストアから値を削除する |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Delete(StorageContext, string)](Storage/Delete2.md) | 与えられたキーに基づいて、永続化ストアから値を削除する |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Get(StorageContext, byte[])](Storage/Get.md) | 与えられたキーに基づいて、永続化ストアから値を返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Get(StorageContext, string)](Storage/Get2.md) | 与えられたキーに基づいて、永続化ストアから値を返す |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, byte[], byte[])](Storage/Put.md) | 永続ストアの指定されたキーに、所定の値を挿入する |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, byte[], string)](Storage/Put2.md) | 永続ストアの指定されたキーに、所定の値を挿入する |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, string, byte[])](Storage/Put3.md) | 永続ストアの指定されたキーに、所定の値を挿入する |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, string, string)](Storage/Put4.md) | 永続ストアの指定されたキーに、所定の値を挿入する|

## コンストラクタ

Storageクラスは静的クラスなので、コンストラクタは必要ありません。

