# API Reference

Each node in the Neo-CLI provides an API interface for obtaining blockchain data from a node, making it easy to develop blockchain applications. The interface is provided via [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html), and the underlying protocol uses HTTP/HTTPS for communication. To start a node that provides an RPC service, run the following command:

`dotnet neo-cli.dll /rpc`

To access the RPC server via HTTPS, you need to modify the configuration file config.json before starting the node and set the domain name, certificate, and password:

```json
{
  "ApplicationConfiguration": {
    "DataDirectoryPath": "Chain",
    "NodePort": 10333,
    "WsPort": 10334,
    "UriPrefix": [ "https://*:10331", "http://*:10332" ],
    "SslCert": "YourSslCertFile.xxx",
    "SslCertPassword": "YourPassword"
  }
}                                          
```

After the JSON-RPC server starts, it will monitor the following ports, corresponding to the Main and Test nets:

For P2P and WebSocket information see [Node/Introduction](introduction.md).

|                | （Main Net） | （Test Net） |
| -------------- | ------------ | ------------- |
| JSON-RPC HTTPS | 10331        | 20331         |
| JSON-RPC HTTP  | 10332        | 20332         |

## Command List

| Command                                       | Reference                                      | Explanation                         | Comments       |
| ---------------------------------------- | --------------------------------------- | -------------------------- | -------- |
| [getaccountstate](api/getaccountstate.md)          | \<address>                             | Check account asset information according to account address  |    |
| [getassetstate](api/getassetstate.md)    | \<asset_id>                              | Query asset information according to the specified asset number             |          |
| [getbalance](api/getbalance.md)          | \<asset_id>                             |Returns the balance of the corresponding asset in the wallet according to the specified asset number.   | Need to open the wallet   |
| [getbestblockhash](api/getbestblockhash.md) |                                         | Gets the hash of the tallest block in the main chain           |          |
| [getblock](api/getblock.md)              | \<hash> [verbose=0]                     | Returns the corresponding block information according to the specified hash value         |          |
| [getblock](api/getblock2.md)             | \<index> [verbose=0]                    | Returns the corresponding block information according to the specified index          |          |
| [getblockcount](api/getblockcount.md)    |                                         | Gets the number of blocks in the main chain                 |          |
| [getblockhash](api/getblockhash.md)      | \<index>                                | Returns the hash value of the corresponding block based on the specified index         |          |
| [getblocksysfee](api/getblocksysfee.md)  | \<index>                                 | Returns the system fees before the block according to the specified index      |          |
| [getconnectioncount](api/getconnectioncount.md) |                                         | Gets the current number of connections for the node                 |          |
| [getcontractstate](api/getcontractstate.md) | \<script_hash>                           | Returns information about the contract based on the specified script hash |          |
| [getrawmempool](api/getrawmempool.md)    |                                         | Get a list of unconfirmed transactions in memory            |          |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                     | Returns the corresponding transaction information based on the specified hash value         |          |
| [getstorage](api/getstorage.md)          | \<script_hash>  \<key>                   | Returns the stored value based on the contract script hash and key |          |
| [gettxout](api/gettxout.md)              | \<txid> \<n>                            | Returns the corresponding transaction output (change) information based on the specified hash and index |          |
| [invoke](api/invoke.md)      | \<script_hash> \<params>      | Invokes a smart contract at specified script hash with the given parameters |         |
| [invokefunction](api/invokefunction.md) | \<script_hash>  \<operation>  \<params>   | Invokes a smart contract at specified script hash, passing in an operation and its params |     |
| [invokescript](api/invokescript.md) | \<script>   | Runs a script through the virtual machine and returns the results |      |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                                  | Broadcast a transaction over the network. See the [network protocol](network-protocol.md) documentation.                       |          |
| [sendtoaddress](api/sendtoaddress.md)    | \<asset_id> \<address> \<value> [fee=0] | Transfer to specified address                     | Need to open the wallet   |
| [sendmany](api/sendmany.md)              | \<outputs_array> \[fee=0] \[change_address] | Bulk transfer order                       | Need to open the wallet   |
| [getnewaddress](api/getnewaddress.md)    |                                          | Create a new address                     | Need to open the wallet   |
| [dumpprivkey](api/dumpprivkey.md)        | \<address>                               | Export the private key of the specified address | Need to open the wallet   |
| submitblock                              | \<hex>                                  | Submit new blocks                      | Needs to be a consensus node |
| [validateaddress](api/validateaddress.md) | \<address>                               | Verify that the address is a correct NEO address           |          |
| [getpeers](api/getpeers.md)              |                                          | Get a list of nodes that are currently connected/disconnected by this node          |          |
| [getversion](api/getversion.md)              |                                          | Get version information of this node          |          |

## GET request example

A typical JSON-RPC GET request format is as follows:

The following is an example of how to get the number of blocks in the main chain.

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

The following is an example of how to get the number of blocks in the main chain.

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

You can use the Chrome extension in Postman to facilitate the test (Installation of the Chrome extension requires Internet connection), the following is a test screenshot:

![image](/zh-cn/node/assets/api_2.jpg)

![image](/assets/api_3.jpg)

## Other

[C# JSON-RPC Command List](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)

