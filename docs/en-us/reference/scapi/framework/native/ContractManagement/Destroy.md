# ContractManagement.Destroy Method

Destroies the contract.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void Destroy();
```

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 Owner = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();

    public static void Destroy()
    {
        if (!Runtime.CheckWitness(Owner)) throw new Exception("No authorization.");
        ContractManagement.Destroy();
    }
}
```

Response body:

```json
[{"type":"Any"}]
```

Response description:

- Void type: the contract was destroyed successfully.

- Other: failed.

[back](../ContractManagement.md)