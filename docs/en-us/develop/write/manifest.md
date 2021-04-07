# NEF and Manifest Files

Neo N3 uses the NEF (NEO Executable Format) and Manifest files as a replacement of the AVM and ABI files in Neo Legacy.

When a contract is compiled successfully, the compiler generates both the NEF file and Manifest file. These two files are also needed when you deploy a contract or upgrade a contract.

## NEF

The NEF file includes the following fields.


| Field    | Type          | Comment                                                 |
| -------- | ------------- | ------------------------------------------------------- |
| Magic    | uint32        | The Magic value of the blockchain.                      |
| Compiler | byte[64]      | Compiler name and version                               |
| Reserve  | byte[2]       | The field reserved for future extensions. It must be 0. |
| Tokens   | MethodToken[] | Method tokens.                                          |
| Reserve  | byte[2]       | The field reserved for future extensions. It must be 0. |
| Script   | Byte[]        | The contract script                                     |
| Checksum | uint32        | The first four bytes after two-time SHA256 hashed       |

## Manifest

Before deploying the contract, you need to explicitly declare the contract functions and permissions in the manifest file, which affects the contract behavior when running.

The Manifest file includes the following fields.

| Field              | Type                                                         | Comment                                                      |
| ------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| Name               | string                                                       | Contract name                                                |
| Groups             | ContractGroup[]<br>Consisting of a public key and a signature on the contract hash | Defines a group of trusted contracts. Contracts in a group trusts each other and can be invoked by each other,  without prompting the user any warnings. For example, a series of contracts that call each other for a DeFi project. <br/>A group is identified by a public key and must has a signature for the contract hash to prove that the contract is included in the group. |
| SupportedStandards | string[]                                                     | Supported NEP standard, equivalent to NEP-10 in Neo Legacy.x      |
| Abi                | ContractAbi                                                  | NEP-14 (NeoContract ABI)<br>Description of smart contract methods (name, parameters, return value, offset, safe or not), events (name, parameters) |
| Permissions        | ContractPermission[]<br>Consisting of the contract and its method names | This field is an array containing a permission object, which defines other contracts and methods that the contract wants to call. The contract can be ScriptHash, Group, or wildcard *. The method is the method name or wildcard *. Contracts or methods not declared in the manifest cannot be called by the contract. |
| Trusts             | WildcardContainer\<UInt160>                                  | Defines other contracts trusted by the contract. The contract can be ScriptHash, Group, or wildcard *. If a contract is trusted, the user will not receive any warning message when the contract is called. |
| Extra              | object                                                       | Other user-defined data, such as developer, email, URL, contract profile, etc. |

