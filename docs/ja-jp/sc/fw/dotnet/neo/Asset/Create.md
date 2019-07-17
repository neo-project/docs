# Asset.CreateAsset メソッド (byte, string, long, byte, byte[], byte[], byte[])

このメソッドは、NEOブロックチェーンにアセットを登録します。

このメソッドは、バージョン2.0においてRegisterTransactionから置き換わります。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Asset Create(byte asset_type, string name, long amount, byte precision, byte[] owner, byte[] admin, byte[] issuer)
```

パラメータ:

asset_type: byte型のアセットタイプです。詳細については、[AssetType](../Asset/AssetType.md)を参照してください。

name: string型のアセットの名前です。

amount: long型のアセットの合計です。ここでの入力値は、100,000,000を掛けた値である必要があります。

precision:byte型のアセットの最小区分、つまりアセットが取ることができる小数点以下の桁数です。

owner: 長さが33のバイト配列の、所有者のパブリックキーです。

admin: 長さが20のバイト配列の、管理者のコントラクトアドレスです。

issuer: 長さが20のバイト配列の、発行者のコントラクトアドレスです。

戻り値: [Asset](../Asset.md)オブジェクト型の、新たに登録されたアセットです。

## 例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte assetType = 0x60; //Token
        string name = "StarWarsMovieTicket";
        long amount = 1000;
        byte precision = 0;
        byte[] owner = { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202 };
        byte[] admin = { 36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73 };
        byte[] issuer = admin;
        Asset ass = Asset.Create(assetType, name, amount, precision, owner, admin, issuer);
        uint blockIndex = ass.Renew(1);
    }
}
```



[戻る](../Asset.md)
