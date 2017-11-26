# Blockchain.GetHeader Method (uint)

Gibt einen Block Header anhand der Block Height zurück.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Header GetHeader(uint height)
```

Parameter: Block Height als ein Unsigned Integer.

Rückgabewert: [Header](../Header.md).

## Beispiel

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Header bl = Blockchain.GetHeader(997027);
     }
}
```



[Back](../Blockchain.md)
