# Method (string) Runtime.Log 

Invia un messaggio log al client che sta eseguendo lo smart contract. Questo metodo può attivare un evento sul client ma richiede che il client sia compatibile.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi:

```c#
public static extern void Log(string message)
```

Parametri: 

message: Log come una stringa.

## Esempio

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



[Indietro](../Runtime.md)
