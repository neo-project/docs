# 获取区块信息

基本的区块链数据和状态信息，如区块高度、区块内容、交易内容和合约等可以通过 `RPC` 模块直接获取，详细信息请参见 [RPC 调用方法](rpc.md)。

而某些特定的合约信息，如区块最大交易数量，每字节系统费，NEP17 合约信息等则需要调用特定的合约方法。


## 通过 RPC 接口获取区块数据

获取最新区块高度或哈希：

```c#
// choose a neo node with rpc opened
RpcClient client = new RpcClient(new Uri("http://localhost:20332"), null, null, ProtocolSettings.Load("config.json"));

// get the hash of the tallest block in the main chain
string hash = await client.GetBestBlockHashAsync().ConfigureAwait(false);

// get the number of blocks in the main chain
uint count = await client.GetBlockCountAsync().ConfigureAwait(false);
```

获取指定高度或哈希的区块内具体数据，包括交易列表等；结果可以是Base64编码的字符串或者Json字符串：

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

通过 `RpcClient` 获取合约脚本、哈希与 manifest 的信息：

```c#
// get NEO contract state
ContractState contractState = await client.GetContractStateAsync(NativeContract.NEO.Hash.ToString()).ConfigureAwait(false);
```

更多信息请参见 [RPC 调用方法](rpc.md)。

## 获取 Policy 相关信息

调用原生合约 `PolicyContract` 中的方法 `policyAPI` 获取 Policy 相关信息：

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

## 获取 NEP17 合约信息

NEP17 是 Neo N3 中的资产标准，NEO 和 GAS 都基于 NEP17 原生合约。调用 `Nep17API` 可以获取 NEP17 合约的名称、标记、小数位和总量等信息：

```c#
// get nep17 token info
Nep17API nep17API = new Nep17API(new RpcClient(new Uri("http://localhost:20332"), null,null, ProtocolSettings.Load("config.json")));
RpcNep17TokenInfo tokenInfo = await nep17API.GetTokenInfoAsync(NativeContract.NEO.Hash).ConfigureAwait(false);
```

