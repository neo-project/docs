# Neo3 Governance API

## Economic Model

Inheriting from Neo2, Neo3 employs the dual-token mechanism, where NEO is used for governance and GAS is used for payment.

### NEO

NEO has a max supply of 100 million tokens and the smallest unit of 1, or in other words, is not divisible. NEO holders are the owners and managers of the Neo network. By constructing voting transactions on the Neo network, they can exercise management power, such as electing validators, adjusting consensus strategy, adjusting pricing model, etc., and can also claim the corresponding GAS based on the amount of NEO they hold.

### GAS

GAS is the fuel token for the realization of Neo network resource control, with a smallest unit of 0.00000001. Users can obtain GAS either through a claim or purchase. When using the Neo network, they need to pay a certain amount of GAS as network fees, such as transfer, registering assets, publishing assets, running DApps, etc.

| Native Contract | Contract Hash                                   |
| ------------ | ------------------------------------------ |
| `ContractManagement` | 0xfffdc93764dbaddd97c48f252a53ea4643faa3fd |
| `StdLib` | 0xacce6fd80d44e1796aa0c2c625e9e4e0ce39efc0 |
| `CryptoLib` | 0x726cb6e0cd8628a1350a611384688911ab75f51b |
| `LedgerContract` | 0xda65b600f7124ce6c79950c1772a36403104f2be |
| `NeoToken` | 0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5 |
| `GasToken` | 0xd2a4cff31913016155e38e474a2c06d08be276cf |
| `PolicyContract` | 0xcc5e4edd9f5f8dba8bb65734541df7a1c081c67b |
| `RoleManagement` | 0x49cf4e5378ffcd4dec034fd98a174c5491e395e2 |
| `OracleContract` | 0xfe924b7cfe89ddd271abaf7210a80a7e11178758 |
| `NameService` | 0x7a8fcf0392cd625647907afa8e45cc66872b596b |

The way to call the native contract methods is the same as calling other ordinary contracts. `Contract.Call(NEO.hash, method, callFlags, params)`

## Governance Strategy

### Candidate

#### Function & Scope

There is no duty assigned to candidates. However, committee members and validators are elected from certain number of candidates with most votes. Their relationship can be described in the following picture. There is no explicit relationship between committee members and validators but, as default committee member amount (21) is more than that of validators, generally speaking validators are a subset of committee members. 

![avatar](./assets/candidateRelationship.png)

#### How to Become a Candidate

An address can be registered as candidate or unregistered afterwards. Corresponding contract methods are as follows:

| Method | Parameters | Fee in GAS |
| ---- | ------------------------------------ | ---- |
| [`RegisterCandidate`](scapi/fw/dotnet/neo/Neo/RegisterCandidate.md) | UInt160 publicKey | Adjustable, initially 0.00001 |
| [`UnregisterCandidate`](scapi/fw/dotnet/neo/Neo/UnregisterCandidate.md) | UInt160 publicKey | 0.00065536 (CpuFee) |

> [!Note]
>
> Registering / unregistering candidate requires signature. It means candidate registering / unregistering is only self-determined. 

#### Candidate Voting 

