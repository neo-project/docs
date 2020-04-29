# Blockchain.GetBlock Method (uint)

Returns a block from the given block height.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Block GetBlock(uint height)
```

Parameters: Block height (block index) as an unsigned integer.

Return Value: [Block](../Block.md).

## Example

```c#
public class Contract1: SmartContract.Framework.SmartContract
{
     public static void Main()
     {
         Block bl = Blockchain.GetBlock(997027);
     }
}
```



[Back](../Blockchain.md)
