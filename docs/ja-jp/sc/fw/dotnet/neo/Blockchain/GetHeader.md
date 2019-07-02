# Blockchain.GetHeader メソッド (byte[])

指定のブロックハッシュにより、ブロックヘッダを返す。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Header GetHeader(byte[] hash)
```

パラメータ: 長さが32のバイト配列のブロックハッシュ。

戻り値: [Header](../Header.md)。

## 例

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] Header = new byte[] {206, 240, 165, 25, 76, 228, 58, 100, 117, 184, 213, 171, 61, 96, 34, 234, 129, 116, 60, 71, 11, 231, 143, 195, 123, 5, 190, 250, 182, 14, 152};
         Header bl = Blockchain.GetHeader(Header);
     }
}
```



[戻る](../Blockchain.md)
