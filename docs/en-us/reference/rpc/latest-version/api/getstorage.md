# getstorage Method

Returns the stored value according to the contract script hash and the stored key.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

### Parameter Description

* script_hash: Contract script hash or contract ID

* key: The key to look up in storage (in hex string)

## Example

Request body:

```json
{
    "jsonrpc": "2.0",
    "method": "getstorage",
    "params": ["0x99042d380f2b754175717bb932a911bc0bb0ad7d", "48656c6c6f"],
    "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "776f726c64"
}
```
