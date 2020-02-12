# gettransactionheight method

Returns the block index in which the transaction is found.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

txid: Transaction id.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "gettransactionheight",
  "params": ["9ae1fd32d525eff2a1bb1fc8d0cd2cfb4cc97a06a232bb87fc58e4fe3bc2a845"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": 251488
}

```
