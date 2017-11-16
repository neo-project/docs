# A Byzantine Fault Tolerance Algorithm for Blockchain 

Erik Zhang

erik@vcage.com 

## Abstract 

​This article proposes an improved Byzantine Fault Tolerance algorithm, adjusted for a blockchain system. Hypothetically, in this system, messages may subject to loss, damage, latency, and repetition. Also, the sending order may not necessarily be consistent with the receiving order of messages. The activities of nodes could be arbitrary, they may join and quit the network at any time; they may also dump and falsify information or simply stop working. Artificial or non-artificial glitches may occur as well. Our algorithm provides a  𝑓 = ⌊ (𝑛−1) / 3 ⌋  fault tolerance to a consensus system that comprises n nodes. This tolerance capacity includes security and usability and is suited for any network environment. 

## Overview 

A blockchain is a decentralized distributed ledger system. It could be used for registration and issuance of digitalized assets, property right certificates, credit points and so on. It enables transfer, payment, and transactions in a peer-to-peer way. The blockchain technology was originally proposed by Satoshi Nakamoto in a cryptography mailing list, i.e. the Bitcoin. Since then, numerous applications based on the blockchain emerged, such as e-cash systems, stock equity exchanges and Smart Contract systems.

A blockchain system is advantageous over a traditional centralized ledger system for its full-openness,immutability and anti-multiple-spend characters, and it does not rely on any kind of trusted third-party.

However, like all distributed systems, blockchain systems are challenged with network latency, transmission errors, software bugs, security loopholes and black-hat hacker threats. Moreover, its decentralized nature suggests that no participant of the system cannot be trusted. Malicious nodes may emerge, so does data difference due to conflicting interests.

To counter these potential errors, a blockchain system is in need of an efficient consensus mechanism to ensure that every node has a copy of a recognized version of the total ledger. Traditional fault tolerance mechanisms concerning certain problems may not be completely capable of tackling the issue that distributed and blockchain systems are faced with. A universal cure-to-all fault tolerance solution is in need.

Proof-of-Work mechanism[1], employed by the Bitcoin, addresses this issue rather brilliantly. But it comes with an obvious price, i.e. significant electricity cost and energy consumption. Further, with Bitcoin’s existence, new blockchains must find different hashing algorithms, so as to prevent computational attacks from it. For example, Litecoin adopts SCRYPT, rather than Bitcoin’s SHA256.

Byzantine Fault Tolerance mechanism is a universal solution for distributed systems[5]. Here in this article, based on the Practical Byzantine Fault Tolerance (PBFT)[3] proposed by Castro and Liskov in 1999, an improved Byzantine Fault Tolerance algorithm is proposed for blockchain systems。 

## System Model 

A blockchain is a distributed ledger system in which participants connect with each other via a peer-to-peer network. All messages within it will be sent by broadcasting. Two types of roles exist: Ordinary nodes and Bookkeeping nodes. Ordinary nodes use the system to transfer and exchange, accepting ledger data; while bookkeeping nodes provide accounting service for the entire network and maintain the ledger. 

Hypothetically, in this system, messages may subject to loss, damage, latency and repetition. Also, the sending order may not necessarily be consistent with the receiving order of messages. The activities of nodes could be arbitrary, they may join and quit the network at any time; they may also dump and falsify information or simply stop working. Artificial or non-artificial glitches may occur as well.

Integrity and Authenticity of information transmission are ensured with cryptography while senders must attach signatures to the hash value of the message sent. Here we define 〈𝑚〉<sub>𝜎𝑖</sub> is the message m’s digital signature from node i, while D(m) is the hash value of message m. Without special clarification, all signature referred to in this article are signatures to the message hash value. 

## The Algorithm 

​Our algorithm ensures security as well as usability. With erroneous nodes in the consensus making no more than ⌊ (𝑛−1) / 3 ⌋ , the functionality and stability of the system is guaranteed. In it, 𝑛 = |𝑅| suggests the total number of nodes joined in the consensus making while R stands for the set of consensus nodes. Given 𝑓 = ⌊ (𝑛−1) / 3 ⌋ , f stands for the maximum number of erroneous nodes allowed in the system. In fact, the total ledger is maintained by bookkeeping nodes while ordinary nodes do not participate in the consensus making. This is to show the entire consensus making procedures.

All consensus nodes are required to maintain a state table to record current consensus status. The data set used for a consensus from its beginning to its end is called a View. If consensus cannot be reached within the current View, a View Change will be required. We identify each View with a number v, starting from 0 and it may increase till achieving the consensus.

​We identify each consensus node with a number, starting from 0, the last node is numbered n − 1. For each round of consensus making, a node will play speaker of the house while other nodes play congressmen. The speaker’s number p will be determined by the following algorithm: Hypothetically the current block height is h, then 𝑝 = (ℎ − 𝑣) 𝑚𝑜𝑑 𝑛, p’s value range will be  0 ≤ 𝑝 < 𝑛 .

​A new block will be generated with each round of consensus, with at least 𝑛 − 𝑓 signatures from bookkeeping nodes. Upon the generation of a block, a new round of consensus making shall begin, resetting v=0.

###  General Procedures 

Set the time intervals of block generation as t, under normal circumstances, the algorithm executes in the following procedures：

1) A node broadcasts transaction data to the entire network, attached with the sender signature;

2) All bookkeeping nodes monitors transaction data broadcasting independently and stores the data in its memory respectively; 

3) After the time t, the speaker sends 〈𝑃𝑒𝑟𝑝𝑎𝑟𝑒𝑅𝑒𝑞𝑢𝑒𝑠𝑡,ℎ,𝑣,𝑝,𝑏𝑙𝑜𝑐𝑘,〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑝</sub>〉； 

