# getrawmempool Method

Obtains the list of unconfirmed transactions in memory.

## Example

Request body:

```json
{
   "jsonrpc": "2.0",
   "method": "getrawmempool",
   "params":[],
   "id": 1
}
```

Response body:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": [
     "B4534f6d4c17cda008a76a1968b7fa6256cd90ca448739eae8e828698ccc44e7"
   ]
}
```

These are the unconfirmed transactions received by nodes, i.e. transactions with zero confirmations.
