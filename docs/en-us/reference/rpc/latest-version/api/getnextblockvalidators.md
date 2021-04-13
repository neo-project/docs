# getnextblockvalidators Method

Gets the validators list of the next block.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getnextblockvalidators",
  "params": [],
  "id": 1
}
```

Response body:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": [
    {
      "publickey": "03aa052fbcb8e5b33a4eefd662536f8684641f04109f1d5e69cdda6f084890286a",
      "votes": "0",
      "active": true
    }
  ]
}
```

`result` returns an array containing multiple validators. Every validator contains information about the public key, the votes, and whether it is a validator or not.

> [!Note]
>
> The default vote of validator is 0 when voting has not started.