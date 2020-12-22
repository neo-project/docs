# Contract Class

The class representing a contract.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Contract
```

## Attributes

| Name | description |
| ---------------------------- | ---------- |
| Script | Returns the scripthash of the contract |
| HasStorage | Whether the contract contains the storage |
| IsPayable | Whether the contract is able to accept assets |

A standard nep-5 asset verifies the IsPayable function of the deposit address in the transfer method to determine whether the transfer can be performed.

## Methods

| Name | Description |
| -------------------------------- | ------ |
| [Call(byte[\] scriptHash, string method, object[] arguments)](Contract/Call.md) | Invokes the contract |
| [CallEx(byte[\] scriptHash, string method, object[] arguments, CallFlags flag)](Contract/CallEx.md) | Invokes the contract by call privilege flag |
| [Create(byte[] script, string manifest)](Contract/Create.md) | Creates a contract |
| [Update(byte[] script, string manifest)](Contract/Update.md) | Updates the contract |
| [Destroy()](Contract/Destroy.md)         | Destroys the contract    |
| [GetCallFlags()](Contract/GetCallFlags.md)         | Gets the privilege flag of the contract |
| [CreateStandardAccount()](Contract/CreateStandardAccount.md)         | Creates a standard account with public key |

## Constructor

The Contract object can be constructed through [Blockchain.GetContract(byte[]) script_hash](Blockchain/GetContract.md).

[Create(byte [] script, string manifest)](Contract/Create.md) publishes the contract onto the blockchain and returns a Contract object.