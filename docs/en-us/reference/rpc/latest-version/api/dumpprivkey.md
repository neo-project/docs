# dumpprivkey Method

Exports the private key of the specified address.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Install the plugin [RpcServer](https://github.com/neo-project/neo-plugins/releases) 
> 2. Call the RPC method `openwallet` to open the wallet first.

### Parameter Description

address: To export the addresses of the private key. The address is required as a standard address.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "dumpprivkey",
  "params": ["NepVckSSgHJf1szQ6LEibd5NU7Ap67yJrJ"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "L5LEfSAAbVAk5vxmkBpWQqJ2e1hyh3nEqgWaosB35XpBAkZdizj4"
}
```

Response Description:

Returns the private key of the standard address.