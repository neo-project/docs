# getversion Method

Returns the version information of the node.

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
        "tcpport": 12333,
        "wsport": 12334,
        "nonce": 1403108496,
        "useragent": "/Neo:3.0.0-preview3/"
    }
}
```
