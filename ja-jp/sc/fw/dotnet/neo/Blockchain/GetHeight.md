# Blockchain.GetHeight メソッド ()

ブロックチェーンの、現在のブロック高さを返します。(ブロック高さ) = (ブロックインデックス) = (ブロック数 - 1)です。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern uint GetHeight()
```

戻り値: unsigned integer型のブロック高さ。

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Uint height = Blockchain.GetHeight();
     }
}
```



[戻る](../Blockchain.md)
