# Invoke method

Returns the result after calling a smart contract at scripthash with the given parameters.

**Note: This method is to test your VM script as if they were ran on the blockchain at that point in time. This RPC call does not affect the blockchain in any way.**

## Parameter Description

scripthash: Smart contract scripthash

params: The parameters to be passed into the smart contract

## Example

Request text:

```json
{
  "jsonrpc": "2.0",
  "method": "invoke",
  "params": [
"dc675afc61a7c0f7b3d2682bf6e1d8ed865a0e5f",
[
  {
    "type": "String",
    "value": "name"
  },
  {
    "type":"Boolean",
    "value": false
  }
]
  ],
  "id": 1
}
```

Response text:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "2.489",
        "stack": [
            {
                "type": "ByteArray",
                "value": "576f6f6c6f6e67"
            }
        ]
    }
}
```