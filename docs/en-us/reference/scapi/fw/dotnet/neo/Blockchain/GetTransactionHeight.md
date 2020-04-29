# Blockchain.GetTransactionHeight Method (byte[])

Returns transaction height of the block from the block hash. Transaction height = Transaction index = Transaction number -1.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern BigInteger GetTransactionHeight(byte[] hash);
```

Parameters: 

- blockHash: Block hash, a 32-byte array

Return Value: Block height, unsigned integer

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        byte[] block = new byte[] { 206, 240, 165, 25, 76, 228, 58, 100, 117, 184, 213, 171, 61, 96, 34, 234, 129, 116, 60, 232, 71, 11, 231, 143, 195, 123, 5, 190, 250, 182, 14, 152 };
        BigInteger height = Blockchain.GetTransactionHeight(block);
    }
}
```



[Back](../Blockchain.md)
