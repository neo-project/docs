# getnep17transfers Method

Returns all the NEP17 transaction information occurred in the specified address.

> [!Note]
>
> You must install the plugin [TokensTracker](https://github.com/neo-project/neo-modules/releases), [LevelDBStore](https://github.com/neo-project/neo-modules/releases), and [RpcSever](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

- address: The address to query the transaction information.

- startTime | endTime: Optional. The UTC timestamp which records the asset start or end  time (included).
  - If start and end timestamps are specified, transactions occurred in the time range are returned.
  - If only one timestamp is specified, transactions occurred since that time are returned.
  - If not specified, transactions in recent seven days are returned.

## Configuration

Before invoking the method, you need to modify the following fields in the TokensTracker config.json file:

- MaxResults: The maximum number of records. The exceeding portion will not be stored.
- Network: Set it to the same value as Network in Neo-CLI config.json.

## Example

##### Example 1 - Set the start time:

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getnep17transfers",
  "params": ["NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ", 0],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "sent": [],
        "received": [
            {
                "timestamp": 1612690497725,
                "assethash": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "transferaddress": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
                "amount": "100",
                "blockindex": 2,
                "transfernotifyindex": 1,
                "txhash": "0x5f957960a782514d6587c445288ee1cca7d6b0f952edc204f14d9be83b8152ff"
            },
            {
                "timestamp": 1612690513541,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
                "amount": "10000000000",
                "blockindex": 3,
                "transfernotifyindex": 0,
                "txhash": "0xe42108b343626035cb51fbcb54949bb38aac50c8ba278841d304e9fdce0807ac"
            }
        ],
        "address": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ"
    }
}
```

##### Example 2 - Set both timestamps:

Request body:

```json
{
    "jsonrpc": "2.0",
    "method": "getnep17transfers",
    "params": ["NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ", 1611716619654, 2011716619654],
    "id": 1
}
```

Response body: 

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "sent": [],
        "received": [
            {
                "timestamp": 1612690497725,
                "assethash": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "transferaddress": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
                "amount": "100",
                "blockindex": 2,
                "transfernotifyindex": 1,
                "txhash": "0x5f957960a782514d6587c445288ee1cca7d6b0f952edc204f14d9be83b8152ff"
            },
            {
                "timestamp": 1612690513541,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
                "amount": "10000000000",
                "blockindex": 3,
                "transfernotifyindex": 0,
                "txhash": "0xe42108b343626035cb51fbcb54949bb38aac50c8ba278841d304e9fdce0807ac"
            }
        ],
        "address": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ"
    }
}
```