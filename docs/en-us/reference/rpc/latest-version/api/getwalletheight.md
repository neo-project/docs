# getwalletheight Method

Obtains the current wallet index height.

> [!Note]
>
> This method is provided by the plugin [RpcWallet](https://github.com/neo-project/neo-plugins/releases). You need to install the plugin before you can invoke the method.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getwalletheight",
  "params": [],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": 2713183
}
```
