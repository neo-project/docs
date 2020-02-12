# getbestblockhash Method

Returns the latest block hash of the main chain.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Example

##### Request body

```json
{
   "jsonrpc": "2.0",
   "method": "getbestblockhash",
   "params":[],
   "id": 1
}
```

##### Response body

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": "0xbee7a65279d6b31cc45445a7579d4c4a4e52d1edc13cc7ec7a41f7b1affdf0ab"
}
```

##### Response Description

Result: The latest block hash of the main chain.