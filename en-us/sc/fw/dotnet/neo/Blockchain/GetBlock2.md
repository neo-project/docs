# Blockchain.GetBlock method (uint)

Find the block by block height.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Block GetBlock (uint height)
```

Parameters: Block height (block index), unsigned integer.

Return Value: Block, [Block](../Block.md) Type.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Block bl = Blockchain.GetBlock (997027);
     }
}
```





[Return to superior](../Blockchain.md)
