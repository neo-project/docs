# Blockchain.GetHeight Methode ()

Gibt die derzeitige Block Height auf der Blockchain zurück. Block height = block index = number of blocks - 1.
 
Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern uint GetHeight()
```

Rückgabewert: Block Height als ein Unsigned Integer.

## Beispiel

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Uint height = Blockchain.GetHeight();
     }
}
```



[Back](../Blockchain.md)
