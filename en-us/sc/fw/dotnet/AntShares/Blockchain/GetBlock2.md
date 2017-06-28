# Blockchain.GetBlock method (uint)

Find the block by block height.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public static extern AntShares.SmartContract.Framework.Services.AntShares.Block GetBlock (uint height)
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
