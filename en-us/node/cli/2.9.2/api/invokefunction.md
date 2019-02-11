# invokefunction Method

Returns the result after calling a smart contract at scripthash with the given operation and parameters.

> [!Note]
>
> This method is to test your VM script as if they were ran on the blockchain at that point in time. This RPC call does not affect the blockchain in any way.

## Parameter Description

scripthash: Smart contract scripthash

operation: The operation name (string)

params: The parameters to be passed into the smart contract operation

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "af7c7328eee5a275a3bcaee2bf0cf662b5e739be",
    "balanceOf",
    [
      {
        "type": "Hash160",
        "value": "91b83e96f2a7c4fdf0c1688441ec61986c7cae26"
      }
    ]
  ],
  "id": 3
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "1426ae7c6c9861ec418468c1f0fdc4a7f2963eb89151c10962616c616e63654f6667be39e7b562f60cbfe2aebca375a2e5ee28737caf",
        "state": "HALT, BREAK",
        "gas_consumed": "0.311",
        "stack": [
            {
                "type": "ByteArray",
                "value": "262bec084432"
            }
        ],
        "tx": "d101361426ae7c6c9861ec418468c1f0fdc4a7f2963eb89151c10962616c616e63654f6667be39e7b562f60cbfe2aebca375a2e5ee28737caf000000000000000000000000"
    }
}
```

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "af7c7328eee5a275a3bcaee2bf0cf662b5e739be",
    "decimals"
  ],
  "id": 3
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "00c108646563696d616c7367be39e7b562f60cbfe2aebca375a2e5ee28737caf",
        "state": "HALT, BREAK",
        "gas_consumed": "0.174",
        "stack": [
            {
                "type": "Integer",
                "value": "8"
            }
        ],
        "tx": "d1012000c108646563696d616c7367be39e7b562f60cbfe2aebca375a2e5ee28737caf000000000000000000000000"
    }
}
```