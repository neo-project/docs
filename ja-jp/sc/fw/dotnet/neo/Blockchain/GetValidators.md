# Blockchain.GetValidators メソッド ()

バリデータ（コンセンサスノード）のパブリックキーを返します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern byte[][] GetValidators()
```

戻り値: パブリックキーの配列で、各要素は長さが33のバイト配列です。

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[][] validators = Blockchain.GetValidators();
     }
}
```



[戻る](../Blockchain.md)
