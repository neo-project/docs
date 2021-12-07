# RPC Invocation Methods

The `RpcClient` encapsulates all the interfaces provided by RpcServer. You can send RPC requests in your code through the standard methods provided in this module. You only need to pass in the corresponding parameters, the SDK will construct the corresponding JSON-RPC requests and then get the data returned by the node.


## Initializing RpcClient
Before you can send RPC requests you need to initialize  `RpcClient` first. Choose the RPC server port of a Neo node according to your own needs. Here is an example:

Test net node：

```c#
// TestNet Node
RpcClient client = new RpcClient(new Uri("http://seed1.neo.org:20332"), null, null, ProtocolSettings.Load("config.json"));
```

Local node (the local Neo-CLI that can be connected to main net, test net, or private net according to configuration):

```c#
// Local Node
RpcClient client = new RpcClient(new Uri("http://localhost:20332"), null, null, ProtocolSettings.Load("config.json"));
```

> [!Note]
>
> Typically, only one RpcClient instance needs to be initialized in an application, not needing in each method.

## Blockchain data

### GetBestBlockHashAsync
Gets the hash of the highest block in the blockchain:

```c#
string hexString = await client.GetBestBlockHashAsync().ConfigureAwait(false);
byte[] hashBytes = hexString.HexToBytes();
UInt256 hash256 = UInt256.Parse(hexString);
```

### GetBlockAsync
Gets the detailed block information by the block hash or block index.

```c#
RpcBlock rpcBlock = await client.GetBlockAsync("773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e").ConfigureAwait(false);
Block block = rpcBlock.Block;
```

or 

```c#
RpcBlock rpcBlock = await client.GetBlockAsync("1024").ConfigureAwait(false);
Block block = rpcBlock.Block;
```

You can also get the serialized block information through the block hash value or block index:

```c#
string serializedBlock = await client.GetBlockHexAsync("773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e").ConfigureAwait(false);
```

### GetBlockCountAsync

Gets the current block quantity.

Block index（Index） = Block height（Height） = Block count（Count） - 1

```c#
uint blockCount = await client.GetBlockCountAsync().ConfigureAwait(false);
```

### GetBlockHashAsync

Gets the block hash by the block index.

```c#
string hexString = await client.GetBlockHashAsync(10000).ConfigureAwait(false);
byte[] hashBytes = hexString.HexToBytes();
UInt256 hash256 = UInt256.Parse(hexString);
```

### Get the block header information
Get the specific block header information by the block hash or block index:

```c#
RpcBlockHeader blockHeader = await client.GetBlockHeaderAsync("a5508c9b6ed0fc09a531a62bc0b3efcb6b8a9250abaf72ab8e9591294c1f6957").ConfigureAwait(false);
Header header = blockHeader.Header;
```

or

```c#
RpcBlockHeader blockHeader = await client.GetBlockHeaderAsync("10000").ConfigureAwait(false);
Header header = blockHeader.Header;
```

Get the serialized block header information from the block hash or block index:

```c#
string serializedBlockHeader = await client.GetBlockHeaderHexAsync("a5508c9b6ed0fc09a531a62bc0b3efcb6b8a9250abaf72ab8e9591294c1f6957").ConfigureAwait(false);
```

or

```
string serializedBlockHeader = await client.GetBlockHeaderHexAsync("10000").ConfigureAwait(false);
```

### GetContractStateAsync
Gets the contract information from the contract hash or contract ID

```c#
ContractState contractState = await client.GetContractStateAsync("dc675afc61a7c0f7b3d2682bf6e1d8ed865a0e5f").ConfigureAwait(false);
```

```c#
ContractState contractState = client.GetContractState(-1);
```

### GetRawMempoolAsync
Gets hash list of the confirmed transactions in the memory.

```c#
string[] verifiedTransactions = await client.GetRawMempoolAsync().ConfigureAwait(false);
```

### GetRawMempoolBothAsync

Gets both confirmed and unconfirmed transaction hashes in memory:

```c#
RpcRawMemPool memPool = await client.GetRawMempoolBothAsync().ConfigureAwait(false);
string[] verifiedTransactions = memPool.Verified;
string[] unverifiedTransactions = memPool.UnVerified;
```

### GetRawTransactionAsync

Gets the transaction information by transaction ID.

```c#
RpcTransaction rpcTransaction = await client.GetRawTransactionAsync("f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657").ConfigureAwait(false);
Transaction transaction = rpcTransaction.Transaction;
```

### GetRawTransactionHexAsync

Gets the serialized transaction by transaction ID.

```c#
string serializedTransaction = await client.GetRawTransactionHexAsync("f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657").ConfigureAwait(false);
```

### CalculateNetworkFeeAsync

Calculates network fee of the specified transaction.

```
long networkFee = await rpcClient.CalculateNetworkFeeAsync(transaction).ConfigureAwait(false);
```

### GetStorageAsync

Gets the stored value through the contract script hash and stored key (which needs to be converted into a hex string):

```c#
string value = await client.GetStorageAsync("03febccf81ac85e3d795bc5cbd4e84e907812aa3", "5065746572").ConfigureAwait(false);
```

### GetTransactionHeightAsync
Gets the block height of the specified transaction by transaction ID:

```c#
uint height = await client.GetTransactionHeightAsync("f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657").ConfigureAwait(false);
```

### GetNextBlockValidatorsAsync
Gets the consensus nodes information and voting status in the current network.

```c#
RpcValidator[] rpcValidators = await client.GetNextBlockValidatorsAsync().ConfigureAwait(false);
foreach (var validator in rpcValidators)
{
    string publicKey = validator.PublicKey;
    BigInteger voteCount = validator.Votes;
    bool isActive = validator.Active;
}
```

### GetCommitteeAsync

Gets the public key list of the current committee members.

```c#
string[] committees = await client.GetCommitteeAsync().ConfigureAwait(false);
```

## Node

### GetConnectionCount
Gets the number of nodes connected to this node.

```c#
int connectionCount = await client.GetConnectionCountAsync().ConfigureAwait(false);
```

### GetPeersAsync
Gets a list of currently connected / unconnected nodes for this node, including IP address and port.

```c#
RpcPeers rpcPeers = await client.GetPeersAsync().ConfigureAwait(false);;
RpcPeer[] connected = rpcPeers.Connected;
RpcPeer[] unconnected = rpcPeers.Unconnected;
if (connected.Length > 0)
{
    RpcPeer peer = connected[1];
    string address = peer.Address;
    int port = peer.Port;
}
```

### GetVersionAsync
Gets the version of the node receiving the RPC request:

```c#
RpcVersion rpcVersion = await client.GetVersionAsync().ConfigureAwait(false);
string version = rpcVersion.UserAgent;
```

### SendRawTransactionAsync
Sends and broadcasts the serialized transaction.

```c#
UInt256 txHash = await client.SendRawTransactionAsync("80000001195876cb34364dc38b730077156c6bc3a7fc570044a66fbfeeea56f71327e8ab0000029b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc500c65eaf440000000f9a23e06f74cf86b8827a9108ec2e0f89ad956c9b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc50092e14b5e00000030aab52ad93f6ce17ca07fa88fc191828c58cb71014140915467ecd359684b2dc358024ca750609591aa731a0b309c7fb3cab5cd0836ad3992aa0a24da431f43b68883ea5651d548feb6bd3c8e16376e6e426f91f84c58232103322f35c7819267e721335948d385fae5be66e7ba8c748ac15467dcca0693692dac").HexToBytes()).ConfigureAwait(false);
```

Or broadcasts the transaction (tx) over the blockchain:

```c#
UInt256 txHash = await client.SendRawTransactionAsync(transaction).ConfigureAwait(false);
```

### SubmitBlockAsync
Sends and broadcasts the serialized block：

