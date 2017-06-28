# Block.GetTransactionCount method ()

Gets the number of transactions in the current block.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public extern int GetTransactionCount ()
```

Return value: number of transactions, integer.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Block block = Blockchain.GetBlock (997027);
         Int txCount = block.GetTransactionCount ();
     }
}
```



[Return to superior](../Block.md)
