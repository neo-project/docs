# ContractManagement Class

Provides a series methods of the native contract `ContractManagement`. The contract hash is `0xa501d7d7d10983673b61b7a2d3a813b36f9f0e43`.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

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
| [GetContract(UInt160 hash)](ContractManagement/GetContract.md) | Gets the contract based on the given contract hash |
| [Deploy(byte[] nefFile, string manifest)](ContractManagement/Deploy.md) | Deploys the contract                               |
| [Update(byte[] nefFile, string manifest)](ContractManagement/Update.md) | Updates the contract                               |
| [Destroy()](ContractManagement/Destroy.md)                   | Destroys the contract                              |

