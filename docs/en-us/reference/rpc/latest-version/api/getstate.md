# getstate Method

Queries the state by the root hash, contract hash and storage key.

> [!Note]
>
> You must install the plugin  [StateService](https://github.com/neo-project/neo-modules/releases) and [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameters

- roothash: The root hash of state root.

- scripthash: The contract hash.

- key: The storage key value encoded by Base64.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getstate",
  "params": ["0xec31cdb14da4143e2ab471a8b5812d895b88fc1c12d54e112791491feca9b5f4","0xb1fbb6b0096919071769906bb23b2ca2ec51eea7","AQFM8QSIkBuHVYOd2kiRmQXXOI833w=="],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "nMJ4AQ=="
}
```