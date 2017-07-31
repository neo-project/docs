# スマートコントラクトパラメータと戻り値

スマートコントラクトのデプロイまたは呼び出しでは、スマートコントラクトのパラメータを指定する必要があります。スマートコントラクトパラメータは、次のように定義されるバイトタイプです。

```c#
     /// <summary>
     /// スマートコントラクトのパラメータタイプを示します。
     /// </ summary>
     public enum ContractParameterType: byte
     {
         /// <summary>
         /// signature
         /// </summary>
         Signature = 0,
         Boolean = 1,
         /// <summary>
         /// Integer
         /// </summary>
         Integer = 2,
         /// <summary>
         /// 160-bit hash value
         /// </summary>
         Hash160 = 3,
         /// <summary>
         /// 256-bit hash value
         /// </summary>
         Hash256 = 4,
         /// <summary>
         /// byte array
         /// </summary>
         ByteArray = 5,
         PublicKey = 6,

         Void = 0xff
     }
```

例えば、以下のスマートコントラクトの場合：

```c#
public class Lock : FunctionCode
{
    public static bool Main(int a, bool b, byte[] pubkey, byte[] signature)
    {
        //more...
    }
}
```

上記のenumを使用すると、intは1、boolは2、公開鍵は6、署名は0として表されます。

PCクライアントからパラメータを入力するときは、各パラメータに2桁の16進文字を使用します。したがって、上記の関数の引数は、02010600、戻り値は、01と記述されます。
