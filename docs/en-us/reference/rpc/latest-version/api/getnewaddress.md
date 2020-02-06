# getnewaddress Method

Creates a new address.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Open a wallet using the method openwallet
> 2. Install the plugin [RpcWallet](https://github.com/neo-project/neo-plugins/releases) 

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
    "result": "NeMDdPDC29BfayYF7xNvnCSfCq9Drh1xKX"
}
```

Response Description:

Returns the newly created address.