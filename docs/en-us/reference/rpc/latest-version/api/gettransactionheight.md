# gettransactionheight method

Returns the transaction height with the specified transaction hash.

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
  "params": ["0x57280b29c2f9051af6e28a8662b160c216d57c498ee529e0cf271833f90e1a53"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": 14
}

```
