# listaddress Method

Lists all the addresses in the current wallet.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Install the plugin [RpcServer](https://github.com/neo-project/neo-plugins/releases) 
> 2. Call the RPC method `openwallet` to open the wallet first.

## Example

Request body：

```json
{
  "jsonrpc": "2.0",
  "method": "listaddress",
  "params": [],
  "id": 1
}
```

Response body：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": [
        {
            "address": "NZos4XyLUEUrD7RQBn9J1A1PyeCwQKqwtT",
            "haskey": true,
            "label": null,
            "watchonly": false
        },
        {
            "address": "NdAth5nq7RyG4HEJRsVJxnk9Q6XHoeB3No",
            "haskey": true,
            "label": null,
            "watchonly": false
        }
    ]
}
```

Response description：

address: The address in the wallet.

watchonly: Indicates whether it is a watch only address.