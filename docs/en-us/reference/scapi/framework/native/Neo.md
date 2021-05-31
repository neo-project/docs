# Neo Class

Provides a series of attributes and methods of the native contract NeoToken, which contract hash is `0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5`.

NeoToken is also an NEP-17 contract that inherits all NEP-17 specific attributes and methods.

Namespace：[Neo.SmartContract.Framework.Native](../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class NEO
```

## Attributes

| Name          | Description                                              |
| ----------------- | ------------------------------------------------------------ |
| Name              | Gets the name, NEO   |
| Symbol           | Gets the symbol, neo |
| Decimals          | Gets decimals                      |

## Methods

| Name                                                         | Description                                     |
| ------------------------------------------------------------ | ----------------------------------------------- |
| [TotalSupply()](Neo/TotalSupply.md)                          | Gets the total supply of NEO                    |
| [BalanceOf(UInt160 account)](Neo/BalanceOf.md)               | Gets the balance                                |
| [Transfer(UInt160 from, UInt160 to, BigInteger amount, object data = null)](Neo/Transfer.md) | Transfers NEO                                   |
| [GetGasPerBlock()](Neo/GetGasPerBlock.md)                    | Gets the number of GAS generated for each block |
| [UnclaimedGas(UInt160 account, uint end)](Neo/UnclaimedGas.md) | Gets the number of unclaimed GAS                |
| [RegisterCandidate(ECPoint pubkey)](Neo/RegisterCandidate.md) | Registers as a candidate                        |
| [UnRegisterCandidate(ECPoint pubkey)](Neo/UnRegisterCandidate.md) | Unregisters as a candidate                      |
| [Vote(UInt160 account, ECPoint voteTo)](Neo/Vote.md)         | Votes for candidates                            |
| [GetCandidates()](Neo/GetCandidates.md)                      | Gets candidates list                            |
| [GetCommittee()](Neo/GetCommittee.md)                        | Gets committee members list                     |
| [GetNextBlockValidators()](Neo/GetNextBlockValidators.md)    | Gets validators list for the next block         |
| [GetAccountState(DataCache snapshot, UInt160 account)](Neo/GetAccountState.md) | Gets the latest votes of the specified  account |

