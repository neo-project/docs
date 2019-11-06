# API Reference

Each NEO-CLI node provides an API interface for obtaining blockchain data from it, making it easy to develop blockchain applications. The interface is provided via [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html), and the underlying protocol uses HTTP/HTTPS for communication. To start a node that provides an RPC service, run the following command:

`dotnet neo-cli.dll /rpc`

## Listening ports

After the JSON-RPC server starts, it will monitor the following ports, corresponding to the Main and Test nets:

For P2P and WebSocket information see [Node Introduction](../../../node/introduction.md).

|                | Main Net | Test Net |
| -------------- | -------- | -------- |
| JSON-RPC HTTPS | 10331    | 20331    |
| JSON-RPC HTTP  | 10332    | 20332    |

## Command List

> [!Note]
>
> **Changes in NEO3**：
>
> Invocation Style: getblockheader，getrawmempool
>
> Returns: getblock，getblockheader，getrawtransaction，getversion，getcontractstate

| Command                                         | Parameter                                   | Description                                                  | Remark                     |
| ----------------------------------------------- | ------------------------------------------- | ------------------------------------------------------------ | ---------------------------- |
| [getbestblockhash](api/getbestblockhash.md)     |                                             | Get the hash of the latest block in the main chain         |                              |
| [getblock](api/getblock.md)                     | \<hash> [verbose=0]                         | Return the block information with the specified hash value |                              |
|                                                 | \<index> [verbose=0]                        | Return the block information with the specified index |                              |
| [getblockcount](api/getblockcount.md)           |                                             | Get the block count of the main chain                  |                              |
| [getblockhash](api/getblockhash.md)             | \<index>                                    | Return the block hash with the specified index |                              |
| [getblockheader](api/getblockheader.md)         | \<hash> [verbose=0]                         | Return the information of the block header with the specified script hash |                              |
|                                                 | \<index> [verbose=0]                         | Return the information of the block header with the specified index |                              |
| [getblocksysfee](api/getblocksysfee.md)         | \<index>                                    | Return the system fees before the block with the specified index |                              |
| [getconnectioncount](api/getconnectioncount.md) |                                             | Get the current connection count of the node          |                              |
| [getcontractstate](api/getcontractstate.md)     | \<script_hash>                              | Return information of the contract with the specified script hash |                              |
| [getpeers](api/getpeers.md)                     |                                             | Get a list of nodes that are currently connected/disconnected by this node |                              |
| [getrawmempool](api/getrawmempool.md)           | [shouldGetUnverified=0]               | Get a list of unconfirmed transactions in memory            |                              |
| [getrawtransaction](api/getrawtransaction.md)   | \<txid> [verbose=0]                         | Return the transaction information with the specified hash value |                              |
| [getstorage](api/getstorage.md)                 | \<script_hash>  \<key>                      | Return the value with the contract script hash and the key |                              |
| [gettransactionheight](api/gettransactionheight.md)| \<txid>                                  | Return the block index in which the transaction is found. ||
| [getvalidators](api/getvalidators.md)           |                                             | Get the information about the validators                        |                              |
| [getversion](api/getversion.md)                 |                                             | Get the version information of the node                        |                              |
| [invokefunction](api/invokefunction.md)         | \<script_hash>  \<operation>  \<params>     | Invoke a smart contract with the specified script hash, passing in an operation and its params |                              |
| [invokescript](api/invokescript.md)             | \<script>                                   | Run a script through the virtual machine and returns the results |                              |
| [listplugins](api/listplugins.md)               |                                             | Return a list of plugins loaded by the node||
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                                      | Broadcast a transaction over the network. |                              |
| [submitblock](api/submitblock.md)               | \<hex>                                      | Submit a new block to the network                             | Need to be a validator |
| [validateaddress](api/validateaddress.md)       | \<address>                                  | Verify whether the address is a valid NEO address             |                              |



### RpcWallet Plugin

| Command                                               | Parameter                                              | Description                                                  | Remark |
| ----------------------------------------------------- | ------------------------------------------------------ | ------------------------------------------------------------ | ------ |
| [dumpprivkey ](api/rpcwallets/dumpprivkey.md)         | \<address>                                             | Exports the private key of the specified address             |        |
| [getbalance](api/rpccwallets/getbalance.md)           | \<asset_id>                                            | Returns the balance of the corresponding asset in the wallet |        |
| [getnewaddress](/api/rpcwallets/getnewaddress.md)     |                                                        | Creates a new address                                        |        |
| [getunclaimedgas](/api/rpcwallets/getunclaimedgas.md) |                                                        | Gets the amount of unclaimed GAS in the wallet               |        |
| [importprivkey](/api/rpcwallets/importprivkey.md)     | \<key>                                                 | Imports the private key to the wallet                        |        |
| [listaddress](/api/rpcwallets/listaddress.md)         |                                                        | Lists all the addresses in the current wallet                |        |
| [sendfrom](/api/rpcwallets/sendfrom.md)               | \<asset_id>\<from>\<to>\<value> | Transfer from the specified address to the destination address |        |
| [sendmany](/api/rpcwallets/sendmany.md)               | \<outputs_array>                | Initiate multiple transfers to designated addresses in a transaction   |        |
| [sendtoaddress](/api/rpcwallets/sendtoaddress.md)     | \<asset_id>\<address>\<value>   | Transfers to the specified address.                          |        |

## GET request example

The format of a typical JSON-RPC GET request is as follows:

Here is an example of how to get the number of blocks in the main chain.

Request URL:

```
http://somewebsite.com:10332?jsonrpc=2.0&method=getblockcount&params=[]&id=1
```

After sending the request, you will get the following response:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909129
}
```

## POST request example

The format of a typical JSON-RPC Post request is as follows:

Here is an example of how to get the number of blocks in the main chain.

Request URL:

```
http://somewebsite.com:10332
```

Request Body：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockcount",
  "params":[],
  "id": 1
}
```

After sending the request, you will get the following response：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909122
}
```

## Test tools

You can use the Chrome extension in Postman to facilitate the test (Installation of the Chrome extension requires Internet connection). A test screenshot is shown below:

![image](../../../assets/api_3.jpg)

## Other

[C# JSON-RPC Command List](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)
