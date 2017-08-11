# Blockchain.GetHeader method (byte[])

The block header is found in the blockchain by block height.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Header GetHeader (uint height)
```

Parameters: Block Hash, 32 bytes of byte array.

Return Value: Block, [Header](../Header.md) Type.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Header bl = Blockchain.GetHeader (997027);
     }
}
```



[Return to superior](../Blockchain.md)
