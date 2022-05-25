# getstateroot Method

Queries the state root by the block height.

> [!Note]
>
> You must install the plugin [StateService](https://github.com/neo-project/neo-modules/releases) and [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

- index: Block index

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getstateroot",
  "params": [160],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "version": 0,
        "index": 160,
        "roothash": "0x3d3f099e05cf92c018703ab309d8643c30a0ab6b2b008cc6fe80869b1a350c31",
        "witnesses": []
    }
}
```