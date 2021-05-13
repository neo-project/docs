# Ledger.GetTransaction Method

Gets transaction by transaction hash.

Namespace：[Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Transaction GetTransaction(UInt256 hash);
```

Parameter:

- hash: The hash of the queried transaction

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Test(UInt256 hash)
    {
        var tx = Ledger.GetTransaction(hash);
    }
}
```
[Back](../Ledger.md)