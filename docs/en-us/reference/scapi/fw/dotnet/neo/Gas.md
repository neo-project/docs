# GAS Class

Provides a series of attributes and methods of the native contract GasToken.

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
| [BalanceOf(byte\[\] account)](Gas/BalanceOf.md)              | Gets the balance             |
| [Transfer(byte\[\] from, byte\[\] to, BigInteger amount)](Gas/Transfer.md) | Transfers GAS                |