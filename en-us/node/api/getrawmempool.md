# Getrawmempool method

Obtain an unrecognized transaction list in memory.

## Call the example

Request text:

```json
{
   "jsonrpc": "2.0",
   "method": "getrawmempool",
   "params":[],
   "id": 1
}
```

Response text:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": [
     "B4534f6d4c17cda008a76a1968b7fa6256cd90ca448739eae8e828698ccc44e7"
   ]
}
```

These are the undetermined transactions received by the node, i.e. zero-confirmed transactions.
