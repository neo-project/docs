# Block.GetTransactions Methode ()

Gibt alle Transaktionen im aktuellen Block zurück.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern Neo.SmartContract.Framework.Services.Neo.Transaction[] GetTransactions()
```

Rückgabewert: Transaktion Array als ein Transaction[].

## Beispiel

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



[Back](../Block.md)
