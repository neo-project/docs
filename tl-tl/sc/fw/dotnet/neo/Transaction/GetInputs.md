# Transaction.GetInputs Method ()

Returns all transaction inputs for the transaction.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern Neo.SmartContract.Framework.Services.Neo.TransactionInput[] GetInputs()
```

Return Value: All transaction inputs for the current transaction as a [TransactionInput](../TransactionInput.md) array.

## Example

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] transaction = new byte[] {88, 114, 160, 206, 130, 137, 41, 94, 119, 120, 242, 71, 232, 244, 3, 20, 165, 69, 182, 106, 185, 119, 239, 183, 65, 174, 220, 157, 251, 28, 215};
         Transaction tx = Blockchain.GetTransaction(transaction);
         TransactionInput[] inputs = tx.GetInputs();
     }
}

```



[Back](../Transaction.md)
