# GAS Class

Provides a series of attributes and methods of the native contract `GasToken`, which contract hash is `0xd2a4cff31913016155e38e474a2c06d08be276cf`.

GasToken is also an NEP-17 contract, which inherits all properties and methods of an NEP-17 contract. 

Namespace：[Neo.SmartContract.Framework.Native](../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class GAS
```

## Attributes

| Name          | Description                                              |
| ----------------- | ------------------------------------------------------------ |
| Hash           | Gets the contract hash                  |
| Symbol           | Gets the symbol, gas                            |
| Decimals          | Gets decimals                   |

## Methods

| Name                                                         | Description                             |
| ------------------------------------------------------------ | --------------------------------------- |
| [TotalSupply()](Gas/TotalSupply.md)                          | Gets the total supply of GAS            |
| [BalanceOf(UInt160 account)](Gas/BalanceOf.md)               | Gets the balance                        |
| [Transfer(UInt160 from, UInt160 to, BigInteger amount, object data = null)](Gas/Transfer.md) | Transfers GAS                           |
| Refuel                                                       | Refuel (adding fees) for smart contract |