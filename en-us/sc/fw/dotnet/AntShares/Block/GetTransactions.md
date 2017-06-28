# Block.GetTransactions method ()

Get all the transactions in the current block.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public extern AntShares.SmartContract.Framework.Services.AntShares.Transaction[] GetTransactions ()
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
