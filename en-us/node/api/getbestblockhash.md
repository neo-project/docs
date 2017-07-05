# Getbestblockhash method

Gets the hash of the tallest segment in the main chain.

## Call the example

Request text:

```json
{
   "jsonrpc": "2.0",
   "method": "getbestblockhash",
   "params":[],
   "id": 1
}
```

Response text:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": "773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e"
}
```

Response Description:

Result: the hash of the most significant block in the main chain.