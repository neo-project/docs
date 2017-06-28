# Getrawmempool method

Obtain an unrecognized transaction list in memory.

## Call the example

Request text:

```json
{
   "Jsonrpc": "2.0",
   "Method": "getrawmempool",
   "Params":[],
   "Id": 1
}
```

Response text:

```json
{
   "Jsonrpc": "2.0",
   "Id": 1,
   "Result": [
     "B4534f6d4c17cda008a76a1968b7fa6256cd90ca448739eae8e828698ccc44e7"
   ]
}
```

These are the undetermined transactions received by the node, ie zero-confirmed transactions.