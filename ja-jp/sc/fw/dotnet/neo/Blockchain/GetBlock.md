# Blockchain.GetBlock メソッド (byte[])

指定されたブロックハッシュにより、ブロックチェーンからブロックを返します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Block GetBlock(byte[] hash)
```

パラメータ:長さが32のバイト配列のブロックハッシュ。

戻り値: [Block](../Block.md)。

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] block = new byte[] {206, 240, 165, 25, 76, 228, 58, 100, 117, 184, 213, 171, 61, 96, 34, 234, 129, 116, 60, 71, 11, 231, 143, 195, 123, 5, 190, 250, 182, 14, 152};
         Block bl = Blockchain.GetBlock(block);
     }
}
```



[戻る](../Blockchain.md)
