# getunclaimedgas Method

Gets the amount of unclaimed GAS in the wallet.

> [!Note] 
>
> - Before you can invoke this method you must open the wallet in NEO-CLI.
> - This method is provided by the plugin [RpcWallet](https://github.com/neo-project/neo-plugins/releases). You need to install the plugin before you can invoke the method.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getunclaimedgas",
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
        "available": "0.140771",
        "unavailable": "0.096224"
    }
}
```

Response description:

Returns the unclaimed GAS amount.