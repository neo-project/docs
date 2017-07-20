# NEO white paper

A kind of intelligent economic distributed network

## NEO design goals: intelligent economy

NEO is the use of block-chain technology and digital identity of the digital assets, the use of intelligent contracts for digital assets for automated management, to achieve "intelligent economy" of a distributed network.

### digital assets

Digital assets are programmable control assets that exist in the form of electronic data. With the block chain technology to achieve the digitization of assets to the center, to intermediary, free of trust, traceable, highly transparent and so on. NEO supports multi-digit assets at the bottom. Users can register their own assets on the NEO, free trade and circulation, and solve the mapping with physical assets through digital identity. The assets registered by the user through a registered digital identity are protected by law.

NEO has two forms of digital assets: global assets and contractual assets. The global assets can be recorded in the system space and can be identified by all the smart contracts and the client. The contract assets are recorded in the private storage area of ​​the smart contract and need to be compatible with the client. Contract assets can refer to a certain standard of agreement, in order to achieve compatibility with most clients.

### digital identity

Digital identity refers to the identity of individuals, organizations, and things that exist in electronic form. The more mature digital identity system is based on the PKI (Public Key Infrastructure) X.509 standard. In NEO, we will implement a set of X.509 compatible digital identity standards. This set of digital identity standards, in addition to compatible X.509 level certificate issuance model, will also support Web Of Trust point-to-point certificate issuance model. And through the face, fingerprint, voice, SMS and other multi-factor authentication to achieve the stage and the use of the stage of the real identity comparison. At the same time, will also use the block chain to replace the OCSP protocol to manage, record X.509 revocation certificate list CRL.

### Smart contract

The smart contract was first proposed by the cryptographer Nick Szabo in 1994, almost the same age as the Internet. According to Nick Szabo's definition: When a pre-programmed condition is triggered, the smart contract executes the corresponding contract terms. Block chain technology gives us a decentralized, non-tampering, highly reliable system in which smart contracts are very useful. NEO has an independent intelligent contract system: NeoContract.

NeoContract intelligent contract system is the biggest feature of the seamless docking of the existing developer ecology. Developers do not need to learn new programming language, can use C #, Java and other mainstream programming language in the familiar IDE environment (Visual Studio, Eclipse, etc.) in the intelligent contract development, debugging, compile. NEO's Universal Lightweight Virtual Machine NeoVM has the advantages of high certainty, high concurrency, and high scalability. NeoContract intelligent contract system so that millions of developers around the world to quickly carry out the development of intelligent contracts. NeoContract will have an independent white paper describing the implementation details.

### application and ecology

Ecology is the vitality of the open source community project. In order to achieve the goal of intelligent economic network, NEO will be committed to the development of developer ecology, to provide mature development tools, improve the development of documents, organize education and training activities, to provide financial support. We plan to support the following NEO-based applications and ecology and to reward the design of the improvement and improvement experience:

🔹 ** node program **

- Full function of PC full node program

- Better experience PC light node program

- Provides Web / Android / iOS clients that do not need to synchronize block chains

- hardware wallet


🔹 ** block chain browser **

SDK Development Kit **

- support Java / Kotlin, .NET C # / VB, JavaScript / Typescript, Python, Go

Smart Contract Compiler and IDE Plugin **

- C # / VB.Net / F #, Visual Studio

- Java / Kotlin, Eclipse

- C / C ++ / GO

- JavaScript / TypeScript

- Python / Ruby

🔹 ** to the center of the application **

- Smart Fund

AI-assisted legal intelligence contract

- Social networking

- Automated tokens liquidity providers

- to the center of the exchange

- Secure communication protocol

- Data exchange market

- IP trading market

- Forecast the market

- Advertising market

- Power market

- NeoGas market

## NEO management mode

### Economic model

NEO has two native tokens, NEO (abbreviated NEO) and NeoGas (abbreviated symbol GAS).

NEO is the management of tokens, a total of 100 million copies, for the realization of the NEO network management. Management rights include voting for bookkeeping, NEO network parameter changes, and so on. The minimum unit of NEO is 1 and can not be divided.

GAS is fuel tokens, the maximum total limit of 100 million, for the realization of NEO network resource control. The NEO network charges for the operation and storage of tokens and smart contracts, thereby achieving economic incentives for journalists and preventing the abuse of resources. The minimum unit of GAS is 0.00000001.

In the creation block of the NEO network, 100 million NEOs have been generated, and GAS has not yet been generated, and the number is zero. 100 million copies of NEO corresponding to the 100 million GAS, will be through a decay algorithm in about 22 years time to gradually generate to the NEO management tokens address. After the NEO management token is transferred to the new address, the subsequent GAS will also be generated at the new address.

The NEO network will set a threshold by voting to exempt GAS from a certain amount of transfer transactions and smart contract operations to enhance the use experience. When a large amount of spam transactions occur, NeoID can be used to prioritize transactions with qualified identities and smart contracts. Transactions and smart contracts with no qualifying digital identities can be given priority by paying GAS.

### Distribution mechanism

NEO distribution:

NEO's 100 million management token is divided into two parts, the first part of the 50 million copies of NEO for the round and proportion distributed to the NEO development funding supporters, the part has been distributed.

The second part is 50 million copies managed by the NEO Council to support NEO's long-term development, operation and maintenance and ecological development. The NEO of this part is in lockout period and is unlocked when the NEO network runs for up to 1 year on October 16, 2017. This part of the NEO will not enter the exchange transactions, only for long-term support NEO project, plans to use the following proportion:

10 million copies (10% total) are used to motivate NEO developers and members of the NEO Council

