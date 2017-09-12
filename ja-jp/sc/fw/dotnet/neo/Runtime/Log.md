# Runtime.Log メソッド (string)

スマートコントラクトを実行するクライアントに、ログメッセージを送信します。このメソッドは、クライアント上でイベントを発生させることができますが、クライアントには互換性が必要です。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern void Log(string message)
```

パラメータ:

message: string型のログ。

## 例

```c#
public class Contract1 : FunctionCode
{
    public static void Main(bool debug)
    {
        if(debug)
        {
            Runtime.Log("Execution successful");
        }
    }
}
```



[戻る](../Runtime.md)
