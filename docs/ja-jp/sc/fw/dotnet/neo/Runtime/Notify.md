# Runtime.Notify メソッド (params object[])

Runtime.Logと同様に、スマートコントラクトを実行しているクライアントに通知します。このメソッドは、クライアント上でイベントを発生させることができますが、クライアントには互換性が必要です。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern void Notify(params object[] state)
```
パラメータ:

state: 通知メッセージは、任意の長さおよび任意の型になり得ます。

## 例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        Runtime.Notify("Hello", "World", Blockchain.GetHeight());
    }
}
```




[戻る](../Runtime.md)
