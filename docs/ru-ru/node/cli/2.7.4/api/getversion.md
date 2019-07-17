# getversion Method

Returns the version information about the queried node.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getversion",
  "params": [],
  "id": 3
}
```

Response body:

```json
{
  "jsonrpc": "2.0",
  "id": 3,
  "result": {
      "port": 0,
      "nonce": 156443862,
      "useragent": "/NEO:2.3.5/"
  }
}
```