10 million copies (10% total) are used to motivate NEO surrounding eco developers

15 million copies (15% of the total) are used to cross-invest in other block-chain projects, which are owned by the NEO Council and are used only for NEO projects

🔹 15 million (total 15%) mobile use

The annual use of NEO in principle shall not exceed 15 million copies

GAS distribution:

GAS is generated with the generation of each new block. The initial total amount of GAS is zero, with the formation of new blocks gradually increased, until about 22 years after the total limit of 100 million. NEO The interval between each block is about 15-20 seconds, and 2 million blocks are about one year.

The first year (actually 0-200 million blocks), each block to generate eight new GAS; the second year (actually the first 200-400 million blocks), each block newly generated seven GAS ; And so on, the annual reduction of a GAS, until the first eight years to each block to generate a new GAS; since then to keep each block a new GAS until about 22 years after the 44 million Block, GAS total reaches 100 million, then stop with the new block to generate GAS.

According to this release curve, 16% of the GAS will be created in the first year, 52% of the GAS will be created in the first four years, and 80% of the first 12 years will be created. These GAS will be in accordance with the NEO holding ratio, recorded in the corresponding address. NEO holders can initiate a claim transaction at any time and claim these GASs at the address of NEO.

### Governance mechanism

Chain management: NEO management tokens holders are NEO network owners and managers, through the NEO network to construct a voting transaction to achieve management rights, through the NEO management tokens corresponding to the GAS fuel tokens to achieve NEO network. NEO management token can be transferred.

Under the chain governance: NEO Council is the founder of the NEO project established by the executive management agencies, under the management committee, technical committee and the Secretariat, respectively, responsible for strategic decision-making, technical decision-making and specific implementation. The NEO Council is responsible to the NEO community for the promotion and development of NEO ecology as its primary objective.

## NEO technology implementation

### Consensus mechanism: DBFT

DBFT is called the Delegated Byzantine Fault Tolerant, a Byzantine fault-tolerant consensus mechanism that enables large-scale nodes to participate in consensus through proxy voting. The holder of the NEO management token can, by voting, pick up the registrant it supports. The BFT algorithm is then passed by the selected group of accounts to reach a consensus and generate new blocks. Voting in the NEO network continues in real time, rather than in accordance with the fixed term.

DBFT provides fault tolerance for f =  (n-1) / 3 bits for a consensus system consisting of n consensus nodes. This fault tolerance also includes both security and availability, resistance to general and Byzantine failures, and In any network environment. DBFT has a good finality, a confirmation that the final confirmation, the block can not be bifurcated, the transaction will not be revoked or rollback.

In the NET DBFT consensus mechanism, every 15 to 20 seconds to generate a block, the transaction throughput measured up to about 1000tps, excellent performance in the public chain. Through appropriate optimization, the ability to reach 10,000TPS, can support large-scale commercial applications.

DBFT combines digital identity technology, making the accountant can be a real name of the individual or institution. Thus making it possible to freeze, revoke, inherit, retrieve, and judge the transfer of judicial decisions. This facilitates the registration of compliance financial assets in the NEO network. The NEO network plans to support such operations when necessary.

### Smart contract system: NeoContract

NEO's intelligent contract system consists of three parts:

** NeoVM - Universal Block Chain Virtual Machine: **

NeoVM is a lightweight, general-purpose virtual machine whose architecture is very close to the JVM and .NET Runtime, similar to a virtual CPU that reads and executes instructions in the contract in sequence, performs process control based on the functionality of the instruction Operations, logic operations and so on. It has a good start-up speed and versatility, is very suitable for intelligent applications such as small programs can also be ported to non-block chain of the scene, or integrated with the IDE to provide a good development experience. NeoVM can be extended to the function, the introduction of JIT (real-time compiler) mechanism, thereby enhancing the efficiency of the implementation of the instructions.

** InteropService - Interoperable Services: **

Used to load the block chain books, digital assets, digital identity, persistent storage area and other underlying services. They are like virtual machines that are provided for virtual machines, enabling smart contracts to access these services at run time to achieve some advanced functionality. Through this low-coupling design, ** NeoVM can be ported to any block chain or even non-block chain system used, making the application of intelligent contracts greatly expanded. **

** DevPack - Compiler and IDE plugin: **

DevPack includes the high-level language compiler and the IDE plug-in. Because NeoVM's architecture is highly similar to the JVM, .NET Runtime, these compilers in DevPack can compile the intermediate language of Java byte code and .NET MSIL into NeoVM's instruction set. Java / Kotlin, C # developers do not need to learn new languages, in VS, Eclipse and other familiar IDE environment will be able to immediately begin to prepare smart contracts. ** This makes the learning contract cost of smart contract greatly reduced, can build a rich NeoContract intelligent contract ecology. **

NeoContract can create a smart contract call tree through static analysis before running an intelligent contract. Through the deterministic call tree, the NEO node can dynamically fragment the smart contract to achieve theoretically unlimited expansion **, which overcomes the "jamming effect" caused by the static fragmentation of other block chain systems.

### Cross-chain interoperability agreement: NeoX

NeoX is a protocol that implements cross-chain interoperability. NeoX is divided into two parts: "cross-chain asset exchange protocol" and "cross-chain distributed transaction protocol."

** Cross-chain asset exchange agreement: **

NeoX has been extended on existing double-stranded atomic asset exchange protocols to allow multiple participants to exchange assets across different chain chains and to ensure that all steps in the entire transaction process succeed or fail all. In order to achieve this function, we need to use NeoContract function, for each participant to create a contract account. Correct
