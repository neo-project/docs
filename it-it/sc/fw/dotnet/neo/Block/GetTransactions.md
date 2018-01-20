# Metodo ()Block.GetTransactions 

Restituisce tutte le transazione nel blocco corrente.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public extern Neo.SmartContract.Framework.Services.Neo.Transaction[] GetTransactions()
```

Valore Restituito: L'array della transazione come Transaction[].

## Esempio

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Block block = Blockchain.GetBlock(997027);
         Transaction[] txs = block.GetTransactions();
     }
}
```



[Indietro](../Block.md)
