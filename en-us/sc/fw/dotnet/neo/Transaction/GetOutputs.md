# Transaction.GetOutputs method ()

Query all transactions for current transactions.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## syntax

```c#
public extern Neo.SmartContract.Framework.Services.Neo.TransactionOutput[] GetOutputs ()
```

Return Value: All transactions for the current transaction, [TransactionOutput](../TransactionOutput.md) array.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[] transaction = new byte[] {88, 114, 160, 206, 130, 137, 41, 94, 119, 120, 242, 71, 232, 244, 3, 20, 165, 69, 182, 106, 185, 119, 239, 183, 65, 174, 220, 157, 251, 28, 215};
         Transaction tx = Blockchain.GetTransaction (transaction);
         TransactionOutput[] = tx.GetOutputs ();
     }
}
```



[Return to superior](../Transaction.md)
