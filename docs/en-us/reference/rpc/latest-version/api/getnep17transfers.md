# getnep17transfers Method

Returns all the NEP17 transaction information occurred in the specified address.

> [!Note]
>
> You must install the plugin [RpcNep17Tracker](https://github.com/neo-project/neo-plugins/releases) and [LevelDBStore](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

- address: The address to query the transaction information.

- startTime | endTime: Optional. The UTC timestamp which records the asset start or end  time (included).
  - If start and end timestamps are specified, transactions occurred in the time range are returned.
  - If only one timestamp is specified, transactions occurred since that time are returned.
  - If not specified, transactions in recent seven days are returned.

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
        "sent": [
            {
                "timestamp": 1611716619654,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
                "amount": "0.1",
                "blockindex": 40,
                "transfernotifyindex": 0,
                "txhash": "0x917c2dee69250dd0be6268ea8e060d4d553122e13d1530b008b67f9083acc476"
            }
        ],
        "received": [
            {
                "timestamp": 1611715807166,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
                "amount": "100",
                "blockindex": 4,
                "transfernotifyindex": 2,
                "txhash": "0x2e7ffdeaa9f74f1c0a85eb545d412b98d9821e9ebaffc373b116d17767e40c49"
            },
            {
                "timestamp": 1611715807166,
                "assethash": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "transferaddress": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
                "amount": "1",
                "blockindex": 4,
                "transfernotifyindex": 1,
                "txhash": "0x9be136667651d0abd02f6976ff08b317f0c4689e0e95b4d1fb5f1fafefc4bfc1"
            },
            {
                "timestamp": 1611716619654,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
                "amount": "0.1",
                "blockindex": 40,
                "transfernotifyindex": 0,
                "txhash": "0x917c2dee69250dd0be6268ea8e060d4d553122e13d1530b008b67f9083acc476"
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
        "sent": [
            {
                "timestamp": 1611716619654,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
                "amount": "0.1",
                "blockindex": 40,
                "transfernotifyindex": 0,
                "txhash": "0x917c2dee69250dd0be6268ea8e060d4d553122e13d1530b008b67f9083acc476"
            }
        ],
        "received": [
            {
                "timestamp": 1611716619654,
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "transferaddress": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
                "amount": "0.1",
                "blockindex": 40,
                "transfernotifyindex": 0,
                "txhash": "0x917c2dee69250dd0be6268ea8e060d4d553122e13d1530b008b67f9083acc476"
            }
        ],
        "address": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ"
    }
}
```