Every address has the right to vote to only one address (whether or not it's a candidate). Candidate's received votes are defined as the sum of NEO held by its voter. Every standby committee member will vote to itself in genesis block. 

Voting contract method is as follows. Please not that voter's signature will be checked. 

| Method | Parameters | Fee in GAS |
| ---- | ------------------------------------ | ---- |
| [`Vote`](scapi/fw/dotnet/neo/Neo/Vote.md) | UInt160 account, byte[] voteTo | 0.00065536 (CpuFee) |

As voters' votes & held NEO, as well as registered candidates keep changing, candidate set and their votes are re-calculated in every block.

#### Corresponding contract methods

| Method | Parameters | Fee in GAS |
| ---- | ------------------------------------ | ---- |
| [`GetCandidates`](scapi/fw/dotnet/neo/Neo/GetCandidates.md) | null | 0.04194304 (CpuFee) |

### Committee

#### Function & Scope

Committee members have the privilege to modify the configuration of Neo network by voting, including:

* Role designation
* Set fee per byte for network transmission
* Set execution fee (CpuFee) factor
* Set storage price
* Block / unblock account
* Set Oracle service price
* Set gas released per block
* Set fee to register a candidate
* Add NNS root
* Set fee to register / modify NNS
* Set minimum fee for contract deployment

Method definition and corresponding fee are defined in PolicyContract as shown below:

| Method | Parameters | Fee in GAS | Contract |
| ---- | ------------------------------------ | ---- | ---- |
| DesignateAsRole | Role role, ECPoint[] nodes | 0.00032768 (CpuFee) | RoleManagement |
| SetFeePerByte | long value | 0.00032768 (CpuFee) | PolicyContract |
| SetExecFeeFactor | uint value | 0.00032768 (CpuFee) | PolicyContract |
| SetStoragePrice | uint value | 0.00032768 (CpuFee) | PolicyContract |
| [`BlockAccount`](scapi/fw/dotnet/neo/Policy/BlockAccount.md) | UInt160 account | 0.00032768 (CpuFee) | PolicyContract |
| [`UnblockAccount`](scapi/fw/dotnet/neo/Policy/UnblockAccount.md) | UInt160 account | 0.00032768 (CpuFee) | PolicyContract |
| SetPrice | long price | 0.00032768 (CpuFee) | OracleContract |
| SetGasPerBlock | BigInteger gasPerBlock | 0.00032768 (CpuFee) | NeoToken |
| SetRegisterPrice | long registerPrice | 0.00032768 (CpuFee) | NeoToken |
| AddRoot | string root | 0.00032768 (CpuFee) | NameService |
| SetPrice | long price | 0.00032768 (CpuFee) | NameService |
| SetMinimumDeploymentFee | BigInteger value | 0.00032768 (CpuFee) | ContractManagement |

To bring such modification into effect, committee members should send a transaction which calls corresponding method & includes enough signatures on chain. This transaction is executed as long as it's signed by more than half of the committee members.

Furthermore, corresponding reading methods are also supported:

| Method | Parameters | Fee in GAS | Contract |
| ---- | ------------------------------------ | ---- | ---- |
| [`GetDesignatedByRole`](scapi/fw/dotnet/neo/RoleManagement/GetDesignatedByRole.md) | Role role, uint index | 0.00032768 (CpuFee) | RoleManagement |
| [`GetFeePerByte`](scapi/fw/dotnet/neo/Policy/GetFeePerByte.md) | null | 0.00032768 (CpuFee) | PolicyContract |
| GetExecFeeFactor | null | 0.00032768 (CpuFee) | PolicyContract |
| GetStoragePrice | null | 0.00032768 (CpuFee) | PolicyContract |
| [`IsBlocked`](scapi/fw/dotnet/neo/Policy/IsBlocked.md) | UInt160 account | 0.00032768 (CpuFee) | PolicyContract |
| GetPrice | null | 0.00032768 (CpuFee) | OracleContract |
| [`GetGasPerBlock`](scapi/fw/dotnet/neo/Neo/GetGasPerBlock.md) | null | 0.00032768 (CpuFee) | NeoToken |
| GetRegisterPrice | null | 0.00032768 (CpuFee) | NeoToken |
| [`GetPrice`](scapi/fw/dotnet/neo/NameService/GetPrice.md) | null | 0.00032768 (CpuFee) | NameService |
| GetMinimumDeploymentFee | null | 0.00032768 (CpuFee) | ContractManagement |

#### How Are Committee Members Elected

1. Sort the registered candidates by votes
2. Take certain numbers of candidates (21 by default) with the most votes as committee members.
Committee members will be refreshed every block.

#### Corresponding Contract method

| Method | Parameters | Fee in GAS | Return value |
| ---- | ------------------------------------ | ---- | ---- |
| [`GetCommittee`](scapi/fw/dotnet/neo/Neo/GetCommittee.md) | null | 0.04194304 (CpuFee) | Current committee members in format of Array<ECPoint> |

### Validator

#### Function & Scope

Validators are nodes which are able to start or vote to new block proposals. 

#### How Are Validators Elected

1. Sort the registered candidates by votes
2. Take certain numbers of candidates (7 by default) with the most votes as validators.
Similar to committee members, validators will be refreshed every block.

#### Corresponding Contract method

| Method | Parameters | Fee in GAS | Return value |
| ---- | ------------------------------------ | ---- | ---- |
|  [`GetNextBlockValidators`](scapi/fw/dotnet/neo/Neo/GetNextBlockValidators.md)  | null | 0.04194304 (CpuFee) | Validators by persisting block in format of Array<ECPoint> |

## Token Distribution

Total NEO amount, or 100 million tokens are distributed in genesis block to standby validators' multi-signature address.

All interactions in Neo are performed through transactions. Sending a transaction on chain requires paying GAS tokens as fee, including system fee and network fee. System fee will be burnt as resource consumption for transaction execution, while network fee will be distributed to the speaker (the validator who start a new-block proposal) of the block where corresponding transaction is included.

## Nep17 Contract method

NEO and GAS are [Nep17](https://github.com/neo-project/proposals/blob/master/nep-17.mediawiki) contracts. Nep17 contract methods are as follows:

| Method | Parameters | Fee in GAS | Result |
| ---- | ---- | ---- | ---- |
| [`symbol`](govapi/symbol.md)  | null | 0 | Token symbol in String |
|  [`decimals`](govapi/decimals.md)  | null | 0 | Token decimals in UInt |
| [`TotalSupply`](scapi/fw/dotnet/neo/Neo/TotalSupply.md) | null | 0.00032768 (CpuFee) | Token total supply in BigInteger |
| [`BalanceOf`](scapi/fw/dotnet/neo/Neo/BalanceOf.md) | UInt160 account | 0.00032768 (CpuFee) | account balance in BigInteger |
| [`Transfer`](scapi/fw/dotnet/neo/Neo/Transfer.md) | UInt160 from, UInt160 to, BigInteger amount | 0.00131072 (CpuFee) + 0.0000005 (StorageFee) | Send specified amount of token from Address *from* to Address *to*. Please note that it will check *from*'s signature, whether caller is *from*, whether *to* is payable, whether *from*'s balance is enough |

Contract methods by NEO:

| Method | Parameters | Fee in GAS | Return value |
| ---- | ------------------------------------ | ---- | ---- |
| [`UnclaimedGas`](scapi/fw/dotnet/neo/Neo/UnclaimedGas.md) | UInt160 account | 0.00131072 (CpuFee) | unclaimed GAS amount of this address in uint |
