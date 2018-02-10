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
