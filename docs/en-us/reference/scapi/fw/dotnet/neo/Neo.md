# Neo Class

Provides a series of attributes and methods of the native contract NeoToken.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

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
| [BalanceOf(byte\[\] account)](Neo/BalanceOf.md)              | Gets the balance                                |
| [Transfer(byte\[\] from, byte\[\] to, BigInteger amount)](Neo/Transfer.md) | Transfers NEO                                   |
| [SetGasPerBlock(BigInteger gasPerBlock)](Neo/SetGasPerBlock.md) | Sets the number of GAS generated for each block |
| [GetGasPerBlock()](Neo/GetGasPerBlock.md)                    | Gets the number of GAS generated for each block |
| [UnclaimedGas(byte\[\] account, uint end)](Neo/UnclaimedGas.md) | Gets the number of unclaimed GAS                |
| [RegisterCandidate(byte\[\] pubkey)](Neo/RegisterCandidate.md) | Registers as a candidate                        |
| [UnRegisterCandidate(byte\[\] pubkey)](Neo/UnRegisterCandidate.md) | Unregisters as a candidate                      |
| [Vote(byte\[\] account, byte\[\] voteTo)](Neo/Vote.md)       | Votes for candidates                            |
| [GetCandidates()](Neo/GetCandidates.md)                      | Gets candidates list                            |
| [GetCommittee()](Neo/GetCommittee.md)                        | Gets committee members list                     |
| [GetNextBlockValidators()](Neo/GetNextBlockValidators.md)    | Gets validators list for the next block         |
