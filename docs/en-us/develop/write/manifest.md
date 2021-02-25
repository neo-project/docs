# NEF and Manifest files

Use the NEF (NEO Executable Format) file in Neo 3 to replace and expand the AVM file of Neo 2.

Use the Manifest file to replace and expand the ABI file of Neo 2.

When a contract is compiled successfully, the compiler generates both the NEF file and the Manifest file. These two files are also needed when you deploy a contract or upgrade a contract.

## NEF

The NEF file includes the following fields.


| Field    | Type          | Comment                                    |
| -------- | ------------- | ------------------------------------------ |
| Magic    | uint32        | Magic header                               |
| Compiler | byte[64]      | Compiler name and version                  |
| Reserve  | byte[2]       | Reserved for future extensions. Must be 0. |
| Tokens   | MethodToken[] | Method tokens.                             |
| Reserve  | byte[2]       | Reserved for future extensions. Must be 0. |
| Script   | Byte[]        | Var bytes for the payload                  |
| Checksum | uint32        | First four bytes of double SHA256 hash     |

## Manifest

When a smart contract is deployed, it must explicitly declare the features and permissions it will use.
When it is running, it will be limited by its declared list of features and permissions, and cannot make any behavior beyond the scope of the list.

The Manifest file includes the following fields.

| Field              | Type                                                         | Comment                                                      |
| ------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| Name               | string                                                       | Contract name                                                |
| Groups             | ContractGroup[]<br>Consists of a public key and a signature on the contract hash | A group represents a set of mutually trusted contracts. A contract will trust and allow any contract in the same group to invoke it, and the user interface will not give any warnings.<br>A group is identified by a public key and must be accompanied by a signature for the contract hash to prove that the contract is indeed included in the group.<br>Example: A series of contracts that call each other for a DeFi project. |
| SupportedStandards | string[]                                                     | Supported NEP standard, equivalent to NEP-10 in Neo 2.x      |
| Abi                | ContractAbi                                                  | NEP-14 (NeoContract ABI)<br>Description of smart contract methods (name, parameters, return value, offset, safe or not), events (name, parameters) |
| Permissions        | ContractPermission[]<br>由合约和方法名组成                   | The permissions field is an array containing a set of Permission objects. It describes which contracts may be invoked and which methods are called.<br>where the contract can be a ScriptHash, a Group, or a wildcard *<br>method is a method name or wildcard *<br>If a contract invokes a contract or method that is not declared in the manifest at runtime, the invocation will fail. |
| Trusts             | WildcardContainer\<UInt160>                                  | The trusts field is an array containing a set of contract hashes or group public keys. It can also be assigned with a wildcard *. If it is a wildcard *, then it means that it trusts any contract.<br>If a contract is trusted, the user interface will not give any warnings when called by the contract. |
| Extra              | object                                                       | Other user-defined data, such as developer, email, URL, contract profile, etc. |

