# Ants smart contract 2.0 white paper

### 📖 The document is being edited

📖 The documentation is a work in progress. You can view other documents on [Github wiki](https://github.com/AntShares/AntShares/wiki/) or visit our [official website](Http://www.antshares.org).

This is an open source community project, you can contribute to the development of the documentation, [github.com/AntShares/docs](https://github.com/AntShares/docs), thanks for visiting.

------

## I. Introduction 

A smart contract is a set of commitments that are defined in digital form, including the agreement that the contractor can perform on these commitments. Blockchain technology gives us a decentralized, non-tampering, highly reliable system in which smart contracts are very useful. Smart contract is one of the most important characteristics of the blockchain, and it is also the main reason why the blockchain can be called disruptive technology. It is making our social structure change with each passing day.

## Second, the characteristics

### 2.1 certainty

If a program is running on a different computer, or at different times on the same computer, the same input can be guaranteed to produce the same output, then the behavior of the program is deterministic and vice versa Is non-deterministic. Blockchain is a multi-party storage, multi-party computing method to achieve the data can not be tampered with a reliable calculation of the results of distributed systems, intelligent contract will be in the blockchain network to run multiple nodes. If a smart contract is non-deterministic, then the results of different nodes may be inconsistent, resulting in consensus can not be reached, the network into a stagnant. Therefore, in the design of intelligent contract system, the need to rule out all may lead to non-deterministic factors.

### 2.1.1 Time

Obtaining system time is a very common system function that may be heavily applied in some time-sensitive contract procedures. But the acquisition time is a non-deterministic system function, the results of different node calls will be inconsistent, in the distributed system is difficult to obtain a unified precise time. Thus, the ant artificial contract only provides a system block based on the block timestamp, which takes the entire blockchain as a timestamp server and obtains the timestamp when any of the blocks are constructed. Since the small ants produce an interval every 15 seconds, the contract runs at about the same time as the latest block time plus about 15 seconds.

### 2.1.2 random number

Many smart contract procedures use random number functions, such as gambling contracts and some small games, but the random function is a typical non-deterministic function, each call will get different results. In a distributed system, there are many ways to solve this problem: the same random seed can be used for all nodes, so that the return sequence of the entire random function is deterministic, but this method exposes the entire random result in advance, making this The practical value of the random number is greatly reduced; another method is to let all nodes communicate in a collaborative way to generate random numbers, it can use some cryptographic techniques to produce a fair random number, but the disadvantage is the performance is very poor, need Additional communication overhead; there is also a way to introduce a centralized random number provider that provides random numbers and ensures consistency, but the drawback of this approach is obvious that the user must trust the provider unconditionally. There are two ways to get a random number on an ant colony: the first is that when each block is constructed, the Consensus node will reach a consensus on a random number and fill it into the Nonce field of the block. The contract procedure Can be read to any block of the Nonce field; the second is the contract program can use the hash value of the block as a random number generation means, because the hash value of the block has a certain randomness, this way can get a Weak random numbers.

### 2.1.3 data source

If a program obtains data at run time and the data source provides non-deterministic data, the program may become a non-deterministic program. For example, through the search engine to get a keyword of the top 10 search results - search engines for different IP address sources may return different sort results.
The AntShares intelligence provides two deterministic data sources:
1) Blockchain book
The contract procedure can access all the data on the entire chain chain through interactive services, including complete blocks and transactions, as well as each of their fields. The data on the blocks are deterministic and consistent, so they can be accessed securely by smart contracts.
2) Contract storage space
Each application contract deployed on a AntShares has a storage space that can only be accessed by the contract itself, and the consensus mechanism of the small ants ensures that the storage status on each node is consistent.
For the case of the need to access the data outside the chain, the small ants did not provide a direct way, through the transaction to the chain data sent to the chain, which converted into the above two types of data sources can be accessed by intelligent contracts.

### 2.1.4 contract call

