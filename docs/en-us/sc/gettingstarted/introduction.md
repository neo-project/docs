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
- GO
- JavaScript

The languages that we plan to support include:

- C, C++


With multiple-language support, more than 90% of developers can directly participate in the development of an NEO smart contract without the need to learn a new language. Existing business system code might even be directly ported to the blockchain. We envision that this will greatly increase the overall popularity of the future blockchain.

Additionally, traditional smart contracts are difficult to debug and test given lack of tool supports and access to clear instructions. NEO, however, provides major support for debugging at the NEO virtual machine level, allowing you to develop NEO Smart Contract 2.0 both easier and faster. If you need TestNet GAS, feel free to ask openly and it will be provided for development purposes.

## Smart contract triggers

There are two ways to trigger smart contracts:

1. Contract User Authentication: Here the smart contract is a contract account. When the user requests to use the contract account in an asset, it will trigger the smart contract.
2. Manually call a smart contract: Here the user sends a transaction (Invocation Transaction) to trigger the implementation of a smart contract.

## NeoVM

NeoVM is the virtual machine that executes the NEO smart contract code. We are talking about the concept of virtual machine in the narrow sense, not in reference to operating systems or programs that can simulate them such as VMware or Hyper-V.

For example, in the Java JVM or .NET CLR, source code will be compiled into the relevant bytecode and then run on the corresponding virtual machine. The JVM or CLR will run the bytecode, which is similar to running instructions on a real physical machine. Notably, the corresponding binary instructions are still run on a physical machine. The physical machine fetches instructions from memory, transfers it to the CPU via the bus, then decodes, executes, and stores the result.

## Charging Model

A smart contract can be programmed to charge a certain fee, divided into deployment costs and execution costs.

Deployment costs refers to the need for a developer to pay a fee to deploy a smart contract on the block chain (100~1000 GAS). Execution costs refers to the fee the user pays for execution of the smart contract. All operations have a costs, with most operations defaulting to 0.001 GAS. The first 10 GAS is free. Priority processing can be achieved by manually increasing the execution fee. Read more about smart contract fees [here](../fees.md).

## Some simple smart contracts (C#)

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

[Hello World](../sample/HelloWorld.md)

[Lock (lock)](../sample/lock2.md)

[Domain (Domain Name System)](../sample/Domain.md)

