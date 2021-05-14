# RoleManagement.GetDesignatedByRole Method

Gets the block where the transaction occurs with transaction hash.

Namespace：[Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Cryptography.ECC.ECPoint[] GetDesignatedByRole(Role role, uint index);
```

Parameter:

- role: The type of the role
- index: The index of the block to be queried

returns: 

- The public keys of the nodes

## Example

```c#
public static void Test()
{
    var nodes = RoleManagement.GetDesignatedByRole(Role.Oracle, 0);
}
```
[Back](../RoleManagement.md)