The smart contract has the ability to call each other, but can not be recursively called. Recursion can be achieved within the contract, but can not cross the boundaries of the current contract. In addition, the call relationship between contracts must be static: that is, the target can not be specified at runtime. This allows the behavior of the program to be fully determined before it can be run, and its call relationship can be fully determined before running, as a basis for dynamic partitioning of multiple contracts to achieve parallel execution.

## 2.2 High performance

The execution environment of an intelligent contract can play a very important role in the performance of the contract. When we analyze the performance of the execution environment, there are two indicators that are critical: the first is the execution speed of the instruction, and the second is the startup speed of the execution environment itself. For smart contracts, the execution speed of the execution environment is often more important than the execution of the instructions. Smart contract is a little more involved in IO operation of the logic to determine the instructions, the implementation of these instructions can easily be optimized. While the smart contract is called each time, you must start a new virtual machine/container. So the execution speed of the execution environment itself (starting a virtual machine/container) has a greater impact on the performance of the smart contract system.
The AntShares uses the lightweight AVM (AntShares Virtual Machine) as its intelligent contract execution environment, it starts very fast, takes up resources is also very small, suitable for such as smart contract short program. The static compilation and caching of hotspot contracts can significantly improve the efficiency of virtual machines by JIT (real-time compiler) technology.

## 2.3 Extensibility

### 2.3.1 high concurrency and dynamic partitioning

When it comes to the scalability of a system, it involves two areas: vertical expansion and horizontal expansion. Vertical expansion is the ability to optimize the processing flow so that the system can take full advantage of existing equipment capacity, this approach is easy to run into the ceiling, a serial system processing capacity depends on the hardware limit of a single device. When we need to expand the system, if there is a way to transform the serial system into a parallel system, then theoretically we only need to increase the number of devices, you can get almost unlimited scalability, this approach is horizontal expansion. Do we have the possibility of unlimited expansion when we consider extending the blockchain system? In other words, can the blockchain handle the business in parallel?
The blockchain is a distributed large book, which records a variety of state data, but also records the rules of how these changes, the smart contract is used to record the rules of the carrier. Whether the chain chain can handle the business in parallel depends on whether multiple smart contracts can be executed concurrently - that is, whether the execution of the contract is orderly. Basically, if the contracts do not interact with each other, or if the contract does not modify the same state data at the same time, their execution is sequential and can be executed concurrently, otherwise it can only be executed serially, Can not scale horizontally.
Based on the above analysis, we can easily design a "unlimited expansion" of the intelligent contract system. Only need to simply specify:
1) an intelligent contract can only modify the status of the contract itself belongs to the record;
2) In the same transaction batch (block), a contract can only be run once;
As a result, all the smart contracts are orderly irrelevant can be handled in parallel. However, if a "smart contract can only modify the status of the contract belongs to their own record", it means that the contract can not call each other, each contract is an island; if "a block, a contract can only be run once "Means that a digital asset issued with a smart contract can only handle a deal in a block. This is obviously and "smart" the original design of the word is very different. After all, the mutual call between the contract, the same block in a number of calls the same contract, are we want the design goals.
Fortunately, the call relationship between the ants' smart contract is static and can not specify the target for the call at run time. This allows the behavior of the program to be fully determined before it can be run, and its call relationship can be fully determined before running. We require that each contract explicitly indicate which contracts are likely to be invoked so that the operating environment can calculate the complete call tree before running the contract procedure and partition the execution of the contract based on the call tree. Contracts that may modify the same state record are executed serially in the same partition, and partitions and partitions can be executed concurrently.

### 2.3.2 Low coupling

Coupling is a measure of two or more entities that depend on each other. The system of the e-smart contract uses a low-coupling design, which is executed in a virtual machine (virtual ant virtual machine) and communicates with the outside through an interactive service layer. Therefore, the vast majority of the upgrade of the smart contract function can be achieved by increasing the API of the interactive service layer.

# Three, contract type

## 3.1 Verify the contract

