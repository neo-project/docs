# NEO RPC SDK - 获取区块链数据和状态信息

> 注：本文档中使用的 NEO 版本为 3.0 及以上。

- 基本的区块链数据和状态信息，比如区块高度，区块内容，交易内容和合约基本信息等可以通过`RPC`模块可以直接获取，可以参见[RPC模块文档](rpc.md)；
- 某些特定的合约信息则需要通过特定合约方法的调用，如区块最大交易数量，每字节系统费可以通过`PolicyAPI`获取；NEP5 Token的名称，总量等需要用`Nep5API`获取。


## 通过RPC接口直接获取区块数据

- 获取最新区块高度或哈希

```c#
// choose a neo node with rpc opened
RpcClient client = new RpcClient("http://seed1t.neo.org:20332");

// get the highest block hash
string hash = client.GetBestBlockHash();

// get the highest block height
uint height = client.GetBlockCount() - 1;
```

- 获取某个区块内具体数据，包括交易列表等

```c#
// get block data
RpcBlock block = client.GetBlock("166396");

// get block data with block hash
RpcBlock block = client.GetBlock("0x953f6efa29c740b68c87e0a060942056382a6912a0ddeddc2f6641acb92d9700");
```

- 通过`RpcClient`可以获取合约脚本，哈希与manifest的信息：

```c#
// get neo contract state
ContractState contractState = client.GetContractState(NativeContract.NEO.Hash.ToString());
```

更多信息请参见[RPC模块文档](rpc.md)。

## 获取Policy相关信息

在NEO3中通过调用原生合约`PolicyContract`中的方法获取Policy相关信息：

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

## 获取NEP5合约信息

NEP5是NEO3中的资产标准，NEO和GAS都基于NEP5原生合约，对于NEP5合约可以通过`Nep5API`获取名称，标记，小数位和总量等信息：

```c#
// get nep5 token info
Nep5API nep5API = new Nep5API(client);
RpcNep5TokenInfo tokenInfo = nep5API.GetTokenInfo(NativeContract.NEO.Hash);
```
