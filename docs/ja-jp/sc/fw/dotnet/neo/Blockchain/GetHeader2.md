# Blockchain.GetHeader メソッド (uint)

指定されたブロック高さから、ブロックヘッダを返します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Header GetHeader(uint height)
```

パラメータ: unsigned integer型のブロック高さ。

戻り値: [Header](../Header.md)。

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Header bl = Blockchain.GetHeader(997027);
     }
}
```



[戻る](../Blockchain.md)
