# Metodo () Blockchain.GetValidators 

Restituisce la chiave pubblica dei validatori (nodi di consenso).

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public static extern byte[][] GetValidators()
```

Valore restituito: Un array di chiavi pubbliche, ogni elemento è un array di byte di lunghezza 33.

## Esempio

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[][] validators = Blockchain.GetValidators();
     }
}
```



[Indietro](../Blockchain.md)
