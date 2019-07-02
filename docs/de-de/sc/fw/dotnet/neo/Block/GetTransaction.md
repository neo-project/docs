# Block.GetTransaction Methode (int)

Gibt die Transaktion zurück die in dem aktuellen Block im Index definiert wurde. 

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern Neo.SmartContract.Framework.Services.Neo.Transaction GetTransaction(int index)
```

Parameter: Der Index der Transaktion in dem Block als Integer.

Rückgabewert: Transaktion als ein [Transaction](../Transaction.md) Typ.

## Beispiel

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Block block = Blockchain.GetBlock(997027);
         Transaction tx = block.GetTransaction(0);
     }
}
```



[Back](../Block.md)
