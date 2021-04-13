# getstorage Method

Returns the stored value according to the contract script hash and the stored key. Both key and value are Base64-encoded.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

### Parameter Description

* script_hash: Contract script hash or contract ID

* key: The key to look up in storage (Base64-encoded)

## Example

Request body:

`hello` is converted into the Base64 string `aGVsbG8=`.

```json
{
    "jsonrpc": "2.0",
    "method": "getstorage",
    "params": ["0x99042d380f2b754175717bb932a911bc0bb0ad7d", "aGVsbG8="],
    "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "d29ybGQ="
}
```

`d29ybGQ=` is converted into the string `world`.