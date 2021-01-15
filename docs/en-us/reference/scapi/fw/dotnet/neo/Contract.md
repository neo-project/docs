# Contract Class

The class representing a contract.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Contract
```

## Attributes

| Name | Description |
| -------------------------------- | ------ |
| Id     | Contract Id     |
| UpdateCounter | Contract update counter |
| Hash  | Contract hash |
| Script  | Contract script array |
| Manifest  | Json strings that represents the contract Manifest |

## Methods

| Name | Description |
| -------------------------------- | ------ |
| [Call(UInt160 scriptHash, string method, object[] arguments)](Contract/Call.md) | Invokes the contract |
| [CallEx(UInt160 scriptHash, string method, object[] arguments, CallFlags flag)](Contract/CallEx.md) | Invokes the contract based on CallFlags |
| [GetCallFlags()](Contract/GetCallFlags.md)         | Gets the CallFlag of the contract |
| [CreateStandardAccount()](Contract/CreateStandardAccount.md)         | Creates a standard account with public key |

## Constructor

The Contract object can be constructed through [Blockchain.GetContract(UInt60 hash) script_hash](ManagementContract/GetContract.md).

[Deploy(byte [] nefFile, string manifest)](ManagementContract/Deploy.md) publishes the contract onto the blockchain and returns a Contract object.

