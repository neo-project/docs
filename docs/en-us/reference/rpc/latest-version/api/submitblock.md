# submitblock Method

Broadcasts a new block in the NEO network.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

```json
{
  "jsonrpc": "2.0",
  "method": "submitblock",
  "params": [hex],
  "id": 1
}
```

### Parameter Description

hex: A hexadecimal string of a serialized block.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "submitblock",
  "params": ["0000000020101cfb80de52766575a91310fddd7bf4fbd4f904e5574373649092cffffcf154badd3ae13d8aa76e75ebf9a1b2fcff874e85798a940da9e21f9533625b5a135bf545ce74010000180000000b2222301e1d5984be6d5a928e946d269603505801420c40ffe24193611172117b7cb49915afe91ec7bf314c6f855f13f82f84329238e8e1649c1aea471873fb374f548a70bb04d0cb127ddb1d4765f67d3b29a2a10e42822b110c2102470d8f746f040f8b9355be5e6fd1dc280f0c6ba9270420290337b07a37f706bd110b41138defaf010088e65a74589edfbf"],
  "id": 1
}
```

Response body in successful cases:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xbe153a2ef9e9160906f7054ed8f676aa223a826c4ae662ce0fb3f09d38b093c1"
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

When result is false, the block has failed to broadcast and an exception occurs. The following error codes can be expected

| Error codes | Message           | Description                                                  |
| ----------- | ----------------- | ------------------------------------------------------------ |
| 500         | AlreadyExists     | Block or transaction already exists and cannot be sent repeatedly. |
|             | OutOfMemory       | The memory pool is full and no more transactions can be sent. |
|             | UnableToVerify    | The block cannot be validated.                               |
|             | Invalid           | The format or parameter is incorrect                         |
|             | Expired           | The block information is expired                             |
|             | InsufficientFunds | Insufficient funds                                           |
|             | PolicyFail        | The behavior is not allowed (such as blacklist address trading) |