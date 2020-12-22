# Neo3 Governance API

## Economic Model

Inheriting from Neo2, Neo3 employs the dual-token mechanism, where NEO is used for governance and GAS is used for payment.

### NEO

NEO has a max supply of 100 million tokens and the smallest unit of 1, or in other words, is not divisible. NEO holders are the owners and managers of the Neo network. By constructing voting transactions on the Neo network, they can exercise management power, such as electing validators, adjusting consensus strategy, adjusting pricing model, etc., and can also claim the corresponding GAS based on the amount of NEO they hold.

### GAS

GAS is the fuel token for the realization of Neo network resource control, with a smallest unit of 0.00000001. Users can obtain GAS either through a claim or purchase. When using the Neo network, they need to pay a certain amount of GAS as network fees, such as transfer, registering assets, publishing assets, running DApps, etc.

| Native Contract | Contract Hash                                   |
| ------------ | ------------------------------------------ |
| `NeoToken` | 0xde5f57d430d3dece511cf975a8d37848cb9e0525 |
| `GasToken` | 0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc |
| `Policy` | 0xce06595079cd69583126dbfd1d2e25cca74cffe9 |

The way to call the native contract methods is the same as calling other ordinary contracts. `Contract.Call(NEO.hash, method, params)`

## Governance Strategy

### Candidate

#### Function & Scope

There is no duty assigned to candidates. However, committee members and validators are elected from certain number of candidates with most votes. Their relationship can be described in the following picture. There is no explicit relationship between committee members and validators but, as default committee member amount (21) is more than that of validators, generally speaking validators are a subset of committee members. 

![avatar](./assets/candidateRelationship.png)

#### How to Become a Candidate

An address can be registered as candidate or unregistered afterwards. Corresponding contract methods are as follows:

| Method | Parameters | Fee in GAS |
| ---- | ------------------------------------ | ---- |
| [`RegisterCandidate`](scapi/fw/dotnet/neo/Neo/RegisterCandidate.md) | UInt160 publicKey | 0.05 |
| [`UnregisterCandidate`](scapi/fw/dotnet/neo/Neo/UnregisterCandidate.md) | UInt160 publicKey | 0.05 |

> [!Note]
>
> Registering / unregistering candidate requires signature. It means candidate registering / unregistering is only self-determined. 

#### Candidate Voting 

