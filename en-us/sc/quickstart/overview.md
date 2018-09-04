# Quick Start

## Compiling smart contracts

We currently recommend C# for developing smart contracts, though we also support Java, Kotlin, Python and plan to support Go, C/C++, JavaScript, and other programming languages.

### Environment

Depending on the programming language and system you use, refer to one of the following to set up your compiling environment：

- [How to use C# to write a NEO smart contract](getting-started-csharp.md)
- [How to write smart contracts in C# on macOS](getting-started-csharp-mac.md)
- [How to write smart contracts in C# on ubuntu](getting-started-csharp-ubuntu.md)
- [How to use Java to write a NEO smart contract](getting-started-java.md)
- [How to use Python to write a NEO smart contract](getting-started-python.md)

### Development dependencies

NEO smart contract development does not support any third-party libraries. Only a small part of the programming languages' own class libraries can be used.

Only the NEO-SmartContract-DevPack dependency library can be used to develop NEO smart contracts. For more information refer to [Smart Contract Framework](../reference/fw.md).

### Generating the .avm file

The NEO smart contract generates NEOVM bytecodes in .avm format. Different generation schemes are provided for different programming languages.

## Unit testing

After the contract is compiled, you can use the NEO-CLI `invokescript` method and the testing tool Postman to do a unit test. For more information, refer to [Unit Testing](test.md).

## Deploying smart contracts

When a smart contract is deployed on the blockchain, it can be used by other users or invoked by other contracts.

#### Which smart contracts need to be deployed?

When a smart contract will be invoked by another smart contract (called appcall), it needs to be deployed. Contracts triggered only by the verification trigger, such as the lock contract and multi-signature contract, do not need to be deployed as they will not be invoked by other contracts. Contracts such as "Return 1+1" do not need to be deployed as they do not require any input parameters.

From the programming language perspective, only when a smart contract will be used as a class library, it needs to be deployed. For example: 

- When a smart contract has variable incoming parameters, it must serve as a storage. The caller (Invocation transaction) or other smart contracts provide the parameters.
- When a smart contract uses storage and dynamic calls it must serve as a class library.
- When a smart contract implements NEP-5 standard assets, the contract needs to be deployed on the blockchain.

#### How to deploy?

Smart contracts are deployed by invoking API through an Invocation transaction (The Publish transaction for deployment of the old version system has been deprecated). We recommend you use NEO-GUI to deploy smart contracts. For more information, refer to [Depolying and Invoking Smart Contracts](deploy-invoke.md).

Deploying and invoking smart contracts will cost fees. For more information, refer to [System Fees](../systemfees.md).

## Invoking smart contracts

With regard to invoking smart contracts, here we refer in particular to smart contracts that serve as class libraries. For more information, refer to [Depolying and Invoking Smart Contracts](deploy-invoke.md).
