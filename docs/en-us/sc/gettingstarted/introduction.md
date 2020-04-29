# Neo Smart Contract Introduction

## What is a smart contract?

A smart contract is a set of commitments which are defined in digital form, including the agreement on how contract participants shall fulfill these commitments. Blockchain technology gives us a decentralized, immutable, highly reliable system in which smart contracts are extremely useful. Smart contracts is one of the most important characteristics of blockchain technologies and the reason why blockchains can be called disruptive technology.

## What are the characteristics of Neo smart contracts?

Neo Smart Contract 2.0 includes the following features: certainty, high performance, and expandability. 

From the performance point of view, Neo uses the lightweight NeoVM (Neo Virtual Machine) as its intelligent contract execution environment. It starts very fast and occupies a small amount of resources and is suitable for short procedures like smart contracts. Static compilation and caching of hotspot contracts can be significantly enhanced by JIT (real-time compiler) technology. The instruction set of the Neo virtual machine includes a series of cryptographic instructions to optimize the execution efficiency of cryptographic algorithms in smart contracts. In addition, data manipulation instructions provide direct support for arrays and complex data structures. All of the above will enhance the execution performance for Neo Smart Contract 2.0.

Neo Smart Contract 2.0 improves its scalability through a combination of high concurrency and dynamic partitioning, along with its low coupling design. The low coupling contract procedure is executed in a virtual machine (Neo virtual machine) and communicates with the outside through the interactive service layer. Therefore, the majority of the smart contract function upgrades can be achieved through API of the interactive service layer.

## Write smart contracts in any language

From the language point of view, the difference between Neo Smart Contract 2.0 and Ethereum is more intuitive: unlike the original Solidity language in Ethereum, the Neo smart contract can be created directly in almost any high-level programming language. The first supported languages ​​are C#, VB.Net, F#, Java, and Kotlin. Neo provides compilers and plugins for these languages, which are used to compile high-level languages ​​into instruction sets supported by Neo virtual machines. The compiler is working on MSIL (Microsoft intermediate language), so theoretically any .Net language and any language that can be translated into MSIL will be immediately supported.

The languages that are currently supported are:

- C#, VB.Net, F#
- Java, Kotlin
- Python
- GO
- JavaScript

The languages that we plan to support include:

- C, C++

With multiple-language support, more than 90% of developers can directly participate in the development of Neo smart contracts without the need to learn a new language. Existing business system codes may even be directly migrated to the blockchain, which will greatly increase the overall popularity of the blockchain in the near future.

Additionally, traditional smart contracts are difficult to debug and test given lack of tool supports and access to clear instructions. Neo, however, provides major support for debugging at the Neo virtual machine level, allowing you to develop Neo Smart Contract 2.0 both easier and faster.

## Smart contract triggers

Neo Smart Contract 2.0 include four types of triggers: System Trigger, Verification Trigger, Application Trigger, and All Trigger (containing the first three types). The commonly used types are Verification Trigger and Application Trigger.

The above two trigger types determine the two ways to trigger smart contracts:

1. The verification trigger indicates that the contract is being invoked as a verification function. The verification function can accept multiple parameters, and should return a boolean value that indicates the validity of the transaction or block. For example, Contract User Authentication: Here the smart contract is used as a contract account. When the user requests to use an asset in the account, the smart contract will be invoked to validate the user.
2. The application trigger indicates that the contract is being invoked as an application function. The application function can accept multiple parameters, change the states of the blockchain, and return any type of value. For example, Manually call a smart contract: Here the user sends a transaction and the transaction includes the script to trigger the smart contract.

A smart contract can support multiple trigger types. Since the contract triggered by verification is executed before the transaction is finally generated, if the contract returns false or throws any exception, the transaction generation will fail. For a contract triggered by a transaction, it's invoked after the transaction is added into the block, so no matter what the contract returns and whether it executes successfully or not, the transaction is already made.

## NeoVM

NeoVM is the virtual machine that executes the Neo smart contract code. The concept of virtual machine here is in a more narrow scope. It's not a simulation of a physical machine under the assistance of the operating system, like VMware or Hyper-V. It's a virtual machine for a specific kind of machine code.

For example, in JVM or .NET CLR, source code will be compiled into the relevant bytecode and then run on the corresponding virtual machine. The JVM or CLR will run the bytecode, which is similar to running instructions on a real physical machine. Notably, the corresponding binary instructions are still run on a physical machine. The physical machine fetches instructions from memory, transfers it to the CPU via the bus, then decodes, executes, and stores the result. For more infomation, refer to [NeoVM Instructions](../../reference/neo_vm.md).

## Charging Model

A smart contract can be programmed to charge a certain amount of fee, including deployment costs and execution costs.

Deployment costs refers to the fee which a developer needs to pay to deploy a smart contract on the block chain (100~1000 GAS). Execution costs refers to the fee the user pays for execution of the smart contract. All operations have a costs, with most operations defaulting to 0.001 GAS. The first 10 GAS is free. Priority processing can be achieved by manually increasing the execution fee. For more information, refer to [Smart Contract Fees](../fees.md).

## Some simple smart contracts (C#)

Here are some simple smart contracts:

```c#
public static bool Main ()
{
    return true;
}
```

Here the return value of the contract is always true, indicating that anyone can spend the assets under this contract address (this can be interpreted as giving away money).

The Neo wallet client has a function for deleting an asset. When you delete an asset, the asset is sent to a specified address being the contract address generated by the above smart contract. Anyone can spend the assets in the address. The assets in the address are assets that others do not want.

```c#
public static bool Main ()
{
    return false
}
```

The return value of the contract is always `false`, indicating that the assets of this contract can not be used (this can be interpreted as burning or destroying an asset). For example, the above contract can be used to store shares of a company which has been unregistered.
