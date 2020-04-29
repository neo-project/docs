# validateaddress Method

Verifies that the address is a valid NEO address.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

```json
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": [address],
  "id": 1
}
```

## Parameter Description

address: Address.

> [!Note]
>
> The NEO standard address begins with N because AddressVersion in NEO3 has been modified to 53.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": ["NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1"],
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
        "isvalid": true
    }
}
```

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": ["152f1muMCNa7goXYhYAQC61hxEgGacmncB"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "152f1muMCNa7goXYhYAQC61hxEgGacmncB",
        "isvalid": false
    }
}
```


