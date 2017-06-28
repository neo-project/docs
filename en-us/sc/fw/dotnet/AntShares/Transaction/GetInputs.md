# Transaction.GetInputs method ()

Query all transactions for the current transaction.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public extern AntShares.SmartContract.Framework.Services.AntShares.TransactionInput[] GetInputs ()
```

Return Value: All transactions for the current transaction, [TransactionInput](../TransactionInput.md) array.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[] transaction = new byte[] {88, 114, 160, 206, 130, 137, 41, 94, 119, 120, 242, 71, 232, 244, 3, 20, 165, 69, 182, 106, 185, 119, 239, 183, 65, 174, 220, 157, 251, 28, 215};
         Transaction tx = Blockchain.GetTransaction (transaction);
         TransactionInput[] inputs = tx.GetInputs ();
     }
}

```



[Return to superior](../Transaction.md)
