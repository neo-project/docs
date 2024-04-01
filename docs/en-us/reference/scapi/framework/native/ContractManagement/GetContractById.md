# ContractManagement.GetContractById Method

Maps the specified ID to the deployed contract.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public ContractState GetContractById(int id);
```

Parameters:

- id: Contract ID. Negative numbers represent native contracts, while positive numbers represent normal contracts (non-native deployed contracts).

## Example

Contract:

```c#
public class Contract1 : SmartContract
{
    public static string MyMethod(int id)
    {
        var contract = ContractManagement.GetContractById(id);
        return contract.Manifest.Name;
    }
}
```

Invoke from neo-cli:

```
invoke 0x425d355a8a62eebf961884c91c6567d3ff1ab0dc myMethod [{"type":"Integer","value":"-1"}]
```

Invoke from RPC:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "method": "invokefunction",
    "params": [
        "0x425d355a8a62eebf961884c91c6567d3ff1ab0dc",
        "myMethod",
        [
            {
                "type": "Integer",
                "value": "-1"
            }
        ]
    ]
}
```

Response body:

```json
[
    {
        "type":"ByteString",
        "value":"Q29udHJhY3RNYW5hZ2VtZW50"
    }
]
```

Response description:

According to the contract code, the contract name associated with the requested ID is returned here.

The string `Q29udHJhY3RNYW5hZ2VtZW50`, when decoded with base64, yields `ContractManagement`.

[Back](../ContractManagement.md)

