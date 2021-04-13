# getpeers Method

Gets a list of nodes that the node is currently connected/disconnected from.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getpeers",
  "params": [],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "unconnected": [],
        "bad": [],
        "connected": [
            {
                "address": "47.90.28.99",
                "port": 21333
            },
            {
                "address": "47.90.28.99",
                "port": 22333
            }
        ]
    }
}
```

Response Description:

- Unconnected: Nodes that are not currently connected.

- Bad: Nodes that are no longer connected.

- Connected: Nodes to which you are currently connected.
