# sendrawtransaction Method

Broadcasts transactions over the NEO network.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

hex: A hexadecimal string that has been serialized after the transaction signed in the program.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "sendrawtransaction",
  "params": ["004715897d2bf173f849d1d59123d097c009aa31624d39e73900e1f50500000000466a130000000000f699200000012bf173f849d1d59123d097c009aa31624d39e739015d0300d0ed902e0000000c1425275006800e73cc64286753a3a732422521c8e40c142bf173f849d1d59123d097c009aa31624d39e73913c00c087472616e736665720c143b7d3711c6f0ccf9b1dca903d1bfa1d896f1238c41627d5b523901420c40632d2abc04cce02a7d373a2def1b5d126ce75cdd6f40ef8ab9258960841c4123c48288a6f44bc86d94e83755faee3c17d059b99561a18d923202717796e0b68f290c2103b9c46c6d5c671ef5c21bc7aa7c30468aeb081a2e3895269adf947718d650ce1e0b410a906ad4"],
  "id": 1
}
```

Response body in successful cases:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x13ccdb9f7eda95a24aa5a4841b24fed957fe7f1b944996cbc2e92a4fa4f1fa73"
    }
}
```

Response body in unsuccessful cases:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "error": {
        "code": -500,
        "message": "AlreadyExists"
    }
}
```

Response Description:

When result is false, the current transaction has failed to broadcast and an exception occurs. In this example, a confirmed transaction is broadcast, which fails due to the double cost.

The following error codes can be expected:

| Error codes | Message           | Description                                                  |
| ----------- | ----------------- | ------------------------------------------------------------ |
| 500         | AlreadyExists     | Block or transaction already exists and cannot be sent repeatedly. |
|             | OutOfMemory       | The memory pool is full and no more transactions can be sent. |
|             | UnableToVerify    | The block cannot be validated.                               |
|             | Invalid           | The format or parameter is incorrect                         |
|             | Expired           | The block information is expired                             |
|             | InsufficientFunds | Insufficient funds                                           |
|             | PolicyFail        | The behavior is not allowed (such as blacklist address trading) |

