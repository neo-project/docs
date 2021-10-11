# API Reference

Each NEO-CLI node provides an API interface for obtaining blockchain data from it, making it easy to develop blockchain applications. The interface is provided via [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html), and the underlying protocol uses HTTP/HTTPS for communication. 

To start a node that provides an RPC service, you must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases). Refer to [Installing plugins](../../../node/cli/config.html#installing-plugins) for instructions. No need to add an argument when starting Neo-CLI.

> [!Note]
>
> If the desired version of file is not found during installation, it is because the corresponding version of RpcServer plug-in has not been released yet. In that case, you can compile the project [neo-modules](https://github.com/neo-project/neo-modules) by yourself:
>
> 1. Create the folder Plugins under the directory where neo-cli.dll locates.
> 2. Put the RpcServer file you has complied in the Plugins folder and then restart Neo-CLI.

## Listening ports

After the JSON-RPC server is started, it will listen to the TCP port. By default it is the port 10332 of the local address (127.0.0.1), which is

```
http://127.0.0.1:10332/
```

You can modify the port in config.json in the RpcServer folder.

## Command Lists

### Blockchain

| Method                                        | Parameter                              | Description                                                  |
| --------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [getbestblockhash](api/getbestblockhash.md) |                                          | Gets the hash of the latest block in the blockchain. |
| [getblock](api/getblock.md)              | \<hash \| index> [verbose=0]                  | Returns the block information with the specified hash value or index. |
| [getblockcount](api/getblockcount.md)    |                                          | Gets the block count of the blockchain. |
| [getblockhash](api/getblockhash.md)      | \<index>                                 | Returns the block hash with the specified index. |
| [getblockheader](api/getblockheader.md) | \<hash \| index> [verbose=0] | Returns the information of the block header with the specified script hash or index. |
| [getcommittee](api/getcommittee.md) | | Gets the public key list of current Neo committee members. |
| [getnativecontracts](api/getnativecontracts.md)         |                              | Gets the list of native contracts.    |
| [getnextblockvalidators](api/getnextblockvalidators.md) |                              | Gets the validators list of the next block. |
| [getcontractstate](api/getcontractstate.md) | \<script_hash>                           | Returns information of the contract with the specified script hash. |
| [getrawmempool](api/getrawmempool.md)    | [shouldGetUnverified=0]         | Gets a list of confirmed transactions in memory. If the value is 1 it gets all the transactions including both confirmed and unconfirmed transactions. |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                      | Returns the transaction information with the specified hash value. |
| [getstorage](api/getstorage.md)          | \<script_hash>  \<key>                   | Returns the value with the contract script hash and the key. |
| [gettransactionheight](api/gettransactionheight.md) | \<txid> | Returns the transaction height with the specified transaction hash. |


### Node

| Method                                       | Parameter                              | Description                                                  |
| --------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [getconnectioncount](api/getconnectioncount.md) |                                          | Gets the current connection count of the node. |
| [getpeers](api/getpeers.md)              |                                          | Gets a list of nodes that are currently connected/disconnected by this node. |
| [getversion](api/getversion.md)          |                                          | Gets the version information of the node. |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex> | Broadcasts a transaction over the network. |
| [submitblock](api/submitblock.md) | \<hex> | Submits a new block to the network.<br/>**Note**: Need to be a validator |

### Smart Contract

| Method                                       | Parameter                              | Description                                                  |
| --------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [getunclaimedgas](api/getunclaimedgas.md) | \<address> | Get unclaimed gas of the specified address. |
| [invokefunction](api/invokefunction.md) | \<script_hash>  \<operation>  \[params] \[sender] \[signers] | Invokes a smart contract with the specified script hash, passing in the method name and its params. |
| [invokescript](api/invokescript.md) | \<script> \[sender] \[signers] | Runs a script through the virtual machine and returns the results. |

### Tool

| Method                                       | Parameter                              | Description                                                  |
| --------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [listplugins](api/listplugins.md) | | Returns a list of plugins loaded by the node. |
| [validateaddress](api/validateaddress.md) | \<address>                              | Verifies whether the address is a valid NEO address. |

### Wallet

| Method                                       | Parameter                              | Description                                                  |
| --------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [calculatenetworkfee](api/calculatenetworkfee.md) | \<tx> | Calculates network fee for the specified transaction. |
| [closewallet](api/closewallet.md) |  | Closes the current wallet. |
| [dumpprivkey](api/dumpprivkey.md) | \<address>                              | Exports the private key of the specified address. |
| [getnewaddress](api/getnewaddress.md) |  | Creates a new address. |
| [getwalletbalance](api/getwalletbalance.md) | \<asset_id> | Returns the balance of the corresponding asset in the wallet. |
| [getwalletunclaimedgas](api/getwalletunclaimedgas.md) |  | Gets the amount of unclaimed GAS in the wallet. |
| [importprivkey](api/importprivkey.md) | \<key> | Imports the private key to the wallet. |
| [invokecontractverify](api/invokecontractverify.md) | \<script_hash>   \[params] \[signers] | Invokes the verification method of contract. |
| [listaddress](api/listaddress.md) |  | Lists all the addresses in the current wallet. |
| [openwallet](api/openwallet.md) | \<path> \<password> | Opens the specified wallet. |
| [sendfrom](api/sendfrom.md) | \<asset_id>\<from>\<to>\<value> | Transfers from the specified address to the destination address. |
| [sendmany](api/sendmany.md) | \<outputs_array> \[signers] | Initiates multiple transfers to multiple addresses in a transaction. |
| [sendtoaddress](api/sendtoaddress.md) | \<asset_id>\<address>\<value> \[signers] | Transfers to the specified address. |

### ApplicationLogs plugin

| Method                                       | Parameter                              | Description                                                  |
| --------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [getapplicationlog](api/getapplicationlog.md) | \<txid> | Returns the contract event information based on the specified txid. |

### RpcNep17Tracker plugin

| Method                                       | Parameter                              | Description                                                  |
| --------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| [getnep17balances](api/getnep17balances.md) | \<address> | Returns the balance of all NEP17 assets in the specified address. |
| [getnep17transfers](api/getnep17transfers.md) | \<address>[timestamp] | Returns all the NEP17 transaction information occurred in the specified address. |

### StateService plugin

| Method                                  | Parameter                      | Description                                                  |
| --------------------------------------- | ------------------------------ | ------------------------------------------------------------ |
| [getstateroot](api/getstateroot.md)     | \<index>                       | Queries the state root by the block height.                  |
| [getproof](api/getproof.md)             | \<roothash>\<scripthash>\<key> | Gets proof by querying root hash, contract hash, and storage key. |
| [verifyproof](api/verifyproof.md)       | \<roothash>\<proof>            | Verifies using the root hash and proof, and gets the value of the storage corresponding to the key. |
| [getstateheight](api/getstateheight.md) |                                | Queries the stateroot height.                                |

> [!Note]
>
> For RPC API, all the return values related to the amount such as fees, NEP-17 asset balance, wallet balance, transfer amount, etc. are unsigned integer, which are automatically converted according to the asset decimal when requested by [RpcClient](https://github.com/neo-project/neo-modules/tree/master/src/RpcClient) (C# light node SDK). If you write the request by yourselves, you need to convert the amount manually. For example, if the return value is 1234560 and the asset decimal is 8, the  actual amount is 0.0123456.

## GET request example

The format of a typical JSON-RPC GET request is as follows:

Here is an example of how to get the number of blocks in the block chain.

Request URL:

```
http://127.0.0.1:10332?jsonrpc=2.0&method=getblockcount&params=[]&id=1
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

Here is an example of how to get the number of blocks in the block chain.

Request URL:

```
http://127.0.0.1:10332
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
