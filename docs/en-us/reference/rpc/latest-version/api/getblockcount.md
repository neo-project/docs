# getblockcount Method

Gets the block count of the main chain.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Example

Request body:

```json
{
   "jsonrpc": "2.0",
   "method": "getblockcount",
   "params":[],
   "id": 1
}
```

Response body:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": 991991
}
```
