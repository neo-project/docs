# getnep5transfers Method

Returns all the NEP-5 transaction information occurred in the specified address.

## Parameter Description

address：The address to query the transaction information.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getnep5transfers",
  "params": ["AbHgdBaWEnHkCiLtDZXjhvhaAK2cwFh5pF"],
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
                "timestamp": 1555651816,
                "asset_hash": "600c4f5200db36177e3e8a09e9f18e2fc7d12a0f",
                "transfer_address": "AYwgBNMepiv5ocGcyNT4mA8zPLTQ8pDBis",
                "amount": "1000000",
                "block_index": 436036,
                "transfer_notify_index": 0,
                "tx_hash": "df7683ece554ecfb85cf41492c5f143215dd43ef9ec61181a28f922da06aba58"
            }
        ],
        "address": "AbHgdBaWEnHkCiLtDZXjhvhaAK2cwFh5pF"
    }
}
```


