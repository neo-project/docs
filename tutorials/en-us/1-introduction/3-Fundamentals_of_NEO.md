# Neo Fundamentals

Neo is a public blockchain that offers smart contract functionality, allowing developers to build decentralized applications that can manage digital assets and identities. It is often compared to [Ethereum](https://www.ethereum.org/), the largest and most well known smart contract platform, however the two have many fundamental differences that set them apart.

## Dual Token Model

Although Neo can support an unlimited number of digital assets created by contracts, it has two assets that are native to the network itself; NEO and GAS.

NEO, referred to as the governance token, is used to elect consensus nodes via the use of a voting mechanism. NEO owners can be considered as the managers of the NEO network, responsible for selecting which candidates are best suited to participate in the creation and validation of blocks.

In return, NEO holders receive GAS, the second native asset on the Neo blockchain. GAS is the utility token, used to pay for operations on the network. This includes system fees, such as the cost of deploying a smart contract, and also network fees that are used to give priority to a transaction.

## Consensus and Transaction Finality

Unlike the majority of current blockchains that use variants of PoW (Proof-of-Work) or PoS (Proof-of-Stake) for their respective consensus mechanisms, Neo uses an original consensus mechanism known as dBFT (delegated Byzantine Fault Tolerance).

PoW- and PoS-based consensus mechanisms encourage a large number of participants to propose blocks to the network. Conflicts are resolved through the use of forks, with the longest chain considered to be the truthful chain. 

In these blockchains, transactions within blocks are finalized over time in a probabilistic manner through the use of confirmations. The more blocks have been added to the blockchain since the block containing a given transaction, the less likely that transaction will be nullified by a fork.

In dBFT, Neo owners vote to elect a set of consensus nodes; a delegated group responsible for producing blocks. Each block in Neo must be agreed on by a 2/3 majority of consensus nodes before it is committed to the blockchain. 

As each potential block must receive full network consensus in this manner before being accepted, transactions in Neo have absolute finality as soon as they are confirmed in a single block. This prevents transactions from being reversed by preventing forks, allowing for immediate settlement of all transactions on the network.

## Contract Languages

In an effort to be as developer-friendly as possible, Neo supports a diverse list of programming languages that can be used to create smart contracts. Currently, Neo allows contracts to be created in C#, Java, Python, Golang, JavaScript/TypeScript, and other languages.

Contracts in Neo are compiled to NVM bytecode before being deployed to the Neo blockchain. When called, these deployed contracts are interpreted and executed by NeoVM.

