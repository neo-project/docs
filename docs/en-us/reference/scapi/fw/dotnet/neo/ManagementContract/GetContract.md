# GetContract Method (UInt160)

Gets the contract information.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

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
    private static byte[] ScriptHash = "0xf32bcab10aeadcd0bb60b9b4ddd7ff9fb9b9a5a0".HexToBytes(reverse: true);

    public static object GetContract()
    {
        Contract contract = ManagementContract.GetContract((UInt160)ScriptHash);
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