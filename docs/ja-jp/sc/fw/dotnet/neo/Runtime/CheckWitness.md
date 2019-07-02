# Runtime.CheckWitness メソッド (byte[])

呼び出し元のコントラクトのトランザクション/ブロックが、必要なスクリプトハッシュを検証したことを確認します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern bool CheckWitness(byte[] hashOrPubkey)
```
パラメータ:

hashOrPubkey: 長さが20のバイト配列の、スクリプトハッシュ。または、長さが33のバイト配列の、パブリックキー。

戻り値: boolean型の、検証が完了したかどうか。

## 例


```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[] pubKey = { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202 };
        bool result = Runtime.CheckWitness(pubKey);
        //byte[] scriptHash = { 36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73 };
        //bool result = Runtime.CheckWitness(scriptHash);
    }
}
```



[戻る](../Runtime.md)
