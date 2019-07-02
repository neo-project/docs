# Storage.Delete メソッド (StorageContext, byte[])

与えられたキーに基づき、永続化ストアから値を削除します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public extern void Delete(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

パラメータ:

Context: [StorageContext](../StorageContext.md)型の、ストレージコンテキスト。

Key: バイト配列のキー。

戻り値: void。

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Storage.Delete(Storage.CurrentContext, new byte[] {0});
     }
}
```



[戻る](../Storage.md)
