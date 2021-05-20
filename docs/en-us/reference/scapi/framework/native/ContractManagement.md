# ContractManagement Class

Provides a series of methods for the native contract `ContractManagement`, which contract hash is `0xfffdc93764dbaddd97c48f252a53ea4643faa3fd`.

Namespace: [Neo.SmartContract.Framework.Native](../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class ContractManagement
```

## Attributes

| Name | Description   |
| ---- | ------------- |
| Hash | Contract hash |

## Methods

| Name                                                         | Description                                        |
| ------------------------------------------------------------ | -------------------------------------------------- |
| GetMinimumDeploymentFee()                                    | Gets the minimum fee of contract deployment        |
| [GetContract(UInt160 hash)](ContractManagement/GetContract.md) | Gets the contract based on the given contract hash |
| [Deploy(byte[] nefFile, string manifest)](ContractManagement/Deploy.md) | Deploys the contract                               |
| [Update(byte[] nefFile, string manifest)](ContractManagement/Update.md) | Updates the contract                               |
| [Destroy()](ContractManagement/Destroy.md)                   | Destroys the contract                              |

