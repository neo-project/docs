# gettransactionheight method

Returns the block index in which the transaction is found.

## Parameter Description

Txid: Transaction ID

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "gettransactionheight",
  "params": ["9ae1fd32d525eff2a1bb1fc8d0cd2cfb4cc97a06a232bb87fc58e4fe3bc2a845"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": 251488
}
```

