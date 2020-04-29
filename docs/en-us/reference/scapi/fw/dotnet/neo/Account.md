# Account Class

The class that represents the account, providing a way to query the balance. The account here refers to the hash of a contract script which corresponds to an address on the blockchain.

Common types of accounts are:

- Standard account: the account created as you create a new wallet or new address. 

- Multi-party signed account: the multi-party signed address consists of a set of public keys and a minimum number of signatures. For example, a 2 of 3 account means that the account is managed by 3 people and the transfer can be authorized when 2 people sign at the same time.


Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Account
```

## Methods

| Name | Description |
| ---------------------------------------- | ------------------ |
| [IsStandard(byte[] scripthash)](Account/IsStandard.md) | Verifies if the contract is a standard account according to its scripthash (unilateral signature account) |


