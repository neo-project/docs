# importprivkey Method

Imports the private key to the wallet.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Install the plugin [RpcServer](https://github.com/neo-project/neo-plugins/releases) 
> 2. Call the RPC method `openwallet` to open the wallet first.

### Parameter Description

key: The WIF-format private key.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "importprivkey",
  "params": ["KwYRSjqmEhK4nPuUZZz1LEUSxvSzSRCv3SVePoe67hjcdPGLRJY5"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
        "haskey": true,
        "label": null,
        "watchonly": false
    }
}
```

Response description:

Returns the address corresponding to the key.