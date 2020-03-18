# Blockchain.GetBlock Method (byte[])

Returns a block from the blockchain given a block hash.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Block GetBlock(byte[] hash)
```

Parameters: Block hash as a byte array of length 32. It should be little endian.

Return Value: [Block](../Block.md).

## Example

```c#
public class Contract1: SmartContract.Framework.SmartContract
{
     public static void Main()
     {
         byte[] block = new byte[] {206, 240, 165, 25, 76, 228, 58, 100, 117, 184, 213, 171, 61, 96, 34, 234, 129, 116, 60, 71, 11, 231, 143, 195, 123, 5, 190, 250, 182, 14, 152};
         Block bl = Blockchain.GetBlock(block);
     }
}
```



[Back](../Blockchain.md)
