# traverseiterator Method

Gets the Iterator value from `session` and `Iterator id` returned by [invokefunction](./invokefunction.md) or [invokescript](./invokescript.md) .

> [!Note]
>
> - This method queries Iterator type data and does not affect the blockchain data.
> - You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.
> - Before you can use the method, make sure that the `SessionEnabled` value in `config.json` of the plugin `RpcServer` is `true`, and you have obtained `Iterator id` and `session` by invoking [invokefunction](./invokefunction.md) or [invokescript](./invokescript.md).

## Parameters

- session: Cache  id. It is `session` returned by [invokefunction](./invokefunction.md) or [invokescript](./invokescript.md) .
- iterator id: Iterator data id. It is the `id` of `stack` returned by [invokefunction](./invokefunction.md) or [invokescript](./invokescript.md).
- count: The number of values returned. It cannot exceed the value of the `MaxIteratorResultItems` field in config.json of the `RpcServer` plug-in.

> [!Note]
>
> The validity of the `session` and `iterator id` is set by `SessionExpirationTime` in the `config.json` file of the `RpcServer` plug-in, in seconds.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "traverseiterator",
  "params": [
    "c5b628b6-10d9-4cc5-b850-3cfc0b659fcf",
    "593b02c6-138d-4945-846d-1e5974091daa",
    10
  ]
}


```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": [
        {
            "type": "ByteString",
            "value": "AAUPmAOGDBtFrjhmByyKoaxgy9LvzyEh8qUiEU1gxTE="
        },
        {
            "type": "ByteString",
            "value": "ABX1SHTkVThVWpKlyFr3OO8swQXWfnRuqw99TTvi2UU="
        },
        {
            "type": "ByteString",
            "value": "ACj/5pqjP2Mko/2c0GSUKxkJlIyC3cwUbgETEZ5+5YI="
        },
        {
            "type": "ByteString",
            "value": "AF16dMuw8CAZBr/sgdJnW8XWrDDDxifHsa8myh+zsD0="
        },
        {
            "type": "ByteString",
            "value": "AF9luS6mW+nVUNwwlkKqqRLjgoXaIlk98NuhzLTZ2sI="
        },
        {
            "type": "ByteString",
            "value": "AHg1cOvi+r1ORjQcs9VD5bpBDCFtpzp/G4g0BMfsneo="
        },
        {
            "type": "ByteString",
            "value": "AM9ZDm7y7R4M5AicSk06sRv+AEmRPToxjoiHo5aeCfo="
        },
        {
            "type": "ByteString",
            "value": "AOqjq4sfaUcMBtXWVHKh6HqXZA3bOSiNc1VjIEi1auY="
        },
        {
            "type": "ByteString",
            "value": "AOsx7QOiuKZCB2bFBR1s/SjJnfvdbyVvC5ZvaTCFe2U="
        },
        {
            "type": "ByteString",
            "value": "APHR02jt/M9nkLF9z+5yRnRE8efjVhMvjIjDHAQeGV0="
        }
    ]
}
```

Response Description:

The result is the first `count` of data traversed in the Iterator, and follow-up requests will continue traversing from  `count + 1`. 