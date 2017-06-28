# Getbestblockhash method

Gets the hash of the tallest segment in the main chain.

## Call the example

Request text:

```json
{
   "Jsonrpc": "2.0",
   "Method": "getbestblockhash",
   "Params":[],
   "Id": 1
}
```

Response text:

```json
{
   "Jsonrpc": "2.0",
   "Id": 1,
   "Result": "773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e"
}
```

Response Description:

Result: the hash of the most significant block in the main chain.