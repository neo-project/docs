# Validator.Register メソッド (byte[])

ブックキーパーとして登録する。 これは登録のみであり、ブックキーパーとして選出されるには投票が必要です。

このメソッドはバージョン2.0のRegisterTransactionを置き換えます。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Validator Register(byte[] pubkey)
```

パラメータ:

pubkey: パブリックキーを表す長さ33のバイト配列。

戻り値: [Validator](../Validator.md)

## 例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[] pubKey = new byte[] { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202 };
        var result = Validator.Register(pubKey);
    }
}
```



[戻る](../Validator.md)
