# Blockchain.GetTransactionFromBlock Method (uint, int)

Returns a transaction from the given block index and transaction index.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Transaction GetTransactionFromBlock(uint blockIndex, int txIndex)
```

Parameters: 

- blockHash: Block index
- txIndex: Transaction index

Return Value: [Transaction](../Transaction.md).

## Example

```c#
public class Contract1 : System.Blockchain.GetContract
{
    public static void Main()
    {
        uint blockIndex = 241400;
        int txIndex = 2;
        Transaction tx = Blockchain.GetTransactionFromBlock(blockIndex, txIndex);
    }
}
```



[Back](../Blockchain.md)
