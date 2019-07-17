# Block.GetTransactionCount Method ()

Returns the number of transactions in the current block.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern int GetTransactionCount()
```

Return value: Number of transactions as an integer.

## Example

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
