# ManagementContract.GetContract Method

Gets the contract information.

Namespace: [Neo.SmartContract.Framework.Native](../../Neo.SmartContract.Framework.Native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Contract GetContract(UInt160 hash);
```

Parameters:

- hash: the contract hash

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static UInt160 ScriptHash = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();

    public static object GetContract()
    {
        Contract contract = ManagementContract.GetContract(ScriptHash);
        return contract != null;
    }
}
```

Response body:

```json
[{
    "type":"Boolean",
    "value":true
}]
```

Response description:

- Boolean type: true indicates the contract has been deployed.

- Other: failed.

[Back](../ManagementContract.md)