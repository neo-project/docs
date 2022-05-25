# getstateheight Method
Queries the stateroot height.

> [!Note]
>
> You must install the plugin  [StateService](https://github.com/neo-project/neo-modules/releases) and [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.


## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getstateheight",
  "params": [],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": "1",
    "result": {
        "localrootindex": 602,
        "validatedrootindex": 602
    }
}
```