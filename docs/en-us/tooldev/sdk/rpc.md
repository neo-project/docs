# RPC Invocation Methods

The Neo RPC SDK encapsulates all the interfaces provided by RpcServer. You can send RPC requests in your code through the standard methods provided in this module. You only need to pass in the corresponding parameters, the SDK will construct the corresponding JSON-RPC requests and then get the data returned by the node.


## Initializing RpcClient
Before you can send RPC requests you need to initialize  `RpcClient` first. Choose the RPC server port of a Neo node according to your own needs. Here is an example:

Test net node：

```c#
// TestNet Node
RpcClient client = new RpcClient("http://seed1t.neo.org:20332");
```

Local node (the local Neo-CLI that can be connected to main net, test net, or private net according to configuration):

```c#
// Local Node
RpcClient client = new RpcClient("http://localhost:10332");
```

> [!Note]
>
> Typically, only one RpcClient instance needs to be initialized in an application, not needing in each method.

## Blockchain data

### GetBestBlockHash
Gets the hash of the highest block in the blockchain:

```c#
string hexString = client.GetBestBlockHash();
byte[] hashBytes = hexString.HexToBytes();
UInt256 hash256 = UInt256.Parse(hexString);
```

### GetBlock
Gets the detailed block information by the block hash or block index.

```c#
Block block = client.GetBlock("773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e").Block;
```

or 

```c#
Block block = client.GetBlock("10000").Block;
```

### GetBlockHex

Gets the serialized block information by the block hash or block index:

```c#
string serializedBlock = client.GetBlockHex("773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e");
```

### GetBlockCount

Gets the current block quantity.

Block index（Index） = Block height（Height） = Block count（Count） - 1

```c#
uint blockCount = client.GetBlockCount();
```

### GetBlockHash

Gets the block hash by the block index.

```c#
string hexString = client.GetBlockHash(10000);
byte[] hashBytes = hexString.HexToBytes();
UInt256 hash256 = UInt256.Parse(hexString);
```

### Get the block header information
Get the specific block header information by the block hash or block index:

```c#
Header header = client.GetBlockHeader("a5508c9b6ed0fc09a531a62bc0b3efcb6b8a9250abaf72ab8e9591294c1f6957").Header;
```

or

```c#
Header header = client.GetBlockHeader("10000").Header;
```

Get the serialized block header information from the block hash or block index:

```c#
string serializedBlockHeader = client.GetBlockHeaderHex("a5508c9b6ed0fc09a531a62bc0b3efcb6b8a9250abaf72ab8e9591294c1f6957");
```

### GetBlockSysFee
Gets the system fee for the block and all the previous blocks through the specific block index.

```c#
BigInteger sysFee = client.GetBlockSysFee(10000);
```

### GetContractState
Gets the contract information from the contract hash or contract ID

```c#
ContractState contractState = client.GetContractState("dc675afc61a7c0f7b3d2682bf6e1d8ed865a0e5f");
```

```c#
ContractState contractState = client.GetContractState(-1);
```

### GetRawMempool
Gets hash list of the confirmed transactions in the memory.

```c#
string[] verifiedTransactions = client.GetRawMempool();
```

### GetRawMempoolBoth

Gets the hash list of both confirmed and unconfirmed transactions in memory.

```c#
RpcRawMemPool memPool = client.GetRawMempoolBoth();
string[] verifiedTransactions = memPool.Verified;
string[] unverifiedTransactions = memPool.UnVerified;
```

### GetRawTransaction

Gets the transaction information by transaction ID.

```c#
RpcTransaction rpcTransaction = client.GetRawTransaction("f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657");
Transaction transaction = rpcTransaction.Transaction;
```

### GetRawTransactionHex

Gets the serialized transaction by transaction ID.

```c#
string serializedTransaction = client.GetRawTransactionHex("f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657");
```

### GetStorage
Gets the stored value through the contract script hash and stored key (which needs to be converted into a hex string):

```c#
string value = client.GetStorage("03febccf81ac85e3d795bc5cbd4e84e907812aa3", "5065746572");
```

### GetTransactionHeight
Gets the block height of the specified transaction by transaction ID:

```c#
uint height = client.GetTransactionHeight("f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657");
```

### GetValidators
Gets the consensus nodes information and voting status in the current network.

```c#
RpcValidator[] rpcValidators = client.GetValidators();
foreach (var validator in rpcValidators)
{
    string publicKey = validator.PublicKey;
    BigInteger voteCount = validator.Votes;
    bool isActive = validator.Active;
}
```

## Node

### GetConnectionCount
Gets the number of nodes connected to this node.

