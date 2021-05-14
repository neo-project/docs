# Contract Class

The class representing a contract.

Namespace：[Neo.SmartContract.Framework.Services](../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Contract
```

## Attributes

| Name | Description |
| -------------------------------- | ------ |
| Id     | Contract Id. The native contract ID is a negative integer, and the normal contract ID is a positive integer. |
| UpdateCounter | Contract update counter |
| Hash  | Contract hash, which is determined by the deployer's script hash, the contract NEF checkcode, and the contract name. |
| Nef | Nef |
| Manifest  | Json strings that represents the contract Manifest |

## Methods

| Name | Description |
| -------------------------------- | ------ |
| [Call(UInt160 scriptHash, string method, object[] arguments)](Contract/Call.md) | Invokes the contract |
| [GetCallFlags()](Contract/GetCallFlags.md)         | Gets the CallFlag of the contract |
| [CreateStandardAccount()](Contract/CreateStandardAccount.md)         | Generate a script hash of standard account with public key |
| CreateMultisigAccount(int, params Cryptography.ECC.ECPoint[]) | Generate a script hash of multi-signature accounts based on the public key list and minimum number of signatures |

## Constructor

The Contract object can be constructed through [ContractManagement.GetContract(UInt60 hash)](../native/ContractManagement/GetContract.md).

 [ContractManagement.Deploy(byte[] nefFile, string manifest)](../native/ContractManagement/Deploy.md) publishes the contract onto the blockchain and returns a contract object.

