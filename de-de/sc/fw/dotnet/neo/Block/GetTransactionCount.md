# Block.GetTransactionCount Methode ()

Gibt die Nummer der Transaktionen im aktuellen Block zurück.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern int GetTransactionCount()
```

Rückgabewert: Nummer der Transaktionen als Integer.

## Beispiel

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



[Back](../Block.md)
