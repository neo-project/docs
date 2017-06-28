# Blockchain.GetHeight method ()

Gets the current block height of the blockchain. Block height = block index = number of blocks - 1.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public static extern uint GetHeight ()
```

Return Value: Block height, unsigned integer.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Uint height = Blockchain.GetHeight ();
     }
}
```



[Return to superior](../Blockchain.md)
