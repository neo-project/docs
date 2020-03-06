# Blockchain.GetTransactionFromBlock Method (byte[], int)

Returns a transaction from the given block hash and transaction index.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Transaction GetTransactionFromBlock(byte[] blockHash, int txIndex);
```

Parameters: 

- blockHash: Block hash as a byte array of length 32.

- txIndex: The transaction index


Return Value: [Transaction](../Transaction.md).

## Example

```c#
public class Contract1 : System.Blockchain.GetContract
{
    public static void Main()
    {
        byte[] blockHash = new byte[] { 88, 114, 160, 206, 130, 137, 41, 94, 119, 120, 242, 71, 232, 244, 3, 20, 165, 69, 182, 232, 106, 185, 119, 239, 183, 65, 174, 220, 157, 251, 28, 215 };
        int txIndex = 2;
        Transaction tx = Blockchain.GetTransactionFromBlock(blockHash, txIndex);
    }
}
```



[Back](../Blockchain.md)
