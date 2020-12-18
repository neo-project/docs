# GAS Class

Provides a series of attributes and methods of the native contract GasToken, which contract hash is 0x36a019d836d964c438c573f78badf79b9e7eebdd.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class GAS
```

## Attributes

| Name          | Description                                              |
| ----------------- | ------------------------------------------------------------ |
| Name              | Gets the name, GAS                                |
| Symbol           | Gets the symbol, gas                            |
| Decimals          | Gets decimals                   |

## Methods

| Name                                                         | Description                  |
| ------------------------------------------------------------ | ---------------------------- |
| [TotalSupply()](Gas/TotalSupply.md)                          | Gets the total supply of GAS |
| [BalanceOf(UInt160 account)](Gas/BalanceOf.md)               | Gets the balance             |
| [Transfer(UInt160 from, UInt160 to, BigInteger amount)](Gas/Transfer.md) | Transfers GAS                |