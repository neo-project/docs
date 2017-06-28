# Block.GetTransaction method (int)

Obtain the transaction specified in the current block by index.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public extern AntShares.SmartContract.Framework.Services.AntShares.Transaction GetTransaction (int index)
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
