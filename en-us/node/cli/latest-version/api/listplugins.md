# listplugins method

Returns a list of plugins loaded by the node.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "listplugins",
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
            "name": "SimplePolicyPlugin",
            "version": "2.10.1.0",
            "interfaces": [
                "ILogPlugin",
                "IPolicyPlugin"
            ]
        }
    ]
}
```