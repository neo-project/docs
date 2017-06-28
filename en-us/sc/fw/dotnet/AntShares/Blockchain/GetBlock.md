# Blockchain.GetBlock method (byte[])

Find the block in the blockchain by block height.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public static extern AntShares.SmartContract.Framework.Services.AntShares.Block GetBlock (byte[] hash)
```

Parameters: Block Hash, 32 bytes of byte array.

Return Value: Block, [Block](../Block.md) Type.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[] block = new byte[] {206, 240, 165, 25, 76, 228, 58, 100, 117, 184, 213, 171, 61, 96, 34, 234, 129, 116, 60, 71, 11, 231, 143, 195, 123, 5, 190, 250, 182, 14, 152};
         Block bl = Blockchain.GetBlock (block);
     }
}
```



[Return to superior](../Blockchain.md)
