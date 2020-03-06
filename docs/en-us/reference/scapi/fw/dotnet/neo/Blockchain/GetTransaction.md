# Blockchain.GetTransaction Method (byte[])

Returns a transaction from the given transaction hash.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Transaction GetTransaction(byte[] hash)
```

Parameters: Transaction ID (Transaction Hash) as a byte array of length 32.

Return Value: [Transaction](../Transaction.md).

## Example

```c#
public class Contract1: SmartContract.Framework.SmartContract
{
     public static void Main()
     {
         byte[] transaction = new byte[] {88, 114, 160, 206, 130, 137, 41, 94, 119, 120, 242, 71, 232, 244, 3, 20, 165, 69, 182, 106, 185, 119, 239, 183, 65, 174, 220, 157, 251, 28, 215};
         Transaction tx = Blockchain.GetTransaction(transaction);
     }
}
```



[Back](../Blockchain.md)
