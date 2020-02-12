# getstorage Method

Returns the stored value according to the contract script hash and the stored key.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

### Parameter Description

* script_hash: Contract script hash

* key: The key to look up in storage (in hex string)

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getstorage",
  "params": ["03febccf81ac85e3d795bc5cbd4e84e907812aa3", "5065746572"],
  "id": 15
}
```

Response body:

```json
{
  "jsonrpc": "2.0",
  "id": 15,
  "result": "4c696e"
}
```