4) After receiving the proposal, congressmen i send 〈𝑃𝑒𝑟𝑝𝑎𝑟𝑒𝑅𝑒𝑠𝑝𝑜𝑛𝑠𝑒,ℎ,𝑣,𝑖,〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑖</sub>〉 ;

​5) Any node, upon receiving at least 𝑛 − 𝑓  〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑖</sub>, reaches a consensus and publishes a full block;

6) Any node, after receiving the full block, deletes the transaction in question from its memory and begins the next round the consensus;

It is required that, for all the consensus nodes, at least 𝑛 − 𝑓 nodes are in the same original state. This is to say, for all the nodes i, the block height h and View number v are the same. This is not difficult, consistency of h could be reached by synchronizing the blocks while consistency of v could reached by changing the View. Block synchronizing is not covered in this article. For View change, check next section.

Nodes, after monitoring the broadcasting and receiving the proposal, shall validate the transactions. They cannot write an illegal transaction in the memory once the latter is exposed. If an illegal transaction is contained in the proposal, this round of consensus will be abandoned and the View change will take place immediately. The validation procedures are as follows:

1) Is the data format of the transaction consistent with the system rules? If no, the transaction is ruled illegal;

2) Is the transaction already in the blockchain? If yes, the transaction is ruled illegal;

3) Are all the contract scripts of the transaction correctly executed? If no, the transaction is ruled illegal;

4) Is there multiple-spend in the transaction? If yes, the transaction is ruled illegal;

5) If the transaction had not been ruled illegal in the above procedures, it will be ruled legal;

### View Change 

If, after 2<sup>𝑣+1</sup> ⋅ 𝑡 time interval, the nodes i cannot reach a consensus or should they receive proposals that contain illegal transactions, the View Change will take place: 

1) Given k=1, 𝑣<sub>𝑘</sub> = 𝑣 + 𝑘 ;

2) Nodes i send View Change request 〈𝐶ℎ𝑎𝑛𝑔𝑒𝑉𝑖𝑒𝑤,ℎ,𝑣,𝑖,𝑣<sub>𝑘</sub>〉 ;

3) Once any node receives at least 𝑛 − 𝑓  same v<sub>k</sub> from different i, the View Change is
completed. Set 𝑣 = 𝑣<sub>𝑘</sub> and the consensus making begins;

4) If, after 2<sup>𝑣+1</sup> ⋅ 𝑡 time interval, the View Change is not completed, the k will increase and back to step 2);

With the k increasing, the overtime waiting time will increase exponentially, so frequent View Change will be avoided and nodes are urged to reach consistency over v.

Before the completion of View Change, the original View v is still valid, so unnecessary View Change caused by occasional network latency can be avoided. 

### Flow Chart

![](~/assets/consensus_flowchart.jpg)

## Fault Tolerance Capacity 

​Our algorithm provides 𝑓 = ⌊ (𝑛−1) / 3 ⌋ fault tolerance to a consensus system that comprises n nodes. This tolerance capacity includes security and usability and is suite for any network environment.

Request data from nodes contain sender signatures, so malicious bookkeeping nodes cannot falsify requests. Instead, they will try to reverse the system status back to the past, forcing the system to fork.

Hypothetically, in the network environment of the system, consensus nodes are divided into 3 parts: 𝑅 = 𝑅1 ∪ 𝑅2 ∪ 𝐹 , and 𝑅1 ∩ 𝑅2 = ∅ , 𝑅1 ∩ 𝐹 = ∅ ，𝑅2 ∩ 𝐹 = ∅ . Also hypothetically,
both R1 and R2 are honest bookkeeping nodes in an information silo that they can only communicate with nodes in their set; F are all malicious nodes in coordination; moreover, the network condition of F allows them to communicate with any node, including R1 and R2.
If F wishes to fork the system, they have to reach consensus with R1 and publish blocks, and
then reach a second consensus without informing the R2, revoking the consensus with R1.
​To reach this, it is necessary that |𝑅1| + |𝐹| ≥ 𝑛 − 𝑓 and |𝑅2| + |𝐹| ≥ 𝑛 − 𝑓 .
In the worst case scenario, |𝐹| = 𝑓​ , i.e. the number of malicious nodes is at the maximum that the system could tolerate the aforementioned relation becomes |𝑅1| ≥ 𝑛 − 2𝑓​ and ​|𝑅2| ≥ 𝑛 − 2𝑓. Added together, |𝑅1| + |𝑅2| ≥ 2𝑛 − 4𝑓​, which could be simplified as ​𝑛 ≤ 3𝑓. Given that 𝑓 = ⌊ (𝑛−1) / 3 ⌋, which contradicts with the former, it can be proven that the system cannot be forked within the tolerance range. 

## Reference 

[1] Nakamoto S. Bitcoin: A peer-to-peer electronic cash system[J]. 2008. 

[2] Lamport L, Shostak R, Pease M. The Byzantine generals problem[J]. ACM Transactions on Programming Languages and Systems (TOPLAS), 1982, 4(3): 382-401. 

[3] Castro M, Liskov B. Practical Byzantine fault tolerance[C]//OSDI. 1999, 99: 173 186.

[4] Bracha G, Toueg S. Asynchronous consensus and broadcast protocols[J]. Journal of the ACM (JACM), 1985, 32(4): 824-840. 

[5] 范捷, 易乐天, 舒继武. 拜占庭系统技术研究综述[J]. 软件学报, 2013, 6: 012. 

