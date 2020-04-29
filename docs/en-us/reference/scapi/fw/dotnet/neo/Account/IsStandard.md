# Account.IsStandard method (byte[])

Verifies whether the contract is a standard account according to its scripthash (unilateral signature account)

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool IsStandard(byte[] scripthash)
```

Parameters: scripthash, the account scripthash

Return value: Boolean, true or false

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        byte[] scriptHash = { 36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73 };
        Account.IsStandard(scriptHash);
    }
}
```



[Back](../Account.md)