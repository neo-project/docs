# closewallet Method

Closes the current wallet.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Install the plugin [RpcServer](https://github.com/neo-project/neo-plugins/releases) 
> 2. Call the RPC method `openwallet` to open the wallet first.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "closewallet",
  "params": [],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": true
}
```

Response Description:

true: The wallet is closed successfully.
Others: failure