The purpose of the verification contract is to verify the ownership of the assets in the contract account. When a transaction is to be transferred to an asset in an account, the verification contract corresponding to that account needs to be executed. A validation contract can accept a set of parameters (usually a digital signature or other criteria) and returns a boolean value after verification to indicate to the system whether the verification was successful.
The user may pre-deploy the verification contract to the chain, or publish the contract content directly in the transaction during the transfer process. If the contract is deployed to the chain in advance, the contract can be used not only as a verification contract but also by another contract. You can call the "self-destruction" of the system function to remove the chain has been deployed from the contract, delete and then can no longer be used.

## 3.2 Function contract

The function contract is used to provide some public or common functions for other contracts to be called. It makes the smart contract code can be reused, so that developers can write more complex business logic. The function contract must be pre-deployed to the chain to be called and removed from the chain by "self-destructing" the system function.

## 3.3 Application Contract

The application contract provides the user with a set of related functions, and can save their own running state data, but also in different applications to call each other. You can call the "self-destruction" of the system function to delete the chain has been deployed from the contract, can not be deleted after the use of the corresponding storage area will be deleted.

# 4, virtual machine

## 4.1 Virtual hardware

The ant virtual virtual machine provides a virtual hardware layer to support the execution of smart contracts, including:
1) CPU
CPU is responsible for reading and in the order of the implementation of the instructions in the contract, according to the function of the instruction flow control, arithmetic operations, logic operations. The function of the CPU can be extended in the future, the introduction of JIT (real-time compiler) function, thereby improving the efficiency of instruction execution.
2) Call the stack
The call stack is used to hold the context information of the program execution at each function call so that it can continue execution in the current context after the function completes and returns.
3) Calculate stack
All the run-time data in the ant virtual virtual machine is stored in the calculation stack, and when the different instructions are executed, the data elements in the calculation stack are manipulated accordingly. For example, when the addition instruction is executed, the two operands participating in the addition are ejected from the calculation stack, and the result of the addition is pushed onto the top of the stack. Function call parameters must also be pressed from right to left in the order of the stack, the function can be completed from the top of the stack function return value.
4) standby stack
When you need to schedule or rearrange the elements in the stack, you can temporarily store the elements in the stack on the standby stack and retrieve them in the future.

## 4.2 instruction set

The AntShares virtual machine provides a simple and practical instruction set for constructing an intelligent contract procedure. By function, mainly include the following categories:
1) constant instruction
2) Process control instructions
3) stack operation instructions
4) string instructions
5) Logical instructions
6) arithmetic instructions
7) cryptographic instructions
8) Data manipulation instructions
It is worth noting that the instruction set of the AntShares virtual machine provides a series of cryptographic instructions such as ECDSA, SHA and other algorithms to optimize the efficiency of the implementation of cryptographic algorithms in smart contracts. In addition, data manipulation instructions provide support for arrays and complex data structures directly.

## 4.3 Interactive service layer

The virtual machine where the smart contract is running is a sandbox environment that requires an interactive service layer when the contract needs to access data outside the sandbox or when the runtime data is persisted, which provides the smart contract for the virtual machine The media of external communication. In the interactive service layer, a series of system functions and services are exposed to the intelligent contract procedure. The contract can be accessed like an ordinary function. All system functions are concurrency, so there is no need to worry about the scalability problem.

## 4.4 Debugging function

Often, the development of a smart contract is very difficult because there is no good debugging and testing method. The small ants at the virtual machine level provides the support of the program debugging function, you can set the breakpoint on the contract code, you can also single-step, single-process execution. Thanks to the low coupling design between the virtual machine and the blockchain, it is easy to integrate the ant virtual machine directly with the various IDEs to provide a test environment that is consistent with the final production environment.

# 5, high-level language

## 5.1 C #, VB.Net, F #