```c#
int connectionCount = client.GetConnectionCount();
```

### GetPeers
Gets a list of currently connected / unconnected nodes for this node, including IP address and port.

```c#
RpcPeers rpcPeers = client.GetPeers();
RpcPeer[] connected = rpcPeers.Connected;
RpcPeer[] unconnected = rpcPeers.Unconnected;
if (connected.Length > 0)
{
    RpcPeer peer = connected[1];
    string address = peer.Address;
    int port = peer.Port;
}
```

### GetVersion
Gets the version of the node receiving the RPC request:

```c#
RpcVersion rpcVersion = client.GetVersion();
string version = rpcVersion.UserAgent;
```

### SendRawTransaction
Sends and broadcasts the serialized transaction.

```c#
bool result = client.SendRawTransaction("80000001195876cb34364dc38b730077156c6bc3a7fc570044a66fbfeeea56f71327e8ab0000029b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc500c65eaf440000000f9a23e06f74cf86b8827a9108ec2e0f89ad956c9b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc50092e14b5e00000030aab52ad93f6ce17ca07fa88fc191828c58cb71014140915467ecd359684b2dc358024ca750609591aa731a0b309c7fb3cab5cd0836ad3992aa0a24da431f43b68883ea5651d548feb6bd3c8e16376e6e426f91f84c58232103322f35c7819267e721335948d385fae5be66e7ba8c748ac15467dcca0693692dac");
```

When `result` is `true` the transaction is broadcast successfully.  

When `result` is `false` the transaction broadcast fails due to double costs, incomplete signatures, etc.

### SubmitBlock
Sends and broadcasts the serialized block：

```c#
bool result = client.SubmitBlock("000000000000000000000000000000000000000000000000000000000000000000000000845c34e7c1aed302b1718e914da0c42bf47c476ac4d89671f278d8ab6d27aa3d65fc8857000000001dac2b7c00000000be48d3a3f5d10013ab9ffee489706078714f1ea2010001510400001dac2b7c00000000400000455b7b226c616e67223a227a682d434e222c226e616d65223a22e5b08fe89a81e882a1227d2c7b226c616e67223a22656e222c226e616d65223a22416e745368617265227d5d0000c16ff28623000000da1745e9b549bd0bfa1a569971c77eba30cd5a4b00000000400001445b7b226c616e67223a227a682d434e222c226e616d65223a22e5b08fe89a81e5b881227d2c7b226c616e67223a22656e222c226e616d65223a22416e74436f696e227d5d0000c16ff286230008009f7fd096d37ed2c0e3f7f0cfc924beef4ffceb680000000001000000019b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc50000c16ff2862300be48d3a3f5d10013ab9ffee489706078714f1ea201000151");
```

When `result` is `true` the block is broadcast successfully. 

When `result` is `false` the block broadcast fails with exception.

## Smart contract

### InvokeFunction
Invokes the specific method of the smart contract through the specified smart contract script hash, method name, and parameters, and returns the result after running in the virtual machine.

```c#
RpcStack rpcStack = new RpcStack()
{
    Type = "Hash160",
    Value = "91b83e96f2a7c4fdf0c1688441ec61986c7cae26"
};
UInt160 scriptHashesForVerifying = UInt160.Parse("0x20e22e16cfbcfdd29f347268427b76863b7679fa");
RpcInvokeResult rpcInvokeResult = client.InvokeFunction("af7c7328eee5a275a3bcaee2bf0cf662b5e739be", "balanceOf", new RpcStack[] { rpcStack },scriptHashesForVerifying);
string script = rpcInvokeResult.Script;
string engineState = rpcInvokeResult.State;
long gasConsumed = long.Parse(rpcInvokeResult.GasConsumed);
ContractParameter[] resultStacks = rpcInvokeResult.Stack;
foreach (var item in resultStacks)
{
    ContractParameterType contractParameterType = item.Type;
    object value = item.Value;
}
string transaction = rpcInvokeResult.Tx;
```

### InvokeScript
Returns the result after running the specified script in the virtual machine.

```c#
byte[] script = "00046e616d656724058e5e1b6008847cd662728549088a9ee82191".HexToBytes();
UInt160 scriptHashesForVerifying = UInt160.Parse("0x20e22e16cfbcfdd29f347268427b76863b7679fa");
RpcInvokeResult rpcInvokeResult = client.InvokeScript(script,scriptHashesForVerifying);
```

## Tools

### ListPlugins
Lists all the plugins loaded in the node.

```c#
RpcPlugin[] rpcPlugins = client.ListPlugins();
foreach (var item in rpcPlugins)
{
    string name = item.Name;
    string version = item.Version;
}
```

