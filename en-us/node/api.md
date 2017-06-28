# API Reference

Each node in the AntSharesCore-CLI provides an API interface for obtaining block-chain data from a node, making it easy to develop block-chain applications. The interface is provided via [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html) and the underlying protocl uses HTTP/HTTPS for communication. To start a node that provides an RPC service, run the following command:

`dotnet AntSharesDaemon.dll /rpc`

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

P2P and WebSocket information see [Node/Introduction](introduction.md)。

|                | （Main Net） | （Test Net） |
| -------------- | ------------ | ------------- |
| JSON-RPC HTTPS | 10331        | 20331         |
| JSON-RPC HTTP  | 10332        | 20332         |

## Command List

| Command                                       | Reference                                      | Explanation                         | Comments       |
| ---------------------------------------- | --------------------------------------- | -------------------------- | -------- |
| [getbalance](api/getbalance.md)          | \<asset_id>                             |Returns the balance of the corresponding asset in the wallet according to the specified asset number.   | Need to open the wallet   |
| [getbestblockhash](api/getbestblockhash.md) |                                         | Gets the hash of the tallest block in the main chain           |          |
| [getblock](api/getblock.md)              | \<hash> [verbose=0]                     | Returns the corresponding block information according to the specified hash value         |          |
| [getblock](api/getblock2.md)             | \<index> [verbose=0]                    | Returns the corresponding block information according to the specified index          |          |
| [getblockcount](api/getblockcount.md)    |                                         | Gets the number of blocks in the main chain                 |          |
| [getblockhash](api/getblockhash.md)      | \<index>                                | Returns the hash value of the corresponding block based on the specified index         |          |
| [getconnectioncount](api/getconnectioncount.md) |                                         | Gets the current number of connections for the node                 |          |
| [getrawmempool](api/getrawmempool.md)    |                                         | Get a list of unrecognized transactions in memory            |          |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                     | Returns the corresponding transaction information based on the specified hash value         |          |
| [gettxout](api/gettxout.md)              | \<txid> \<n>                            | Returns the corresponding transaction output (change) information based on the specified hash and index |          |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                                  | Broadcast transmission                       |          |
| [sendtoaddress](api/sendtoaddress.md)    | \<asset_id> \<address> \<value> [fee=0] | Transfer to specified address                     | Need to open the wallet   |
| submitblock                              | \<hex>                                  | Submit new blocks                      | Needs to be a consensus node |

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

You can use the Chrome extension in Postman to facilitate the test (Installation of the Chrome extension requires a scientific Internet), the following is a test screenshot:

![image](http://docs.antshares.org/images/2017-05-17_17-06-20.jpg)

![image](http://docs.antshares.org/images/2017-05-17_16-55-58.jpg)

## Other

[C# JSON-RPC Command List](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)

