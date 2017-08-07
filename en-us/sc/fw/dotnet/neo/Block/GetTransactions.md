# Block.GetTransactions method ()

Get all the transactions in the current block.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## syntax

```c#
public extern Neo.SmartContract.Framework.Services.Neo.Transaction[] GetTransactions ()
```

Return Value: Transaction array, Transaction[] type.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Block block = Blockchain.GetBlock (997027);
         Transaction[] txs = block.GetTransactions ();
     }
}
```



[Return to superior](../Block.md)
