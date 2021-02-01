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
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "tcpport": 10333,
        "wsport": 10334,
        "nonce": 639577408,
        "useragent": "/Neo:3.0.0-CI01171/",
        "magic": 5195086
    }
}
```
