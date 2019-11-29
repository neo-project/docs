# getwalletheight Method

Obtains the current wallet index height.

> [!Note]
>
> Before you can invoke this method you must：
>
> - Open the wallet in NEO-CLI.
> - Install the plugin [RpcWallet](https://github.com/neo-project/neo-plugins/releases). 

#### Example

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