### ValidateAddress
Validates if the specified address is a valid Neo address.

```c#
RpcValidateAddressResult result = client.ValidateAddress("AQVh2pG732YvtNaxEGkQUei3YA4cvo7d2i");
bool isValid = result.IsValid;
```

## Wallets
The node local wallet interface contains the function of accessing the local wallet file. Before using the methods described in this section, you need to open the wallet using the openwallet method.

This method is disabled by default in the node configuration file for preventing high security risks.

### CloseWallet
Closes the wallet and clears the wallet information in memory.

```c#
bool result = client.CloseWallet();
```

### DumpPrivKey
Exports the private key of the specified address.

```c#
string wif = client.DumpPrivKey("NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ");
```

### GetBalance
Returns balance of the specified asset in the wallet by the asset id. This method is applicable to the native contract assets and NEP-5 compliant assets.

```c#
BigInteger balance = client.GetBalance(NativeContract.NEO.Hash.ToString());
```

### GetNewAddress
Creates a new account in the wallet and returns the corresponding address.

```c#
string address = client.GetNewAddress();
```

### GetUnclaimedGas
Displays amount of the unclaimed GAS in the wallet.

```c#
BigInteger amount = client.GetUnclaimedGas();
```

### ImportPrivKey
Imports the private key into the wallet.

```c#
string wif = "KyoYyZpoccbR6KZ25eLzhMTUxREwCpJzDsnuodGTKXSG8fDW9t7x";
RpcAccount account = client.ImportPrivKey(wif);
```

### ListAddress
Lists all the addresses in the wallet.

```c#
List<RpcAccount> acoounts = client.ListAddress();
```

### OpenWallet
Opens the wallet file in the machine where the node is located:

```c#
string path = "D:/temp/123.json";
string pass = "Password***";
bool result = client.OpenWallet(path, pass);
```

### SendFrom
Transfers asset from a specified address to another address.

```c#
string assetId = NativeContract.NEO.Hash.ToString();
string fromAddress = "NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ";
string toAddress= "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";
string amount = "100";
JObject result = client.SendFrom(assetId, fromAddress, toAddress, amount);
```
If the JSON transaction information is returned the transaction was sent successfully, or the transaction failed to be sent.

If the signature is incomplete transaction to be signed is returned.

If the balance is insufficient an error is returned.

### SendMany
Transfers assets to multiple addresses. You can specify the sending address.

```c#
List<RpcTransferOut> outs = new List<RpcTransferOut>();
outs.Add(new RpcTransferOut
{
    Asset = NativeContract.NEO.Hash,
    ScriptHash = Utility.GetScriptHash("NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ"),
    Value = "100"
});
outs.Add(new RpcTransferOut
{
    Asset = NativeContract.GAS.Hash,
    ScriptHash = Utility.GetScriptHash("NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW"),
    Value = "100.12345678"
});
JObject result = client.SendMany("", outs);
```
If the JSON transaction information is returned the transaction was sent successfully, or the transaction failed to be sent.

If the signature is incomplete transaction to be signed is returned.

If the balance is insufficient an error is returned.

### SendToAddress
Transfers asset to the specified address.

```c#
string assetId = NativeContract.NEO.Hash.ToString();
string toAddress = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";
string amount = "100";
JObject result = client.SendToAddress(assetId, toAddress,amount);
```
If the JSON transaction information is returned the transaction was sent successfully, or the transaction failed to be sent.

If the signature is incomplete transaction to be signed is returned.

If the balance is insufficient an error is returned.

## Plugins

### GetApplicationLog
Gets the contract log by the specific transaction ID. The plugin ApplicationLogs is required for invoking this method. 

```c#
string txHash = "0x23bf33766d00b4bb3314185f1ff0c2c85182d4d5e4e96f7c2df7506e7f99098b";
RpcApplicationLog log = client.GetApplicationLog(txHash);
```

### GetNep5Balances
Returns all NEP-5 assets balance at the specified address. The plugin RpcNep5Tracker is required for invoking this method.

```c#
string address = "NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ";
RpcNep5Balances balances = client.GetNep5Balances(address);
```

### GetNep5Transfers
Returns all NEP-5 transaction records at the specific address. The plugin RpcNep5Tracker is required for invoking this method.

If start and end timestamps are specified, transactions occurred in the time range is returned.

If no parameter is specified transactions in the past seven days are returned.

```c#
string address = "NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ";
RpcNep5Transfers transfers = client.GetNep5Transfers(address, 0);
```

### What's next?

[Getting Blockchain Data](monitor.md)

