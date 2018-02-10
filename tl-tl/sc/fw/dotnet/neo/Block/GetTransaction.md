# Block.GetTransaction Method (int)

Returns the transaction specified in the current block by index.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern Neo.SmartContract.Framework.Services.Neo.Transaction GetTransaction(int index)
```

Parameters: the index of the transaction in the block as an integer.

Return Value: Transaction as a [Transaction](../Transaction.md) Type.

## Example

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Block block = Blockchain.GetBlock(997027);
         Transaction tx = block.GetTransaction(0);
     }
}
```



[Back](../Block.md)
