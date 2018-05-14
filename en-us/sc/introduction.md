# NEO Smart Contract Introduction

## What is a smart contract?

A smart contract is a set of commitments that are defined in digital form, including the agreement on how contract participants shall fulfill these commitments. Blockchain technology gives us a decentralized, non-tampering, highly reliable system in which smart contracts are extremely useful. Smart contracts is one of the most important characteristics of blockchain technologies and the reason why blockchains can be called disruptive technology. It is increasing the efficiency of our social structure by each passing day.

## What are the characteristics of NEO smart contracts?

The NEO Smart Contract 2.0 includes the following features: certainty, high performance, and expandability. The contract types include: validation contracts, function contracts, and application contracts.

From the performance point of view, NEO uses the lightweight NeoVM (NEO Virtual Machine) as its intelligent contract execution environment. It starts very fast and takes up a small amount of resources and is suitable for smart contracts such as short procedures. Static compilation and caching of hotspot contracts can be significantly enhanced by JIT (real-time compiler) technology. The instructional setup of the NEO virtual machine provides a series of cryptographic instructions to optimize the execution efficiency of cryptographic algorithms in smart contracts. In addition, data manipulation instructions provide support for arrays and complex data structures directly. All of the above will enhance performance in NEO Smart Contract 2.0.

NEO Smart Contract 2.0 achieves a scalable approach through a combination of high concurrency and dynamic partitioning, combined with its low-coupling design. The low coupling contract procedure is executed in a virtual machine (NEO virtual machine) and communicates with the outside through the interactive service layer. Therefore, the vast majority of upgrades to the smart contract function can be achieved through API of the interactive service layer.

## Write smart contracts in any language

From the language point of view, the difference between NEO Smart Contract 2.0 and Ethereum is more intuitive: unlike the original Solidity language in Ethereum, the NEO smart contract can be used directly by almost any high-level programming language. The first supported languages ​​are C#, VB.Net, F#, Java, and Kotlin. NEO provides compilers and plug-ins for these languages, which are used to compile high-level languages ​​into instruction sets supported by NEO virtual machines. The first compiler will be for MSIL (Microsoft intermediate language), so theoretically any .Net language and any language that can be translated into MSIL will be immediately supported.

The languages that are currently supported are:

- C#, VB.Net, F#

- Java, Kotlin
- Python

The languages that we plan to support include:

- C, C++, Golang

- JavaScript

With multiple-language support, more than 90% of developers can directly participate in the development of an NEO smart contract without the need to learn a new language. Existing business system code might even be directly ported to the blockchain. We envision that this will greatly increase the overall popularity of the future blockchain.

Additionally, traditional smart contracts are difficult to debug and test given lack of tool supports and access to clear instructions. NEO, however, provides major support for debugging at the NEO virtual machine level, allowing you to develop NEO Smart Contract 2.0 both easier and faster. If you need TestNet GAS, feel free to ask openly and it will be provided for development purposes.

## Smart contract triggers

There are two ways to trigger smart contracts:

1. Contract User Authentication: Here the smart contract is a contract account. When the user requests to use the contract account in an asset, it will trigger the smart contract.
2. Manually call a smart contract: Here the user sends a transaction (Invocation Transaction) to trigger the implementation of a smart contract.

## NeoVM

NeoVM is the virtual machine that executes the NEO smart contract code. We are talking about the concept of virtual machine in the narrow sense, not in reference to operating systems or programs that can simulate them such as VMware or Hyper-V.

For example, in the Java JVM or .NET CLR, source code will be compiled into the relevant bytecode and then run on the corresponding virtual machine. The JVM or CLR will run the bytecode, which is similar to running instructions on a real physical machine. Notably, the corresponding binary instructions are still run on a physical machine. The physical machine fetches instructions from memory, transfers it to the CPU via the bus, then decodes, executes, and stores the result.

### Virtual machine architecture

![neo-vm](../../assets/neo-vm.jpg)

The above diagram is the system architecture diagram of the Neo Virtual Machine (NeoVM), where the deployment in the dashed box is the core of the virtual machine.

#### Execution engine

The green on the left is the Virtual Machine execution engine (the equivalent of the CPU). It can execute common instructions such as flow control, stack operations, bit operations, arithmetic operations, logical operations, cryptographic methods, and so on. It can interact with the Interoperable service layer (described below) through system calls.

#### Evaluation stack

The middle gray part of the the virtual machine is the Evaluation Stack (it is equivalent to memory). These days there are two ways to achieve a virtual machine 1) stack based and 2) register based. Both ways have their own advantages and disadvantages, and both have their own great implementation examples. There are stack-based virtual machines like JVM, CPython, and the .NET CLR. On the other side there are register-based VMs, such as Dalvik and Lua5.0. Stack-based virtual machines have a computing stack concept that allows virtual machines to interact directly with the stack (Evaluation Stack) when performing real operations.

Since the default behavior of a stack based VM is to fetch data from the operand stack, there is no need to specify an operand. Contrast this to for example the following x86 assembly `"ADD EAX, EBX"`. This operation requires you to specify the source operands and destination of the result. Stack-based virtual machine instructions do not need to specify these parameters. For example, the addition of a simple "ADD" operation will operate directly on the operand stack. The data can be popped of directly and the result is stored at the stop of the stack.

#### Interoperable service layer

The blue part on the right side is the interoperable service layer of the virtual machine (equivalent to the peripherals). At present, the interoperable service layer provides some APIs for accessing the chain-chain data of the smart contract. It can access block information, transaction information, contract information, asset information, and so on.

In addition, the interoperable service layer also provides a persistent storage area for each contract. Each of the smart contracts is optionally created with private storage, which is in the form of a key-value object determined by the callee of the contract rather than the context of the persistent store. The caller needs to pass their own storage context to the callee (to complete the authorization) before the caller can perform read and write operations.

### Charge mode

A smart contract can be programmed to charge a certain fee, divided into deployment costs and execution costs.

Deployment costs refers to the need for a developer to pay a fee to deploy a smart contract on the block chain (currently 500 GAS). Execution costs refers to the fee the user pays for execution of the smart contract. All operations have a costs, with most operations defaulting to 0.001 GAS. The first 10 GAS is free. Priority processing can be achieved by manually increasing the execution fee. Read more about smart contract fees [here](systemfees.md#smart-contract-fees).

## A simple smart contract

Here are some simple smart contracts:

```c#
public static bool Main ()
{
    return true;
}
```

Here the return value of the contract is always true, indicating that anyone can spend the contract address of the assets (can be understood as money).

The NEO wallet client has a function for deleting an asset. When you delete an asset, the asset is sent to a specified address being the contract address generated by the above smart contract. Anyone can spend the assets in the address. The assets in the address are assets that others do not want.

```c#
public static bool Main ()
{
    return false
}
```

The return value of the contract is always `false`, indicating that the assets of this contract can not be used (this can be interpreted as burning or destroying an asset). Such a contract can for example be applied for shares of a company that have  been written off/canceled.

For more examples please see:

[Hello World](tutorial/HelloWorld.md)

[Lock (lock)](tutorial/lock.md)

[Domain (Domain Name System)](tutorial/Domain.md)
