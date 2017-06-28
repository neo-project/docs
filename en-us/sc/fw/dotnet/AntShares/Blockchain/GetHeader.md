# Blockchain.GetHeader method (byte[])

Find the block header with a block hash.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public static extern AntShares.SmartContract.Framework.Services.AntShares.Header GetHeader (byte[] hash)
```

Parameters: Block Hash, 32 bytes of byte array.

Return Value: Block header, [Header](../Header.md) type.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         byte[] Header = new byte[] {206, 240, 165, 25, 76, 228, 58, 100, 117, 184, 213, 171, 61, 96, 34, 234, 129, 116, 60, 71, 11, 231, 143, 195, 123, 5, 190, 250, 182, 14, 152};
         Header bl = Blockchain.GetHeader (Header);
     }
}
```



[Return to superior](../Blockchain.md)
