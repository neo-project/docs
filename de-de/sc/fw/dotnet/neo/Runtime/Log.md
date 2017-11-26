# Runtime.Log Methode (string)

Sendet ein Log Message zu dem Client der den Smart Contract ausführt. Diese Methode löst ein Event an dem Client der den Smart Contract ausführt aus. Der Client muss kompatibel sein.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void Log(string message)
```

Parameter: 

Message: Log als ein string.

## Beispiel

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



[Back](../Runtime.md)
