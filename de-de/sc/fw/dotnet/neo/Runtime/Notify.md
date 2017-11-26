# Runtime.Notify Methode (params object[])

Ähnlich dem Runtime.log, benachrichtigt das Log den Client der den Smart Contract ausführt. Diese Methode löst ein Event an dem Client der den Smart Contract ausführt aus. Der Client muss kompatibel sein.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void Notify(params object[] state)
```

Parameter: 

State: Die Benachrichtigungsmeldung, kann jede Länge und jeden Typ haben.

## Beispiel

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        Runtime.Notify("Hello", "World", Blockchain.GetHeight());
    }
}
```



[Back](../Runtime.md)
