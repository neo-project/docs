# getunclaimedgas method

Returns the unclaimed GAS with the specified address.

> [!Note]
>
> Before you can invoke this method you must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases).

## Parameter Description

address: Specified address.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getunclaimedgas",
  "params": ["NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "unclaimed": "499999500",
        "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
    }
}
```