```c#
UInt256 blockHash = await client.SubmitBlockAsync("000000000000000000000000000000000000000000000000000000000000000000000000845c34e7c1aed302b1718e914da0c42bf47c476ac4d89671f278d8ab6d27aa3d65fc8857000000001dac2b7c00000000be48d3a3f5d10013ab9ffee489706078714f1ea2010001510400001dac2b7c00000000400000455b7b226c616e67223a227a682d434e222c226e616d65223a22e5b08fe89a81e882a1227d2c7b226c616e67223a22656e222c226e616d65223a22416e745368617265227d5d0000c16ff28623000000da1745e9b549bd0bfa1a569971c77eba30cd5a4b00000000400001445b7b226c616e67223a227a682d434e222c226e616d65223a22e5b08fe89a81e5b881227d2c7b226c616e67223a22656e222c226e616d65223a22416e74436f696e227d5d0000c16ff286230008009f7fd096d37ed2c0e3f7f0cfc924beef4ffceb680000000001000000019b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc50000c16ff2862300be48d3a3f5d10013ab9ffee489706078714f1ea201000151").HexToBytes()).ConfigureAwait(false);
```

## Smart contract

### InvokeFunctionAsync
Invokes the specific method of the smart contract through the specified smart contract script hash, method name, and parameters, and returns the result after running in the virtual machine.

```c#
string contractHash = "0xd2a4cff31913016155e38e474a2c06d08be276cf";
string method = "transfer";
RpcStack from = new RpcStack()
{
    Type = "Hash160",
    Value = "0x262678399f390ee9f0cfd9ac8c65df8c149b4e9c"
};
RpcStack to = new RpcStack()
{
    Type = "Hash160",
    Value = "0x753b9b069ef88dea7323a0f1ba6cb24486584f05"
};
RpcStack amount = new RpcStack()
{
    Type = "Integer",
    Value = "120000000"
};
RpcStack data = new RpcStack()
{
    Type = "String",
    Value = "my data"
};

Signer signer0 = new Signer()
{
    Account = UInt160.Parse("0x262678399f390ee9f0cfd9ac8c65df8c149b4e9c")
};

RpcInvokeResult rpcInvokeResult = await _rpcClient.InvokeFunctionAsync(contractHash, method, new RpcStack[] { from, to, amount, data }, signer0).ConfigureAwait(false);

string script = rpcInvokeResult.Script;
var engineState = rpcInvokeResult.State;
long gasConsumed = rpcInvokeResult.GasConsumed;
```

### InvokeScriptAsync
Returns the result after running the specified script in the virtual machine.

```c#
byte[] script = "00046e616d656724058e5e1b6008847cd662728549088a9ee82191".HexToBytes();
RpcInvokeResult rpcInvokeResult = await client.InvokeScriptAsync(script).ConfigureAwait(false);
```

### GetUnclaimedGasAsync

Gets amount of unclaimed GAS at the specified address.

```c#
RpcUnclaimedGas unclaimedGas = await client.GetUnclaimedGasAsync("NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM").ConfigureAwait(false);
BigInteger unclaimed = unclaimedGas.Unclaimed;
string address = unclaimedGas.Address;
```

## Tools

### ListPluginsAsync
Lists all the plugins loaded in the node.

```c#
RpcPlugin[] rpcPlugins = await client.ListPluginsAsync().ConfigureAwait(false);
foreach (var item in rpcPlugins)
{
    string name = item.Name;
    string version = item.Version;
}
```

### ValidateAddressAsync
Validates if the specified address is a valid Neo address.

```c#
RpcValidateAddressResult result = await client.ValidateAddressAsync("AQVh2pG732YvtNaxEGkQUei3YA4cvo7d2i").ConfigureAwait(false);
string address = result.Address;
bool isValid = result.IsValid;
```

## Wallets
The node local wallet interface contains the function of accessing the local wallet file. Before using the methods described in this section, you need to open the wallet using the openwallet method.

This method is disabled by default in the node configuration file for preventing high security risks.

### OpenWalletAsync

Opens the wallet file in the machine running the node.

```c#
string path = "D:/temp/123.json";
string password = "Password***";
bool result = await client.OpenWalletAsync(path, password).ConfigureAwait(false);
```

### CloseWalletAsync
Closes the wallet and clears the wallet information in memory.

```c#
bool result = await client.CloseWalletAsync().ConfigureAwait(false);
```

