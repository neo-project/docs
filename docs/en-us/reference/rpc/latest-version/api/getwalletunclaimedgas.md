# getwalletunclaimedgas Method

Gets the amount of unclaimed GAS in the wallet.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) 
> 2. Call the RPC method `openwallet` to open the wallet first.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getwalletunclaimedgas",
  "params": ["NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "750000000"
}
```

Response description:

Returns the unclaimed GAS amount.