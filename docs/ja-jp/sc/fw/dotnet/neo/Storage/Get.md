# Storage.Get メソッド (StorageContext, byte[])

与えられたキーに基づき、永続化ストアから値を返します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public extern byte[] Get(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

パラメータ:

Context: [StorageContext](../StorageContext.md)。

Key: バイト配列のキー。

戻り値: バイト配列の、キーに対応する値。

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] value = Storage.Get(Storage.CurrentContext, new byte[] {0});
     }
}
```



[戻る](../Storage.md)
