# Blockchain.GetAsset メソッド (byte[])

指定されたアセットIDにより、ブロックチェーン上のアセットを返します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Asset GetAsset (byte[] asset_id)
```

パラメータ:長さが32のバイト配列のアセットID。

戻り値: [Asset](../Asset.md)。

## 例

```c#
public class Contract1: FunctionCode
{
    public static void Main()
    {
        // Take the NEO shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        Asset ass = Blockchain.GetAsset(asset);
    }
}
```

あらかじめアセットIDを取得し、パラメータとしてスマートコントラクトに渡すことができます。次のコードでは、SDKを使用して16進数文字列をバイト配列に変換しています。

```c#
Static void Main(string[] args)
{
    byte[] asset = Neo.Helper.HexToBytes("c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b");
}
```



[戻る](../Blockchain.md)

