# getnewaddress Method

Creates a new address.

> [!Note]
>
> - You need to open the wallet in the NEO-CLI node before you execute this command.
> - This method is provided by the plugin [RpcWallet](https://github.com/neo-project/neo-plugins/releases). You need to install the plugin before you can invoke the method.

## Example

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