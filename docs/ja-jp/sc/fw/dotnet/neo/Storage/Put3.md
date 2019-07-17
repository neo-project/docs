# Storage.Put メソッド (StorageContext, string, byte[])

永続化ストア内の指定されたキーに、所定の値を挿入します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key, byte[] value)
```

パラメータ:

Context: [StorageContext](../StorageContext.md)型の、ストレージコンテキスト。

Key: string型のキー。

Value: バイト配列の値。

戻り値: void。

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         String key = "key";
         byte[] value = new byte[] {1};
         Storage.Put(Storage.CurrentContext, key, value);
     }
}
```



[戻る](../Storage.md)
