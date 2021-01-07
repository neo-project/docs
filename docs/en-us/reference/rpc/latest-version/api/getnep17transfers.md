# getnep17transfers Method

Returns all the NEP17 transaction information occurred in the specified address.

> [!Note]
>
> You must install the plugin [RpcNep17Tracker](https://github.com/neo-project/neo-plugins/releases) and [LevelDBStore](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

address：The address to query the transaction information.

timestamp (Optional): 

- If start and end timestamps are specified, transactions occurred in the time range are returned.
- If only one timestamp is specified, transactions occurred since that time are returned.
- If not specified, transactions in recent seven days are returned.

## Example

##### Example 1 - no timestamp is specified:

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getnep17transfers",
  "params": ["NNSri1QcdtidykMxryz1xpmzSFwEXeYohH"],
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
                "timestamp": 1579170709527,
                "assethash": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "transferaddress": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
                "amount": "100",
                "blockindex": 54496,
                "transfernotifyindex": 0,
                "txhash": "0x49f40ea86de140849fc5eb1c1ab8dbbe4d1186c47807963a162338d979e79c0f"
            },
            {
                "timestamp": 1579170725318,
                "assethash": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "transferaddress": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
                "amount": "10000000000",
                "blockindex": 54499,
                "transfernotifyindex": 0,
                "txhash": "0x1c25607fda68a2ab5793fb83b5bc87f781afb310127b440620b4ad176d77fa3d"
            }
        ],
        "address": "NNSri1QcdtidykMxryz1xpmzSFwEXeYohH"
    }
}
```

##### Example 2 - start and end timestamps are specified:

Request body:

```json
{
    "jsonrpc": "2.0",
    "method": "getnep17transfers",
    "params": ["NNSri1QcdtidykMxryz1xpmzSFwEXeYohH", 1579170709528, 1579170725319],
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
                "timestamp": 1579170725318,
                "assethash": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "transferaddress": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
                "amount": "10000000000",
                "blockindex": 54499,
                "transfernotifyindex": 0,
                "txhash": "0x1c25607fda68a2ab5793fb83b5bc87f781afb310127b440620b4ad176d77fa3d"
            }
        ],
        "address": "NNSri1QcdtidykMxryz1xpmzSFwEXeYohH"
    }
}
```