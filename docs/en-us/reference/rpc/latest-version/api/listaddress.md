# listaddress Method

Lists all the addresses in the current wallet.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) 
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
            "address": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
            "haskey": true,
            "label": null,
            "watchonly": false
        },
        {
            "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
            "haskey": true,
            "label": null,
            "watchonly": false
        }
    ]
}
```

Response description：

address: The address in the wallet.

haskey: Whether there is a private key for the address.

label: Address label.

watchonly: Indicates whether it is a watch only address.