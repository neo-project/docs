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
> The NEO standard address begins with N because AddressVersion in Neo N3 has been modified to 53.

## Example

**Example 1**

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

**Example 2**

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

**Example 3**

Request body:

```
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": ["0x9127ea19791e3f3fc59309778a4abf275d5290e5"],
  "id": 1
}
```

Response body:

```
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "address": "0x9127ea19791e3f3fc59309778a4abf275d5290e5",
    "isvalid": false
  }
}
```