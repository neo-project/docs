# listplugins Method

Returns a list of plugins loaded by the node.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

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
            "name": "ApplicationLogs",
            "version": "3.0.0.0",
            "interfaces": [
                "IPersistencePlugin"
            ]
        },
        {
            "name": "LevelDBStore",
            "version": "3.0.0.0",
            "interfaces": [
                "IStoragePlugin"
            ]
        },
        {
            "name": "RpcNep5Tracker",
            "version": "3.0.0.0",
            "interfaces": [
                "IPersistencePlugin"
            ]
        },
        {
            "name": "RpcServer",
            "version": "3.0.0.0",
            "interfaces": []
        },
        {
            "name": "StatesDumper",
            "version": "3.0.0.0",
            "interfaces": [
                "IPersistencePlugin"
            ]
        },
        {
            "name": "SystemLog",
            "version": "3.0.0.0",
            "interfaces": [
                "ILogPlugin"
            ]
        }
    ]
}
```