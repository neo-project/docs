# Account.GetBalance メソッド (byte[])

アセットIDを通じて、アカウント内の指定されたアセットの残高を取得します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public extern long GetBalance (byte[] asset_id)
```

パラメータ: アセットIDで、これはアセットが登録された時のRegisterTransactionのトランザクションIDです。長さ32のバイト配列です。

戻り値: long型のアカウント内のアセットの残高で、実際の総計に100,000,000を掛けたものに等しいです。

## 例

```c#
public class Contract1: FunctionCode
{
    public static void Main()
    {
        byte[] scriptHash = {36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73};
        Account account = Blockchain.GetAccount(scriptHash);
        // Take NEO shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        long balance = account.GetBalance(asset);
    }
}
```



[戻る](../Account.md)