Every address has the right to vote to only one address (whether or not it's a candidate). Candidate's received votes are defined as the sum of NEO held by its voter. Every standby committee member will vote to itself in genesis block. 

Voting contract method is as follows. Please not that voter's signature will be checked. 

| Method | Parameters | Fee in GAS |
| ---- | ------------------------------------ | ---- |
| [`Vote`](scapi/fw/dotnet/neo/Neo/Vote.md) | UInt160 account, byte[] voteTo | 5 |

As voters' votes & held NEO, as well as registered candidates keep changing, candidate set and their votes are re-calculated in every block.

#### Corresponding contract methods

| Method | Parameters | Fee in GAS |
| ---- | ------------------------------------ | ---- |
| [`GetCandidates`](scapi/fw/dotnet/neo/Neo/GetCandidates.md) | null | 1 |

### Committee

#### Function & Scope

Committee members have the privilege to modify the configuration of Neo network by voting, including:

* Set the maximum block size
* Set maximum transactions in a block
* Set fee per byte for network transmission
* Block / unblock account

Method definition and corresponding fee are defined in PolicyContract as shown below:

| Method | Parameters | Fee in GAS |
| ---- | ------------------------------------ | ---- |
| [`SetMaxBlockSize`](scapi/fw/dotnet/neo/Policy/SetMaxBlockSize.md) | uint blockSize | 0.03 |
| [`SetMaxTransactionsPerBlock`](scapi/fw/dotnet/neo/Policy/SetMaxTransactionsPerBlock.md) | uint maxTransactions | 0.03 |
| [`SetFeePerByte`](scapi/fw/dotnet/neo/Policy/SetFeePerByte.md) | long feePerByte | 0.03 |
| [`BlockAccount`](scapi/fw/dotnet/neo/Policy/BlockAccount.md) | UInt160 account | 0.03 |
| [`UnblockAccount`](scapi/fw/dotnet/neo/Policy/UnblockAccount.md) | UInt160 account | 0.03 |

To bring such modification into effect, committee members should send a transaction which calls corresponding method & includes enough signatures on chain. This transaction is executed as long as it's signed by more than half of the committee members.

Furthermore, PolicyContract also supports corresponding reading methods:

| Method | Parameters | Fee in GAS |
| ---- | ------------------------------------ | ---- |
| [`GetMaxBlockSize`](scapi/fw/dotnet/neo/Policy/GetMaxBlockSize.md) | null | 0.01 |
| [`GetMaxTransactionsPerBlock`](scapi/fw/dotnet/neo/Policy/GetMaxTransactionsPerBlock.md) | null | 0.01 |
| [`GetFeePerByte`](scapi/fw/dotnet/neo/Policy/GetFeePerByte.md) | null | 0.01 |
| [`getBlockedAccounts`](govapi/getBlockedAccounts.md) | null | 0.01 |

#### How Are Committee Members Elected

1. Sort the registered candidates by votes
2. Take certain numbers of candidates (21 by default) with the most votes as committee members.
Committee members will be refreshed every block.

#### Corresponding Contract method

| Method | Parameters | Fee in GAS | Return value |
| ---- | ------------------------------------ | ---- | ---- |
| [`GetCommittee`](scapi/fw/dotnet/neo/Neo/GetCommittee.md) | null | 1 | Current committee members in format of Array<ECPoint> |

### Validator

#### Function & Scope

Validators are nodes which are able to start or vote to new block proposals. Detailed description can be found in Neo3 write paper.

#### How Are Validators Elected

1. Sort the registered candidates by votes
2. Take certain numbers of candidates (7 by default) with the most votes as validators.
Similar to committee members, validators will be refreshed every block.

#### Corresponding Contract method

| Method | Parameters | Fee in GAS | Return value |
| ---- | ------------------------------------ | ---- | ---- |
| [`getValidators`](govapi/getValidators.md) | null | 1 | Current validators in format of Array<ECPoint> |
|  [`GetNextBlockValidators`](scapi/fw/dotnet/neo/Neo/GetNextBlockValidators.md)  | null | 1 | Validators by persisting block in format of Array<ECPoint> |

## Token Distribution

Half of total NEO amount, or 50 million tokens are distributed in genesis block to all standby committee members in the following rules:

1. Get N1 = amount of standby committee members & N2 = amount of standby validators according to protocol.json

2. Separate 50 million NEO tokens into (N1 + N2) portions and distribute them to all committee members: every non-validator with 1 portion and every validator with 2 portions

3. Remaining half is distributed to standby validators' multi-signature address

   All interactions in Neo are performed through transactions. Sending a transaction on chain requires paying GAS tokens as fee, including system fee and network fee. System fee will be burnt as resource consumption for transaction execution, while network fee will be distributed to the speaker (the validator who start a new-block proposal) of the block where corresponding transaction is included.

## Nep5 Contract method

NEO and GAS are [Nep5](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki) contracts. Nep5 contract methods are as follows:

| Method | Parameters | Fee in GAS | Result |
| ---- | ---- | ---- | ---- |
| [`name`](govapi/name.md)  | null | 0 | Token name in String |
| [`symbol`](govapi/symbol.md)  | null | 0 | Token symbol in String |
|  [`decimals`](govapi/decimals.md)  | null | 0.01 | Token decimals in UInt |
| [`TotalSupply`](scapi/fw/dotnet/neo/Neo/TotalSupply.md) | null | 0.01 | Token total supply in BigInteger |
| [`BalanceOf`](scapi/fw/dotnet/neo/Neo/BalanceOf.md) | UInt160 account | 0.01 | account balance in BigInteger |
| [`Transfer`](scapi/fw/dotnet/neo/Neo/Transfer.md) | UInt160 from, UInt160 to, BigInteger amount | 0.08 | Send specified amount of token from Address *from* to Address *to*. Please note that it will check *from*'s signature, whether caller is *from*, whether *to* is payable, whether *from*'s balance is enough |
|  [`onPersist`](govapi/onPersist.md) | null | 0 | Manually perform actions this Nep5 contract will do upon block persisting |
| [`supportedStandards`](govapi/supportedStandards.md) | null | 0 | Supported NEP standards in String[] |

Contract methods by NEO:

| Method | Parameters | Fee in GAS | Return value |
| ---- | ------------------------------------ | ---- | ---- |
| [`UnclaimedGas`](scapi/fw/dotnet/neo/Neo/UnclaimedGas.md) | UInt160 account | 0.03 | unclaimed GAS amount of this address in uint |
