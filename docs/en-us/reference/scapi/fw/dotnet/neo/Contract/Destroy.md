# Contract.Destroy Method ()

Destruction of smart contracts. The smart contract published to the blockchain cannot be destroyed from outside, thus if the contract needs to be destroyed, the logic needs to be written during development.

When the contract is destroyed, the storage area of the old contract is destroyed as well. If the contract is moved, the contents in the old storage area are copied to the new contract storage area.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void Destroy()
```

## Example

```c#
public class Contract1: SmartContract.Framework.SmartContract
{
     public static void Main()
     {
         var height = Blockchain.GetHeight();
         var block = Blockchain.GetBlock(height);
         if (block.Timestamp > 1514736000) // Beijing time 2018-1-1
         {
             Contract.Destroy();
         }
     }
}
```



[Back](../Account.md)
