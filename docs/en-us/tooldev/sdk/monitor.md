# Getting Blockchain Information

The `RPC` module provides methods to get basic information of blockchain data and status, such as block height, block content, transaction details, and contracts. 

For some specific information of contracts, such as the block maximum transaction number, system fee per byte, NEP-5 contract details, you need to invoke specific contract methods, which will be introduced in this document.


## Getting blockchain data from RPC interfaces

Gets the latest block height or hash:

```c#
// choose a neo node with rpc opened
RpcClient client = new RpcClient("http://seed1t.neo.org:20332");

// get the highest block hash
string hash = client.GetBestBlockHash();

// get the highest block height
uint height = client.GetBlockCount() - 1;
```

Gets the specific data inside a block, including transaction list, etc.

```c#
// get block data
RpcBlock block = client.GetBlock("166396");

// get block data with block hash
RpcBlock block = client.GetBlock("0x953f6efa29c740b68c87e0a060942056382a6912a0ddeddc2f6641acb92d9700");
```

Gets the contract script, hash, and manifest through `RpcClient`:

```c#
// get NEO contract state
ContractState contractState = client.GetContractState(NativeContract.NEO.Hash.ToString());
```

For more information refer to [RPC invocation methods](rpc.md).

## Getting policy information

Invokes the method  `policyAPI` in the native contract `PolicyContract` to get the Policy related information:

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

## Getting NEP-5 contract information

NEP5 is an asset standard for Neo3, such as NEO and GAS, both of which are assets based on NEP5 native contract. You can invoke  `Nep5API`  to get the name, mark, decimal place, and amount of the NEP5 contract.

```c#
// get nep5 token info
Nep5API nep5API = new Nep5API(client);
RpcNep5TokenInfo tokenInfo = nep5API.GetTokenInfo(NativeContract.NEO.Hash);
```

## What's next?

[Wallet Interfaces](wallet.md)

