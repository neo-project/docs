# Contract.Migrate メソッド (byte[], byte[], byte, bool, string, string, string, string, string)

スマートコントラクトを移行/更新します。このメソッドはC`Contract.Create`と同様ですが、唯一の違いとして、このメソッドはプライベートの永続化ストアへの、移行のためのロジックを追加しています。このメソッドを実行する際、永続化ストア内の**既存のデータ**をすべて移行します。

コントラクトが永続化ストアを使用しない場合、`Contract.Migrate`は機能的に`Contract.Create`と同様です。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Contract Migrate(byte[] script, byte[] parameter_list, byte return_type, bool need_storage, string name, string version, string author, string email, string description)
```

パラメータ:

script: バイト配列の、コントラクトのバイトコードです。

parameter_list: バイト配列の、パラメータリストです。[Smart Contract Parameters and Return Values](../../../../tutorial/Parameter.md)を参照してください。

return_type: バイト型の、戻り値の方です。 [Smart Contract Parameters and Return Values](../../../../tutorial/Parameter.md)を参照してください。

need_storage: boolean型の、コントラクトが永続化ストアを必要とするかどうかです。

name: string型の、コントラクトの名前です。

version: string型の、バージョンです。

author: string型の、署名者の名前です。

email: string型の、署名者のeメールアドレスです。

description: string型の、コントラクトの説明です。

戻り値: [Contract](../Contract.md)。

## 例

```c#
public class Contract1 : FunctionCode
{
    public static void Main(byte[] signature)
    {
        if(VerifySignature(new byte[] { 2, 133, 234, 182, 95, 74, 1, 38, 228, 184, 91, 78, 93, 139, 126, 48, 58, 255, 126, 251, 54, 13, 89, 95, 46, 49, 137, 187, 144, 72, 122, 213, 170 }, signature))
          {
                    //This is the scripthash of the new contract
        byte[] script = new byte[] { 116, 107, 0, 97, 116, 0, 147, 108, 118, 107, 148, 121, 116, 81, 147, 108, 118, 107, 148, 121, 147, 116, 0, 148, 140, 108, 118, 107, 148, 114, 117, 98, 3, 0, 116, 0, 148, 140, 108, 118, 107, 148, 121, 97, 116, 140, 108, 118, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 108, 117, 102 }; 
      
        byte[] parameter_list = { 2, 2 };
        byte return_type = 2;
        bool need_storage = true;
        string name = "AdditionContractExample";
        string version = "1";
        string author = "chris";
        string email = "chris@neo.org";
        string description = "DescriptionHere";
      
        Contract.Migrate(script, parameter_list, return_type, need_storage, name, version, author, email, description);
          }

    }
}
```



[戻る](../Contract.md)

