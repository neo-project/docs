# GAS Class

Provides a series of attributes and methods of the native contract GasToken, which contract hash is `0x70e2301955bf1e74cbb31d18c2f96972abadb328`.

GasToken is also an NEP-17 contract, which inherits all properties and methods of an NEP-17 contract. 

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

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

| Name                                                         | Description                  |
| ------------------------------------------------------------ | ---------------------------- |
| [TotalSupply()](Gas/TotalSupply.md)                          | Gets the total supply of GAS |
| [BalanceOf(UInt160 account)](Gas/BalanceOf.md)               | Gets the balance             |
| [Transfer(UInt160 from, UInt160 to, BigInteger amount)](Gas/Transfer.md) | Transfers GAS                |