Developers can use almost any high-level language they are good at for the development of ants' smart contracts. The first supported languages ​​are C #, VB.Net, F #, etc., which provide compilers and plug-ins for these languages ​​for compiling high-level languages ​​into instruction sets supported by AntShares virtual machines. As the compiler will be for MSIL (Microsoft intermediate language) to compile, so theoretically any. Net language or can be translated into MSIL language can be directly directly supported.
The number of developers in these languages ​​is numerous and has a very strong integrated development environment. Developers can develop, test, debug and debug a series of development work in Visual Studio, and can also use the intelligence provided by the small ants Contract development template for quick entry.

## 5.2 Other languages

Follow-up, small ants will be based on the degree of difficulty to sub-batch development of various other high-level language compiler, there may be these languages:
1) Java
2) C, C ++, GO
3) Python, JavaScript
The future will continue to add new high-level language support, so that 90% of developers do not need to learn new language can participate in the development of AntShares smart contract, and even the existing business system code can be directly transplanted to the district Block on the chain.

# 6, service

## 6.1 Block Chain Book

The immovable smart contract can obtain the complete account data of the AntShares blockchain, including the complete block and the transaction, and each of their fields, at runtime, through the system functions provided by the interactive service. Specifically, you can query these data:
1) the height of the blockchain;
2) Block head, block;
3) transactions;
4) the type of transaction, attributes, input, output, etc .;
Through these data, you can develop some interesting applications, such as automatic dividends, based on the workload of intelligent contracts and so on.

## 6.2 Digital assets

Through the digital service interface provided by the interactive service, the intelligent contract can not only query the attributes and statistics of various digital assets on the small block area chain, but also create new digital assets at run time. The digital assets created by the smart contract can be issued, transferred, traded, etc. outside the contract, which, like the original assets of the small ants, can be managed with any wallet software that is compatible with the small ants. The specific interface mainly has these:
1) asset attribute query;
2) asset statistics query;
3) Asset life cycle management: create, modify, destroy, etc .;
4) asset management: multi-language name, total change, precision changes, changes in the administrator;

## 6.3 Persistence

Each of the intelligent contract procedures deployed on the chain area will have a storage area where only the contract itself can read and write. Smart contract has full operational rights to the data in its own store: can read, write, modify, delete. The data is stored in the form of key-value pairs and provides these interfaces:
1) traverses all records in the store;
2) return to a specific record according to the specified key;
3) modify or write new records according to the specified key;
4) delete the record according to the specified key;
In general, a contract can only read and write data from its own store, with one exception: when a contract is invoked, the invoked contract can access the caller's store through a cross-domain request. A total of three storage areas can be requested:
1) the current area
2) Direct caller's storage area
3) the storage area of ​​the root caller
Cross-domain requests enable lazy smart contracts to provide richer library capabilities that provide highly portable data management capabilities for callers.

# Seven, the cost

## 7.1 Deployment costs

The distributed structure of the small-ants blockchain provides high redundancy of storage capacity, and the use of this capability is not free. The cost of deploying a smart contract on a small chain block is now fixed at 500ANC, which is collected by the system and becomes a system gain. The future may be based on the actual operation of the system to adjust the price. The smart contract deployed on the chain chain can be used multiple times until the contract is destroyed by the deployer.

## 7.2 Execution Fee

The small block area provides a credible execution environment for the smart contract, and the execution of the contract also consumes the computing resources of the nodes, so the user needs to pay for the execution of the smart contract. The number of costs is determined by the computational resources consumed by each execution, and the unit of pricing is ANC, which is charged by the consensus node of the small-ants block. If the implementation of the process due to lack of costs lead to the implementation of intelligent contract failure, the cost of consumption will not be returned, which can prevent malicious attacks on the total network computing power consumption.

# 8, the application of the scene

## 8.1 Superconducting transaction

