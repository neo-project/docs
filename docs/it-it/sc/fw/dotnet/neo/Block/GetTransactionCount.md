# Metodo () Block.GetTransactionCount 

Restituisce il numero di transazione nel blocco corrente.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public extern int GetTransactionCount()
```

Valore restituito: Numero di transazioni come integer.

## Esempio

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Block block = Blockchain.GetBlock(997027);
         Int txCount = block.GetTransactionCount();
     }
}
```



[Indietro](../Block.md)
