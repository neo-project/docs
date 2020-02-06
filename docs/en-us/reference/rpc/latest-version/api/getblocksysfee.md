# getblocksysfee Method

Returns the system fees up to the block based on the specified index.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

```json
{
  "jsonrpc": "2.0",
  "method": "getblocksysfee",
  "params": [index],
  "id": 1
}
```

### Parameter Description

index: Block index

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getblocksysfee",
  "params": [70000],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "33200000000"
}
```

Response description:

result: The system fees up to the block in NeoGas units.