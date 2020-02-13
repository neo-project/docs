# getnep5transfers Method

Returns all the NEP-5 transaction information occurred in the specified address.

> [!Note]
>
> You must install the plugin [RpcNep5Tracker](https://github.com/neo-project/neo-plugins/releases) and [LevelDBStore](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

address：The address to query the transaction information.

timestamp (Optional): 

- If start and end timestamps are specified, transactions occurred in the time range are returned.
- If only one timestamp is specified, transactions occurred since that time are returned.
- If not specified, transactions in recent seven days are returned.

## Example

Example 1 - no timestamp is specified:

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getnep5transfers",
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
                "asset_hash": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "transfer_address": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
                "amount": "100",
                "block_index": 54496,
                "transfer_notify_index": 0,
                "tx_hash": "0x49f40ea86de140849fc5eb1c1ab8dbbe4d1186c47807963a162338d979e79c0f"
            },
            {
                "timestamp": 1579170725318,
                "asset_hash": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "transfer_address": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
                "amount": "10000000000",
                "block_index": 54499,
                "transfer_notify_index": 0,
                "tx_hash": "0x1c25607fda68a2ab5793fb83b5bc87f781afb310127b440620b4ad176d77fa3d"
            }
        ],
        "address": "NNSri1QcdtidykMxryz1xpmzSFwEXeYohH"
    }
}
```

Example 2 - start and end timestamps are specified:

Request body:

```json
{
    "jsonrpc": "2.0",
    "method": "getnep5transfers",
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
                "asset_hash": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "transfer_address": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
                "amount": "10000000000",
                "block_index": 54499,
                "transfer_notify_index": 0,
                "tx_hash": "0x1c25607fda68a2ab5793fb83b5bc87f781afb310127b440620b4ad176d77fa3d"
            }
        ],
        "address": "NNSri1QcdtidykMxryz1xpmzSFwEXeYohH"
    }
}
```