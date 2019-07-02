# Blockchain.GetBlock メソッド (uint)

指定されたブロック高さにより、ブロックチェーンからブロックを返します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Block GetBlock(uint height)
```

パラメータ: unsigned integer型のブロック高さ(ブロックインデックス)。

戻り値: [Block](../Block.md)。

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Block bl = Blockchain.GetBlock(997027);
     }
}
```



[戻る](../Blockchain.md)
