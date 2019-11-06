# getversion Method

Return the version information about the queried node.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getversion",
  "params": [],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": "1",
    "result": {
        "tcpPort": 12333,
        "wsPort": 12334,
        "nonce": 245971508,
        "useragent": "/Neo:3.0.0-preview1/"
    }
}
```
