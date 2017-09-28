# Contract.Destroy Method ()

Destruction of smart contracts. The smart contract published to the blockchain cannot be destroyed from outside, thus if the contract needs to be destryed, the logic needs to be written during development.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void Destroy()
```

## Example

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         var height = Blockchain.GetHeight();
         var block = Blockchain.GetBlock(height);
         if (block.Timestamp > 1514736000) // Beijing time 2018-1-1
         {
             Neo.SmartContract.Framework.Services.Neo.Contract.Destroy();
         }
     }
}
```



[Back](../Account.md)
