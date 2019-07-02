# Metodo (params object[]) Runtime.Notify 

Similarmente a Runtime.Log, questo notifica al client l'esecuzione dello smart contract. Questo metodo può attivare un evento sul client ma richiede che il client sia compatibile.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public static extern void Notify(params object[] state)
```

Parametri: 

state: Il messaggio di notifica, può essere di qualsiasi lunghezza e di qualsiasi tipo.

## Esempio

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        Runtime.Notify("Hello", "World", Blockchain.GetHeight());
    }
}
```



[Indietro](../Runtime.md)
