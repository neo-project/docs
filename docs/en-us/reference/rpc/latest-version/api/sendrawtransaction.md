# sendrawtransaction Method

Broadcasts a transaction over the NEO network. There are many kinds of transactions, as specified in the network protocol [documentation](../../../../tooldev/advanced/network-protocol.md).

## Parameter Description

Hex: A hexadecimal string that has been serialized, after the signed transaction in the program.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "sendrawtransaction",
  "params": [ "80000001195876cb34364dc38b730077156c6bc3a7fc570044a66fbfeeea56f71327e8ab0000029b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc500c65eaf440000000f9a23e06f74cf86b8827a9108ec2e0f89ad956c9b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc50092e14b5e00000030aab52ad93f6ce17ca07fa88fc191828c58cb71014140915467ecd359684b2dc358024ca750609591aa731a0b309c7fb3cab5cd0836ad3992aa0a24da431f43b68883ea5651d548feb6bd3c8e16376e6e426f91f84c58232103322f35c7819267e721335948d385fae5be66e7ba8c748ac15467dcca0693692dac"],
  "id": 1
}
```

Response body if successful:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": true
}
```

Response body if not successful:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "error": {
        "code": -501,
        "message": "Block or transaction already exists and cannot be sent repeatedly."
    }
}
```

Response Description:

When result is true, the current transaction is successfully broadcasted.

When result is false, the current transaction has failed to broadcast and an exception is raised. 

In this example, a confirmed transaction is re-sent, so it failed. The following error codes can be expected:

Error code | Message |
| --------------- | ---- |
| -501 | Block or transaction already exists and cannot be sent repeatedly. |
| -502 | The memory pool is full and no more transactions can be sent. |
| -503 | The block cannot be validated. |
| -504 | Block or transaction validation failed. |
| -505 | One of the Policy filters failed. |
| -500 | Unknown error.
