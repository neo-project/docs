# Policy.GetStoragePrice Method

Gets data storage fee per byte.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern uint GetStoragePrice();
```

Return:

- Data storage fee per byte

## Example

```c#
public static void Test()
{
    var price = Policy.GetStoragePrice();
}
```
[Back](../Policy.md)

