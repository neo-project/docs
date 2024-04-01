# ContractManagement.GetContractById Method

Gets the hashes of all non-native deployed contracts.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
private IIterator GetContractHashes()
```

Return:

Iterator with hashes of all deployed contracts.

## Example

Contract:

```c#
public static Iterator<(int, UInt160)> MyMethod()
{
    return ContractManagement.GetContractHashes();
}
```

Invoke from RPC:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "method": "invokefunction",
    "params": [
        "0xc04ff111aa88cc5239cf36360cb298a9a3eae586",
        "myMethod",
        []
    ]
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "script": "wh8MCG15TWV0aG9kDBSG5eqjqZiyDDY2zzlSzIiqEfFPwEFifVtS",
        "state": "HALT",
        "gasconsumed": "2950200",
        "exception": null,
        "notifications": [],
        "stack": [
            {
                "type": "InteropInterface",
                "interface": "IIterator",
                "id": "0cd0591b-cf5a-4517-a060-779269f3577d"
            }
        ],
        "session": "4829327b-8c1d-439e-becc-1360453839f6"
    }
}
```

Invoke again from RPC to get the specific value of the iterator. For more information, refer to the command [traverseiterator](../../../../rpc/latest-version/api/traverseiterator.md).

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "traverseiterator",
  "params": [
    "4829327b-8c1d-439e-becc-1360453839f6",
    "0cd0591b-cf5a-4517-a060-779269f3577d",
    10
  ]
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": [
        {
            "type": "Struct",
            "value": [
                {
                    "type": "ByteString",
                    "value": "AAAAAQ=="
                },
                {
                    "type": "ByteString",
                    "value": "3LAa/9NnZRzJhBiWv+5iilo1XUI="
                }
            ]
        },
        {
            "type": "Struct",
            "value": [
                {
                    "type": "ByteString",
                    "value": "AAAAAg=="
                },
                {
                    "type": "ByteString",
                    "value": "gwlF8xm/6snmJCfRzDiaIiu40pI="
                }
            ]
        },
        {
            "type": "Struct",
            "value": [
                {
                    "type": "ByteString",
                    "value": "AAAAAw=="
                },
                {
                    "type": "ByteString",
                    "value": "oDlHkjZPmX2hcY9E7b0Wdwwoxa8="
                }
            ]
        },
        {
            "type": "Struct",
            "value": [
                {
                    "type": "ByteString",
                    "value": "AAAABA=="
                },
                {
                    "type": "ByteString",
                    "value": "huXqo6mYsgw2Ns85UsyIqhHxT8A="
                }
            ]
        }
    ]
}
```

Response description:

Each element of the returned array is a contract message containing the contract ID and Hash.

Base64 string `AAAABA==` to hexadecimal string is `00000004`.

Base64 script hash `huXqo6mYsgw2Ns85UsyIqhHxT8A=` to script hash (little-endian) is `86e5eaa3a998b20c3636cf3952cc88aa11f14fc0`.

[Back](../ContractManagement.md)