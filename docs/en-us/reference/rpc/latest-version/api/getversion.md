# getversion Method

Returns the version information about the queried node.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

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
    "id": "3",
    "result": {
        "tcpPort": 12333,
        "wsPort": 12334,
        "nonce": 1403108496,
        "userAgent": "/Neo:3.0.0-preview1/"
    }
}
```