### DumpPrivKeyAsync
Exports the private key of the specified address.

```c#
string wif = await client.DumpPrivKeyAsync("NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ").ConfigureAwait(false);
```

### GetBalanceAsync
Returns balance of the specified asset in the wallet by the asset id. This method is applicable to the native contract assets and NEP-17 compliant assets.

```c#
BigDecimal balance = await client.GetWalletBalanceAsync(NativeContract.NEO.Hash.ToString()).ConfigureAwait(false);
```

### GetNewAddressAsync
Creates a new account in the wallet and returns the corresponding address.

```c#
string address = await client.GetNewAddressAsync().ConfigureAwait(false);
```

### GetUnclaimedGasAsync
Displays amount of the unclaimed GAS in the wallet.

```c#
BigInteger amount = await client.GetWalletUnclaimedGasAsync().ConfigureAwait(false);
```

### ImportPrivKeyAsync
Imports the private key into the wallet.

```c#
string wif = "KyoYyZpoccbR6KZ25eLzhMTUxREwCpJzDsnuodGTKXSG8fDW9t7x";
RpcAccount account = await client.ImportPrivKeyAsync(wif).ConfigureAwait(false);
```

### ListAddressAsync
Lists all the addresses in the wallet.

```c#
List<RpcAccount> acoounts = await client.ListAddressAsync().ConfigureAwait(false);
```

### SendFromAsync
Transfers asset from a specified address to another address.

```c#
string assetId = NativeContract.NEO.Hash.ToString();
string fromAddress = "NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ";
string toAddress= "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";
string amount = "100";
JObject result = await client.SendFromAsync(assetId, fromAddress, toAddress, amount).ConfigureAwait(false);
```
If the JSON transaction information is returned the transaction was sent successfully, or the transaction failed to be sent.

If the signature is incomplete transaction to be signed is returned.

If the balance is insufficient an error is returned.

### SendManyAsync
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
JObject result = await client.SendManyAsync("", outs).ConfigureAwait(false);
```
If the JSON transaction information is returned the transaction was sent successfully, or the transaction failed to be sent.

If the signature is incomplete transaction to be signed is returned.

If the balance is insufficient an error is returned.

### SendToAddressAsync
Transfers asset to the specified address.

```c#
string assetId = NativeContract.NEO.Hash.ToString();
string toAddress = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";
string amount = "100";
JObject result = await client.SendToAddressAsync(assetId, toAddress, amount).ConfigureAwait(false);
```
If the JSON transaction information is returned the transaction was sent successfully, or the transaction failed to be sent.

If the signature is incomplete transaction to be signed is returned.

If the balance is insufficient an error is returned.

## Plugins

### GetApplicationLogAsync
Gets the contract log by the specific transaction ID. The plugin ApplicationLogs is required for invoking this method. 

```c#
string txHash = "0x23bf33766d00b4bb3314185f1ff0c2c85182d4d5e4e96f7c2df7506e7f99098b";
RpcApplicationLog log = await client.GetApplicationLogAsync(txHash).ConfigureAwait(false);
```

Or gets the contract log based on the specified transaction ID and trigger type

```c#
string txHash = "0x23bf33766d00b4bb3314185f1ff0c2c85182d4d5e4e96f7c2df7506e7f99098b";
RpcApplicationLog log = await client.GetApplicationLogAsync(txHash, TriggerType.Application).ConfigureAwait(false);
```

### GetNep17BalancesAsync

Returns all NEP-17 assets balance at the specified address. The plugin TokensTracker is required for invoking this method.

```c#
string address = "NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ";
RpcNep17Balances balances = await client.GetNep17BalancesAsync(address).ConfigureAwait(false);
```

### GetNep17TransfersAsync
Returns all NEP-17 transaction records at the specific address. The plugin TokensTracker is required for invoking this method.

If start and end timestamps are specified, transactions occurred in the time range is returned.

If no parameter is specified transactions in the past seven days are returned.

```c#
string address = "NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ";
RpcNep17Transfers transfers = await client.GetNep17TransfersAsync(address, 0).ConfigureAwait(false);
```
