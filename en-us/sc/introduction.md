# AntShares smart contract introduction

## What is a smart contract?

A smart contract is a set of commitments that are defined in digital form, including the agreement that the contractor can perform on these commitments. Blockchain technology gives us a decentralized, non-tampering, highly reliable system in which smart contracts are very useful. Smart contracts are one of the most important characteristics of the blockchain, and also why the blockchain can be called disruptive technology.

## What are the characteristics of AntShares smart contracts?

The AntShares Smart Contract 2.0 includes the following features: certainty, high performance, and expandability. The contract types include: validation contracts, function contracts, and application contracts.

From the performance point of view, AntShares uses the lightweight AVM (AntShares Virtual Machine) as its intelligent contract execution environment, it starts very fast and takes up a small amount of resources, suitable for smart contracts such as short procedures. Static compilation and caching of hotspot contracts can be significantly enhanced by JIT (real-time compiler) technology. The instructional setup of the AntShares virtual machine provides a series of cryptographic instructions to optimize the execution efficiency of cryptographic algorithms in smart contracts. In addition, data manipulation instructions provide support for arrays and complex data structures directly, which will enhance performance.

Smart contract 2.0 achieves a scalable approach through a combination of high concurrency and dynamic partitioning, combined with its low-coupling design. The low coupling contract procedure is executed in a virtual machine (AntShares virtual machine) and communicates with the outside through the interactive service layer. Therefore, the vast majority of upgrades to the smart contract function can be achieved through API of the interactive service layer.

## Write an intelligence contract across many languages

From the language point of view, the difference between AntShares and Ethereum is more intuitive: unlike the original Solidity language in Ethereum, the AntShares contract can be used directly by almost any high-level programming language. The first supported languages ​​are C#, VB.Net, F#, and so on. AntShares provides compilers and plug-ins for these languages, which are used to compile high-level languages ​​into instruction sets supported by AntShares virtual machines. The first compiler will be for MSIL (Microsoft intermediate language), so any .Net language that can be translated into MSIL will be immediately supported.

Antshares also provides compilers and plug-ins which are used to compile high-level languages into instruction sets supported by the ant virtual machine. The compiler uses MSIL (Microsoft intermediate language) to compile, so theoretically any .Net language that can be translated into MSIL language can be directly supported.

The languages that are currently supported are:

1) C#, VB.Net, F#
2) Java, Kotlin

The advanced language that we plan to support include:

1) C, C ++, GO
2) Python, JavaScript

Our goal is that developers do not need to learn a new language to participate in the development of an AntShares smart contract. Existing business system code might even be directly ported to the blockchain. We envision that this will greatly increase the overall popularity of the future blockchain.

Usually smart contracts are difficult to debug and test given lack of tool support. AntShares will provide support for debugging at the AVM level, making it easier to develop these contracts.