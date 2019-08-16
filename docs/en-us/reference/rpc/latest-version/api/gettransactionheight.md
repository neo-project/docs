# gettransactionheight method

Returns the block index in which the transaction is found.

## Parameter Description

txid：Transaction id.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "gettransactionheight",
  "params": ["9c909e1e3ba03290553a68d862e002c7a21ba302e043fc492fe069bf6a134d29"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": 10000
}
```

