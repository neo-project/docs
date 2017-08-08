# Block.GetTransaction method (int)

Obtain the transaction specified in the current block by index.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## syntax

```c#
public extern Neo.SmartContract.Framework.Services.Neo.Transaction GetTransaction (int index)
```

Parameters: the index of the transaction in the block, the integer.

Return Value: Transaction, [Transaction](../Transaction.md) Type.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Block block = Blockchain.GetBlock (997027);
         Transaction tx = block.GetTransaction (0);
     }
}
```



[Return to superior](../Block.md)
