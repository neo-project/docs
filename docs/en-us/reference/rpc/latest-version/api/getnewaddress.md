# getnewaddress Method

Creates a new address.

> [!Note]
>
> Before you can invoke this method you must：
>
> - Open the wallet in NEO-CLI.
> - Install the plugin [RpcWallet](https://github.com/neo-project/neo-plugins/releases). 

#### Example

Request body：

```json
{
  "jsonrpc": "2.0",
  "method": "getnewaddress",
  "params": [],
  "id": 1
}
```

Response body：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AVHcdW3FGKbPWGHNhkPjgVgi4GGndiCxdo"
}
```

Response Description:

Returns the newly created address.