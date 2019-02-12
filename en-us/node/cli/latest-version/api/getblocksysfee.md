# getblocksysfee Method

Returns the system fees of the block, based on the specified index.

## Parameter Description

index：Block index

## Example

Request body：

```json
{
  "jsonrpc": "2.0",
  "method": "getblocksysfee",
  "params": [1005434],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "195500"
}
```

Response description：

result：The system fees of the block, in NeoGas units.