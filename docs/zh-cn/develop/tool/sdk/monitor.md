# 获取区块信息

基本的区块链数据和状态信息，如区块高度、区块内容、交易内容和合约等可以通过 `RPC` 模块直接获取，详细信息请参见 [RPC 调用方法](rpc.md)。

而某些特定的合约信息，如区块最大交易数量，每字节系统费，NEP5 合约信息等则需要调用特定的合约方法。


## 通过 RPC 接口获取区块数据

获取最新区块高度或哈希：

```c#
// choose a neo node with rpc opened
RpcClient client = new RpcClient("http://seed1t.neo.org:20332");

// get the highest block hash
string hash = client.GetBestBlockHash();

// get the highest block height
uint height = client.GetBlockCount() - 1;
```

获取某个区块内具体数据，包括交易列表等：

```c#
// get block data
RpcBlock block = client.GetBlock("166396");

// get block data with block hash
RpcBlock block = client.GetBlock("0x953f6efa29c740b68c87e0a060942056382a6912a0ddeddc2f6641acb92d9700");
```

通过 `RpcClient` 获取合约脚本、哈希与 manifest 的信息：

```c#
// get NEO contract state
ContractState contractState = client.GetContractState(NativeContract.NEO.Hash.ToString());
```

更多信息请参见 [RPC 调用方法](rpc.md)。

## 获取 Policy 相关信息

调用原生合约 `PolicyContract` 中的方法 `policyAPI` 获取 Policy 相关信息：

```c#
// choose a neo node with rpc opened
PolicyAPI policyAPI = new PolicyAPI(new RpcClient("http://seed1t.neo.org:20332"));

// get the accounts blocked by policy
UInt160[] blockedAccounts = policyAPI.GetBlockedAccounts(); // [], no account is blocked by now

// get the system fee per byte
long feePerByte = policyAPI.GetFeePerByte(); // 1000, 0.00001000 GAS per byte

// get the max size of one block
uint maxBlockSize = policyAPI.GetMaxBlockSize(); // 262144, (1024 * 256) bytes one block

// get the max transaction count per block
uint maxTransactionsPerBlock = policyAPI.GetMaxTransactionsPerBlock(); // 512, max 512 transactions one block
```

## 获取 NEP5 合约信息

NEP5 是 Neo3 中的资产标准，NEO 和 GAS 都基于 NEP5 原生合约。调用 `Nep5API` 可以获取 NEP5 合约的名称、标记、小数位和总量等信息：

```c#
// get nep5 token info
Nep5API nep5API = new Nep5API(client);
RpcNep5TokenInfo tokenInfo = nep5API.GetTokenInfo(NativeContract.NEO.Hash);
```

## 阅读下节

[钱包相关接口](wallet.md)

