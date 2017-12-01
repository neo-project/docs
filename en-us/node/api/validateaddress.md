# validateaddress Method

Verifies that the address is a correct NEO address.

## Parameter Description

address: Address.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": ["AQVh2pG732YvtNaxEGkQUei3YA4cvo7d2i"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "AQVh2pG732YvtNaxEGkQUei3YA4cvo7d2i",
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



