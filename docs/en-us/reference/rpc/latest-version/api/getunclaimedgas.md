# getunclaimedgas Method

Gets the amount of unclaimed GAS in the wallet.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Open a wallet using the method openwallet
> 2. Install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases). 

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getunclaimedgas",
  "params": ["NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "897299680935"
}
```

Response description:

Returns the unclaimed GAS amount.