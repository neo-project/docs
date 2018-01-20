# metodo () Blockchain.GetHeight 

Restituisce l'altezza attuale del blocco della blockchain. Altezza del blocco = indice del blocco = numero di blocchi - 1.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public static extern uint GetHeight()
```

Valore restituito: Altezza del blocco come integer non firmato.

## Example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Uint height = Blockchain.GetHeight();
     }
}
```



[Indietro](../Blockchain.md)
