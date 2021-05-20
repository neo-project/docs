# Policy.GetFeePerByte Method

Gets the transaction network fee per byte.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern long GetFeePerByte();
```

Return:

- Transaction network fee per byte

## Example

```c#
public static void Test()
{
    var feePerByte = Policy.GetFeePerByte();
}
```
[Back](../Policy.md)

