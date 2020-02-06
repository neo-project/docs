# getconnectioncount Method

Gets the current number of connections for the node.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Example

Request body:

```json
{
   "jsonrpc": "2.0",
   "method": "getconnectioncount",
   "params":[],
   "id": 1
}
```

Response body:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": 10
}
```