Digital assets on the chain chain are inherently mobile demand, and usually point-to-point transactions can not provide sufficient liquidity, so the need for the exchange to provide users with trading services. Digital assets of the exchange will generally be divided into two categories: the first is the central exchange, the user needs to recharge the digital assets to the exchange, and then on the site to order a single transaction; the second category is to the central exchange, Its trading system is built into the blockchain system, provided by the system matching services.
Centralized exchanges can provide very high performance and diversified services, but need to have a strong credit guarantee, otherwise there will be moral hazard, such as misappropriation of user funds, Paolu and so on. Relatively, to the center of the exchange although there is no moral hazard, but the user experience is poor, performance also has a greater bottleneck. Is there a way to combine the advantages of both to provide a best of both worlds?
Superconducting transactions can do this, it is a mechanism: users do not need to recharge, you can directly use their own assets in the chain chain to trade, the transaction settlement in the chain to complete, but the process of matching Outside the chain, by a central exchange to provide matching services. Due to the match in the chain, its efficiency can be as high as the central exchange, but the assets are still under the control of the user, the exchange can be based on the user's trading intent to carry out matching services, but can not divert funds or Paolu, no Moral Hazard.
At present, the AntShares community has been the emergence of some use of ants intelligent contract to achieve the blockchain superconducting transactions, such as blue whale scouring.

## 8.2 Smart Fund

## 8.3 cross-chain interoperability

It is foreseeable that in the future for a long period of time, there will be a number of public chains in the world and thousands of alliance chains and private chains coexist. These independent block-chain systems are islands of value and information that are interoperable with each other. Through the cross-chain interoperability mechanism, numerous isolated blocks can be linked together, so that the value of different blocks can be exchanged on each other to form a real value of the Internet.
The e-smart contract provides support for the implementation of cross-chain interoperability, not only for cross-chain asset switching, but also for running cross-chain distributed transactions, running smart contracts on different blockchains, and ensuring their consistency.

## 8.4 Echo machine

A whisper can be seen as a tuple machine connected to a prophet (oracle). The so-called prophet's concept is an entity that can answer a particular set of questions. In the blockchain, the whistleblower opens the door to the outside world for smart contracts, making it possible to use real-world information as a condition for contract execution. Ants' smart contract does not provide the ability to access external data directly, such as access to resources on the Internet, as this introduces non-deterministic, making the nodes appear inconsistent with the results of contract execution.
In the small-ants blockchain to achieve the whistle machine, the need for a trusted third party to external data through the form of transactions sent to the blockchain, making this information become part of the book data, thus eliminating the uncertainty. The credible third party referred to in the preceding article may be a person or institution co-trusted by both parties to the contract, or a decentralized data provider that is guaranteed by economic incentives. To achieve such a whistle machine.

## 8.5 Ethernet Square Series DAPP

Bitcoin created a chain of chains and electronic cash, the ether square is to create a smart contract era. With the pioneer of the intelligent contract of the blockchain, it is a great contribution to the design idea, economic model and technology realization of the intelligent contract system. At the same time, there are already a lot of DAPP (distributed application) on the platform, which has different functions, such as gambling agreement, digital assets, electronic gold, game platform, medical insurance, marriage platform, industry. All of these DAPP, theoretically can be easily transplanted to the platform of small ants, as the application of small ants.

# 9, explore

## 9.1 version control

Smart contracts need to be deployed to the blockchain before they can be distributed. Once the contract code is deployed, it can not be modified because the behavior of the program needs to be determined by the user before running. If the contract code can be arbitrarily modified or upgraded, it is bound to bring some moral hazard: for example, the original contract is the transfer of assets to the user specified account, but one day was "upgraded" for all assets were transferred to the contract development In the account to go. Because it is not possible to prevent this type of risk in the mechanism, the current e-smart contract can not be upgraded once it is deployed, and only the user is informed that the asset is transferred to the new contract and then the old contract is destroyed. The future requires a mechanism to enable smart contracts to be dynamically upgraded in a secure way.

## 9.2 IPFS resource access

At present, the smart contract on the system can only access the data in its own storage area, the future may need a shared public storage between the contract, the storage area through the hash table to retrieve the file, and distributed Stored on the nodes of the small ants. May be implemented through DHT (Distributed Hash Table) or IPFS (InterPlanetary File System).
