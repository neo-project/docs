# Blockchain.GetHeader Method (uint)

Returns a block header given a block height.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Header GetHeader(uint height)
```

Parameters: Block Height as an unsigned integer.

Return Value: [Header](../Header.md).

## Example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Header bl = Blockchain.GetHeader(997027);
     }
}
```



[Back](../Blockchain.md)
