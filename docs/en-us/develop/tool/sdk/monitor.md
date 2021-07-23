# Getting Blockchain Information

The `RPC` module provides methods to get basic information of blockchain data and status, such as block height, block content, transaction details, and contracts. 

For some specific information of contracts, such as the block maximum transaction number, system fee per byte, NEP-17 contract details, you need to invoke specific contract methods, which will be introduced in this document.


## Getting blockchain data from RPC interfaces

Gets the latest block height or hash:

```c#
// choose a neo node with rpc opened
RpcClient client = new RpcClient(new Uri("http://localhost:20332"), null, null, ProtocolSettings.Load("config.json"));

// get the hash of the tallest block in the main chain
string hash = await client.GetBestBlockHashAsync().ConfigureAwait(false);

// get the number of blocks in the main chain
uint count = await client.GetBlockCountAsync().ConfigureAwait(false);
```

Gets the specific data inside a block, including transaction list, etc.

```c#
// get the Base64 string of the block with block height
string blockHex = await client.GetBlockHexAsync("166396").ConfigureAwait(false);

// get the Base64 string of the block with block hash
string blockHex = await client.GetBlockHexAsync("0x4e61cd9d76e30e9147ee0f5b9c92f4447decbe52c6c8b412d0382a14d3a0b408").ConfigureAwait(false);

// get block data with block height
RpcBlock block = await client.GetBlockAsync("166396").ConfigureAwait(false);

// get block data with block hash
RpcBlock block = await client.GetBlockAsync("0x4e61cd9d76e30e9147ee0f5b9c92f4447decbe52c6c8b412d0382a14d3a0b408").ConfigureAwait(false);
```

Gets the contract script, hash, and manifest through `RpcClient`:

```c#
// get NEO contract state
ContractState contractState = await client.GetContractStateAsync(NativeContract.NEO.Hash.ToString()).ConfigureAwait(false);
```

For more information refer to [RPC invocation methods](rpc.md).

## Getting policy information

Invokes the method  `policyAPI` in the native contract `PolicyContract` to get the Policy related information:

```c#
// choose a neo node with rpc opened
PolicyAPI policyAPI = new PolicyAPI(new RpcClient(new Uri("http://localhost:20332"), null,null, ProtocolSettings.Load("config.json")));

// get the system fee per byte
long feePerByte = await policyAPI.GetFeePerByteAsync().ConfigureAwait(false); // 1000, 0.00001000 GAS per byte

// get the max size of one block
uint maxBlockSize = await policyAPI.GetMaxBlockSizeAsync().ConfigureAwait(false); // 262144, (1024 * 256) bytes one block

// get the max transaction count per block
uint maxTransactionsPerBlock = await policyAPI.GetMaxTransactionsPerBlockAsync().ConfigureAwait(false); // 512, max 512 transactions one block

// check if the account is blocked
UInt160 account = Utility.GetScriptHash("NirHUAteaMr6CqWuAAMaEUScPcS3FDKebM");
bool isBlocked = await policyAPI.IsBlockedAsync(account).ConfigureAwait(false);
```

## Getting NEP-17 contract information

NEP17 is an asset standard for Neo N3, such as NEO and GAS, both of which are assets based on NEP17 native contract. You can invoke  `Nep17API`  to get the name, mark, decimal place, and amount of the NEP17 contract.

```c#
// get nep17 token info
Nep17API nep17API = new Nep17API(new RpcClient(new Uri("http://localhost:20332"), null,null, ProtocolSettings.Load("config.json")));
RpcNep17TokenInfo tokenInfo = await nep17API.GetTokenInfoAsync(NativeContract.NEO.Hash).ConfigureAwait(false);
```

