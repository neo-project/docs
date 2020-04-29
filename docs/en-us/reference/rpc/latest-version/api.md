# API Reference

Each NEO-CLI node provides an API interface for obtaining blockchain data from it, making it easy to develop blockchain applications. The interface is provided via [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html), and the underlying protocol uses HTTP/HTTPS for communication. 

To start a node that provides an RPC service, you need to install the plugin [RpcServer](https://github.com/neo-project/neo-plugins/releases). No need to add an argument when starting Neo-CLI.

## Listening ports

After the JSON-RPC server starts, it will monitor the following ports, corresponding to the Main and Test nets:

For P2P and WebSocket information see [Node Introduction](../../../node/introduction.md).

|                | Main Net | Test Net |
| -------------- | -------- | -------- |
| JSON-RPC HTTPS | 10331    | 20331    |
| JSON-RPC HTTP  | 10332    | 20332    |

## Command Lists

### Blockchain

| Command                                             | Parameter                              | Description                                                  |
| --------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [getbestblockhash](api/getbestblockhash.md) |                                          | Gets the hash of the latest block in the main chain. |
| [getblock](api/getblock.md)              | \<hash \| index> [verbose=0]                  | Returns the block information with the specified hash value or index. |
| [getblockcount](api/getblockcount.md)    |                                          | Gets the block count of the main chain. |
| [getblockhash](api/getblockhash.md)      | \<index>                                 | Returns the block hash with the specified index. |
| [getblockheader](api/getblockheader.md) | \<hash \| index> [verbose=0] | Returns the information of the block header with the specified script hash or index. |
| [getcontractstate](api/getcontractstate.md) | \<script_hash>                           | Returns information of the contract with the specified script hash. |
| [getrawmempool](api/getrawmempool.md)    | [shouldGetUnverified=0]         | Gets a list of unconfirmed transactions in memory. |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                      | Returns the transaction information with the specified hash value. |
| [getstorage](api/getstorage.md)          | \<script_hash>  \<key>                   | Returns the value with the contract script hash and the key. |
| [gettransactionheight](api/gettransactionheight.md) | \<txid> | Returns the block index in which the transaction is found. |
| [getvalidators](api/getvalidators.md) | | Gets the information about the validators. |

### Node

| Command                                             | Parameter                              | Description                                                  |
| --------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [getconnectioncount](api/getconnectioncount.md) |                                          | Gets the current connection count of the node. |
| [getpeers](api/getpeers.md)              |                                          | Gets a list of nodes that are currently connected/disconnected by this node. |
| [getversion](api/getversion.md)          |                                          | Gets the version information of the node. |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex> | Broadcasts a transaction over the network. |
| [submitblock](api/submitblock.md) | \<hex> | Submits a new block to the network.<br/>**Note**：Need to be a validator |

### Smart Contract

| Command                                             | Parameter                              | Description                                                  |
| --------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [invokefunction](api/invokefunction.md) | \<script_hash>  \<operation>  \<params> \<checkWitnessHashes> | Invokes a smart contract with the specified script hash, passing in an operation and its params. |
| [invokescript](api/invokescript.md) | \<script> \<checkWitnessHashes> | Runs a script through the virtual machine and returns the results. |

### Tool

| Command                                             | Parameter                              | Description                                                  |
| --------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [listplugins](api/listplugins.md) | | Returns a list of plugins loaded by the node. |
| [validateaddress](api/validateaddress.md) | \<address>                              | Verifies whether the address is a valid NEO address. |

### Wallet

| Command                                             | Parameter                              | Description                                                  |
| --------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [closewallet](api/closewallet.md) |  | Closes the current wallet. |
| [dumpprivkey](api/dumpprivkey.md) | \<address>                              | Exports the private key of the specified address. |
| [getbalance](api/getbalance.md) | \<asset_id> | Returns the balance of the corresponding asset in the wallet. |
| [getnewaddress](api/getnewaddress.md) |  | Creates a new address. |
| [getunclaimedgas](api/getunclaimedgas.md) |  | Gets the amount of unclaimed GAS in the wallet. |
| [importprivkey](api/importprivkey.md) | \<key> | Imports the private key to the wallet. |
| [listaddress](api/listaddress.md) |  | Lists all the addresses in the current wallet. |
| [openwallet](api/openwallet.md) | \<path> \<password> | Opens the specified wallet. |
| [sendfrom](api/sendfrom.md) | \<asset_id>\<from>\<to>\<value> | Transfers from the specified address to the destination address. |
| [sendmany](api/sendmany.md) | \<outputs_array> | Initiates multiple transfers to designated addresses in a transaction. |
| [sendtoaddress](api/sendtoaddress.md) | \<asset_id>\<address>\<value> | Transfers to the specified address. |

### ApplicationLogs plugin

| Command                                             | Parameter                              | Description                                                  |
| --------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [getapplicationlog](api/getapplicationlog.md) | \<txid> | Returns the contract log based on the specified txid. |

### RpcNep5Tracker plugin

| Command                                             | Parameter                              | Description                                                  |
| --------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [getnep5balances](api/getnep5balances.md) | \<address> | Returns the balance of all NEP-5 assets in the specified address. |
| [getnep5transfers](api/getnep5transfers.md) | \<address>[timestamp] | Returns all the NEP-5 transaction information occurred in the specified address. |

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

> [!Note]
>
> To make sure you get the latest result synchronize your client to the latest block height before you use the API.

## Test tools

You can use the Chrome extension in Postman to facilitate the test (Installation of the Chrome extension requires Internet connection). A test screenshot is shown below:

![image](../../../assets/api_3.jpg)

## See also

[C# JSON-RPC Command List](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)
