# Contract.Create メソッド (byte[], byte[], byte, bool, string, string, string, string, string)

スマートコントラクト内でこのメソッドを呼び出すと、新たなコントラクトを発行します。

これはバージョン2.0において、PublishTransactionの置き換えです。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Contract CreateContract(byte[] script, byte[] parameter_list, byte return_type, bool need_storage, string name, string version, string author, string email, string description)
```

パラメータ:

script: バイト配列の、コントラクトのバイトコードです。

parameter_list: バイト配列の、パラメータリストです。[Smart Contract Parameters and Return Values](../../../../tutorial/Parameter.md)を参照してください。

return_type: バイト型の、戻り値の型です。[Smart Contract Parameters and Return Values](../../../../tutorial/Parameter.md)を参照してください。

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
    public static void Main()
    {
        //This is the new contract as bytecode
        byte[] script = new byte[] { 116, 107, 0, 97, 116, 0, 147, 108, 118, 107, 148, 121, 116, 81, 147, 108, 118, 107, 148, 121, 147, 116, 0, 148, 140, 108, 118, 107, 148, 114, 117, 98, 3, 0, 116, 0, 148, 140, 108, 118, 107, 148, 121, 97, 116, 140, 108, 118, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 108, 117, 102 }; 
      
        byte[] parameter_list = { 2, 2 };
        byte return_type = 2;
        bool need_storage = false;
        string name = "AdditionContractExample";
        string version = "1";
        string author = "chris";
        string email = "chris@abc.com";
        string description = "This is an Addition Contract. It takes in 2 inputs, adds them and returns the result.";
      
        Blockchain.CreateContract(script, parameter_list, return_type, need_storage, name, version, author, email, description);
    }
}
```



[戻る](../Contract.md)
